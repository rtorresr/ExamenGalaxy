using Examen.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Contexto.Configuracion
{
    public class TipoArticuloConfiguration : IEntityTypeConfiguration<TipoArticulo>
    {
        public void Configure(EntityTypeBuilder<TipoArticulo> builder)
        {
            builder.HasKey("IdTipoArticulo");
            builder.ToTable("TipoArticulo","EXAMEN");
        }
    }
}
