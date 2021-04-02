using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using KrispyKreme.Models;
using KrispyKreme.Services;

namespace KrispyKreme.Controllers
{
    public class CuponesController : Controller
    {
        #region Atributos        
        private readonly DBKrispy _db;
        #endregion

        #region Constructor
        public CuponesController()
        {
            _db = new DBKrispy();
        }
        #endregion

        #region Metodos
        public ActionResult Index(Nullable<bool> InsertoCupon = null)
        {
            ViewBag.insertoCupon = InsertoCupon;
            bool puedeEditar = false;
            bool puedeEliminar = false;
            if (Sesion.usuarioEstaFirmado)
            {
                puedeEliminar = Sesion.usuario.Perfil.PuedeEliminar;
                puedeEditar = Sesion.usuario.Perfil.PuedeEditar;
            }
            ViewBag.puedeEditar = puedeEditar;
            ViewBag.puedeEliminar = puedeEliminar;
            return View();
        }

        [HttpPost]
        public JsonResult LstCupones()
        {
            List<Cupon> lstCupones = _db.LstCupones();                        
            return Json(new { data = lstCupones}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FrmCupon(int IdCupon = 0)
        {
            ViewBag.lstEstatus = _db.LstEstatus();
            ViewBag.lstEstablecimientos = _db.LstEstablecimientos();
            Cupon model;
            if (IdCupon == 0)
            {

                string codigo = _db.GenerarCodigo(RecursosGlobales.ObtenerRecurso("Configuraciones", "InicioFolios", "FC"));
                model = new Cupon();
                model.Codigo = codigo;
                return PartialView("_FormCupon", model);
            }
            else
            {
                model = _db.GetCupon(IdCupon);
                return PartialView("_FormCupon", model);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUpdateCupon(Cupon model)
        {
            bool insertoModificoCupon = false;
            if (ModelState.IsValid)
            {
                if (model.CuponID != 0)
                {
                    insertoModificoCupon = _db.UpdateCupon(model);

                }
                else
                {

                    insertoModificoCupon = _db.AddCupon(model);
                }
            }
            return RedirectToAction("Index", "Cupones", new { InsertoCupon = insertoModificoCupon });
        }

        [HttpPost]
        public JsonResult DeleteCupon(int IdCupon)
        {
            bool eliminoCupon = _db.DeleteCupon(IdCupon);
            return Json(eliminoCupon, JsonRequestBehavior.AllowGet);
        }

        public void ExportarCupones()
        {
            List<Cupon> lstCupones = _db.LstCupones();
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Cupones");

                ws.Cell(1, 1).Value = "Código";
                ws.Cell(1, 2).Value = "Serie";
                ws.Cell(1, 3).Value = "Vigencia";
                ws.Cell(1, 4).Value = "Estatus";
                ws.Cell(1, 5).Value = "Establecimiento";

                ws.Range(ws.Cell(1, 1).Address, ws.Cell(1, 5).Address).Style.Fill.BackgroundColor = XLColor.FromArgb(166, 166, 166);
                ws.Range(ws.Cell(1, 1).Address, ws.Cell(1, 5).Address).Style.Font.FontColor = XLColor.FromArgb(0, 0, 0);
                ws.Range(ws.Cell(1, 1).Address, ws.Cell(1, 5).Address).Style.Font.Bold = true;

                int inicioRegistros = 2;
                foreach (Cupon item in lstCupones)
                {
                    ws.Cell(inicioRegistros, 1).Value = item.Codigo;
                    ws.Cell(inicioRegistros, 2).Value = item.Serie;
                    ws.Cell(inicioRegistros, 3).Value = item.Vigencia.ToShortDateString();
                    ws.Cell(inicioRegistros, 4).Value = item.Estatus.Nombre;
                    ws.Cell(inicioRegistros, 5).Value = item.Establecimiento.Nombre;
                    inicioRegistros++;
                }

                ws.Columns().AdjustToContents();
                Server.ScriptTimeout = 6000;
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "aplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "Cupones.xlsx");

                using(MemoryStream myMemory = new MemoryStream())
                {
                    wb.SaveAs(myMemory);
                    myMemory.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }

            }
        }

        public JsonResult CanjearCupon(int idCupon)
        {
            var validacion = new ServiceReference1.ValidaCupon();
            using (ServiceReference1.Service1Client cliente = new ServiceReference1.Service1Client())
            {
                validacion = cliente.ValidarCupon(idCupon);                
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}