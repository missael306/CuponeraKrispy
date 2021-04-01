using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrispyKreme.Models
{
    public static class RecursosGlobales
    {
        public static string ObtenerRecurso(string File, string Key, string Default)
        {
            try
            {
                return HttpContext.GetGlobalResourceObject(File, Key).ToString();
            }
            catch (Exception)
            {

                return Default;
            }
        }
    }
}