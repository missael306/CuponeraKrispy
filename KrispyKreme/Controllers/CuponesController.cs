using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        #endregion
    }
}