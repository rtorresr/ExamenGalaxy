using Examen.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Contexto.Configuracion
{
    public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.HasKey("IdArticulo");
            builder.ToTable("Articulo", "EXAMEN");

            builder.HasOne<TipoArticulo>(t => t.TipoArticulo).WithMany(a => a.Articulo).HasForeignKey(i => i.IdTipoArticulo);
        }
    }
}
