using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KrispyKreme.Models;
using System.Data.Entity;

namespace KrispyKreme.Services
{
    public class DBKrispy
    {
        public Usuario Login(string email, string contrasena)
        {
            Usuario usuario;
            try
            {
                using(var db = new KrispyConext())
                {
                    usuario = db.Usuarios.Where(x => x.Email == email && x.Contrasena == contrasena).FirstOrDefault();                    
                }
            }
            catch (Exception)
            {
                //--Guardar log
                usuario = null;
            }
            return usuario;
        }
    }
}