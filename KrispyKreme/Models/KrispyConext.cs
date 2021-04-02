using System;
using System.Data.Entity;
using System.Linq;
using KrispyKreme.Models;

namespace KrispyKreme
{
    public class KrispyConext : DbContext
    {

        #region Atributos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Cupon> Cupones { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<Establecimiento> Establecimientos { get; set; }
        #endregion
        public KrispyConext()
            : base("name=Krispy")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Usuario>().HasRequired(x => x.Perfil);

            builder.Entity<Cupon>().HasRequired(x => x.Establecimiento);
            builder.Entity<Cupon>().HasRequired(x => x.Estatus);            
        }

    }
    
}