using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrispyKreme.Services;
using KrispyKreme.Models;

namespace KrispyKreme.Controllers
{
    public class HomeController : Controller
    {
        #region Atributos        
        private readonly DBKrispy _db;
        #endregion

        #region Constructor
        public HomeController()
        {
            _db = new DBKrispy();
        }
        #endregion

        #region Metodos
        [AllowAnonymous]
        public ActionResult Index()
        {            
            return View();
        }        
        #endregion       
    }
}