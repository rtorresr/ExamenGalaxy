using Examen.Contexto.Configuracion;
using Examen.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Contexto
{
    public class ExamenContext : DbContext
    {
        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Aplicando Configuracion

            modelBuilder.ApplyConfiguration(new TipoArticuloConfiguration());
            modelBuilder.ApplyConfiguration(new ArticuloConfiguration());
            modelBuilder.ApplyConfiguration(new UserAppConfiguration());
            modelBuilder.ApplyConfiguration(new OpcionConfiguration());

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TipoArticulo> TipoArticulo { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<UserApp> UserApp { get; set; }
        public DbSet<Opcion> Opcion { get; set; }
    }
}
