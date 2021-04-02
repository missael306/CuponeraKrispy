var Krispy = Krispy || {};
Krispy.Home = Krispy.Home || {};

Krispy.Home = (function () {
    "use strict";
    let HomeLoad = function () {
        let Comun = Krispy.Comun;
        let Controller = "/Home";

        this.initialize = function () {            
            canjearCupon();
        };      

        let canjearCupon = function () {
            $(".canjearCupon").click(function (event) {
                event.preventDefault();
                let idCupon = $(this).attr("data-idcupon");                
                $.ajax({
                    url: `/Cupones/CanjearCupon`,
                    data: { idCupon: idCupon }
                }).done(function (response) {
                    console.log(response)
                    if (response.ValidaCuponID == 0) {
                        $.alert({
                            title: "Cupon canjeado",
                            type: "green",
                            content: response.MensajeValidacion
                        })
                    } else {
                        $.alert({
                            title: "Cupon no canjeable",
                            type: "orange",
                            content: response.MensajeValidacion
                        })
                    }
                });
            })
        }
    };

    return new HomeLoad();
})();
(function ($, window, document) {
    "use strict";
    $(function () {
        Krispy.Home.initialize();
    });
})(window.jQuery, window, document);
