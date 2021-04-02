using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrispyKreme.Services;
using KrispyKreme.Models;

namespace KrispyKreme.Controllers
{
    public class AccountController : Controller
    {

        #region Atributos        
        private readonly DBKrispy _db;
        #endregion

        #region Constructor
        public AccountController()
        {
            _db = new DBKrispy();
        }
        #endregion

        #region Metodos      
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string contrasena)
        {
            Usuario usuario = _db.Login(email, contrasena);
            if (usuario != null)
            {
                Sesion.usuario = usuario;
                return RedirectToAction("Index", "Home");
            }else
            {
                ViewBag.ErrorSesion = RecursosGlobales.ObtenerRecurso("Configuraciones", "MensajeErrorLogin", "Usuario y/o contraseña invalidos.");
                return View("Index");
            }
        }        

        public ActionResult Logout()
        {
            Sesion.destruirSesion();
            return View("Index");
        }
        #endregion
    }
}
