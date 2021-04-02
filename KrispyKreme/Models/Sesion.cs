using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrispyKreme.Models
{
    public static class Sesion
    {
        #region Atributos
        public static Usuario usuario
        {
            get
            {
                if(HttpContext.Current.Session["usuario"] == null)
                {
                    return null;
                }
                else
                {
                    return (Usuario)HttpContext.Current.Session["usuario"];
                }
            }
            set
            {
                HttpContext.Current.Session["usuario"] = value;
            }
        }

        public static bool usuarioEstaFirmado
        {
            get
            {
                return (HttpContext.Current.Session["usuario"] != null);                
            }            
        }
        #endregion

        #region Metodos
        public static void destruirSesion()
        {
            usuario = null;
        }
        #endregion
    }
}