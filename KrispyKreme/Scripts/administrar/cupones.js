var Krispy = Krispy || {};
Krispy.Cupones = Krispy.Cupones || {};

Krispy.Cupones = (function () {
    "use strict";
    let CuponLoad = function () {
        let Comun = Krispy.Comun;
        let CONTROLLER = "/Cupones";        

        this.initialize = function () {
            iniTablaCupones();
        };

        let iniTablaCupones = function () {
            $("#tblCupones").DataTable({
                "searching": true,
                "ordering": false,
                "info": false,
                "dom": '<f<t>ip>',
                "language": {
                    "url": "/Content/plugins/dataTable/datatable_language.json"
                },
                "ajax": {
                    url: `${CONTROLLER}/LstCupones`,
                    type: "POST",
                    datatype: "json"                    
                },
                "columns": [
                    {
                        data: "Codigo",
                    },
                    {
                        data: "Titulo",
                    },
                    {
                        data: "Serie",
                    },
                    {
                        data: "Vigencia",
                        render: function (data, type, row, meta) {
                            let vigencia = moment(data).format("YYYY-MM-DD")
                            return '<p>' + vigencia + '</p>';
                        },
                    },
                    {
                        data: "Estatus.Nombre",
                    },
                    {
                        data: "Establecimiento.Nombre",
                    },
                    {
                        visible: $("#hdPuedeEditar").val(),
                        data: "CuponID",
                        render: function (data, type, row, meta) {
                            return '<i style="cursor:pointer" class="fa fa-edit" data-idcupon=' + data + '></i>';
                        },
                    },
                    {
                        visible: $("#hdPuedeEliminar").val(),
                        data: "CuponID",
                        render: function (data, type, row, meta) {
                            return '<i style="cursor:pointer" class="fa fa-trash" data-idcupon=' + data + '></i>';
                        },
                    }
                ],
                "columnDefs": [
                    {
                        targets: [5, 6],
                        createdCell: function (td, cellData, rowData, row, col) {
                            $(td).addClass("text-center");
                        }
                    }
                ],
                "initComplete": function (settings, json) {
                    iniEventosTablaCupones()
                }
            });
        }

        let iniEventosTablaCupones = function () {
            $("#btnAddCupon").click(function () {
                $.ajax({
                    url: `${CONTROLLER}/FrmCupon`,
                    data: { IdCupon: 0 }
                }).done(function (response) {
                    $("#bodyAddCupon").html("");
                    $("#bodyAddCupon").html(response);
                    $("#addCupon").modal("show")
                    enviarCupon();
                });
            })

            $("#tblCupones").off("click", ".fa-trash")
            $("#tblCupones").on("click", ".fa-trash", function () {
                let IdCupon = $(this).attr("data-idcupon")
                $.confirm({
                    title: "Eliminar cupón",
                    icon: "fa fa-question-circle",
                    content: "¿Deseas eliminar el cupón?",
                    type: "red",
                    typeAnimated: true,
                    closeIcon: true,
                    closeIconClass: "fa fa-close",
                    columnClass: "col-md-4",
                    buttons: {
                        cancelar: {},
                        eliminar: {
                            btnClass: "btn-danger",
                            action: function () {
                                $.ajax({
                                    url: `${CONTROLLER}/DeleteCupon`,
                                    type: "POST",
                                    data: { IdCupon: IdCupon }
                                }).done(function (response) {
                                    if (response) {
                                        $.alert({
                                            title: "Cupón eliminado",
                                            type: "green",
                                            content: "El cupón se eliminó correctamente",
                                            buttons: {
                                                Ok: {
                                                    action: function () {
                                                        window.location.reload();
                                                    }
                                                }
                                            }
                                        })
                                    } else {
                                        $.alert({
                                            title: "Algo salió mal",
                                            type: "orange",
                                            content: "Intente más tarde"
                                        })
                                    }
                                });
                            }
                        }
                    }
                });
            })

            $("#tblCupones").off("click", ".fa-edit")
            $("#tblCupones").on("click", ".fa-edit", function () {
                let idProject = $(this).attr("data-idcupon")
                $.ajax({
                    url: `${CONTROLLER}/FrmCupon`,
                    data: { IdCupon: idProject }
                }).done(function (response) {
                    $("#bodyAddCupon").html("");
                    $("#bodyAddCupon").html(response);
                    $("#addCupon").modal("show")
                    enviarCupon();
                });
            })
        }

    };

    return new CuponLoad();
})();
(function ($, window, document) {
    "use strict";
    $(function () {
        Krispy.Cupones.initialize();
    });
})(window.jQuery, window, document);
