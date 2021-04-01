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
        #endregion
        public KrispyConext()
            : base("name=Krispy")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>().HasRequired(x => x.Perfil);

        }

    }
    
}