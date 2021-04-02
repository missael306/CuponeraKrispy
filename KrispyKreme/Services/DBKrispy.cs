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

        #region Catalogos 

        public string GenerarCodigo(string inicioFolio)
        {
            int totalFolios = 0;
            try
            {
                using (var db = new KrispyConext())
                {
                    totalFolios = db.Cupones.Count();
                }
            }
            catch (Exception)
            {
                //--Guardar log
                totalFolios = 0;
            }
            return inicioFolio = inicioFolio + totalFolios;
        }

        public List<Estatus> LstEstatus()
        {
            List<Estatus> lstEstatus;
            try
            {
                using (var db = new KrispyConext())
                {
                    lstEstatus = db.Estatus.ToList();
                }
            }
            catch (Exception)
            {
                //--Guardar log
                lstEstatus = new List<Estatus>();
            }
            return lstEstatus;
        }

        public List<Establecimiento> LstEstablecimientos()
        {
            List<Establecimiento> lstEstablecimientos;
            try
            {
                using (var db = new KrispyConext())
                {
                    lstEstablecimientos = db.Establecimientos.ToList();
                }
            }
            catch (Exception)
            {
                //--Guardar log
                lstEstablecimientos = new List<Establecimiento>();
            }
            return lstEstablecimientos;
        }
        #endregion

        #region Account
        public Usuario Login(string email, string contrasena)
        {
            Usuario usuario;
            try
            {
                using (var db = new KrispyConext())
                {
                    usuario = db.Usuarios.Where(x => x.Email == email && x.Contrasena == contrasena).Include(x => x.Perfil).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //--Guardar log
                usuario = null;
            }
            return usuario;
        }        
        #endregion

        #region Cupones
        public List<Cupon> LstCupones()
        {
            List<Cupon> lstCupones;
            try
            {
                using (var db = new KrispyConext())
                {
                    lstCupones = db.Cupones.Include(x => x.Establecimiento).Include(x => x.Estatus).ToList();
                }
            }
            catch (Exception)
            {
                //--Guardar log
                lstCupones = new List<Cupon>();
            }
            return lstCupones;
        }

        public bool UpdateCupon(Cupon model)
        {
            bool res = false;
            try
            {
                using (var db = new KrispyConext())
                {
                    Cupon modificar = db.Cupones.Where(x => x.CuponID == model.CuponID).FirstOrDefault();
                    if (modificar != null)
                    {
                        modificar.Serie = model.Serie;
                        modificar.EstatusID = model.EstatusID;
                        modificar.EstablecimientoID = model.EstablecimientoID;
                        modificar.Vigencia = model.Vigencia;
                        res = (db.SaveChanges() > 0);
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            catch (Exception ex)
            {
                res = false;
                //log
            }
            return res;
        }

        public bool AddCupon(Cupon model)
        {
            bool res = false;
            try
            {
                using (var db = new KrispyConext())
                {

                    db.Cupones.Add(model);
                    res = (db.SaveChanges() > 0);
                }
            }
            catch (Exception ex)
            {
                res = false;
                //log
            }
            return res;
        }

        public Cupon GetCupon(int idCupon)
        {
            Cupon res;
            try
            {
                using (var db = new KrispyConext())
                {
                    res = db.Cupones.Where(x => x.CuponID == idCupon).FirstOrDefault();
                    if (res == null)
                        res = new Cupon();
                }
            }
            catch (Exception)
            {
                res = new Cupon();
                //log
            }
            return res;
        }

        public bool DeleteCupon(int idCupon)
        {
            bool res = false;
            try
            {
                using (var db = new KrispyConext())
                {

                    Cupon eliminar = db.Cupones.Where(x => x.CuponID == idCupon).FirstOrDefault();
                    if (eliminar != null)
                    {
                        db.Cupones.Remove(eliminar);
                        res = (db.SaveChanges() > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                res = false;
                //log
            }
            return res;
        }
        #endregion
    }
}