using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrispyKreme.Models;
using KrispyKreme.Controllers;

namespace KrispyKreme.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        
        #region Metodos
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);
                Usuario usuario = Sesion.usuario;
                if(usuario == null)
                {
                    if(filterContext.Controller is AccountController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Account/Index");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Account/Index");
            }
        }
        #endregion
    }
}