using Examen.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Contexto.Configuracion
{
    public class OpcionConfiguration : IEntityTypeConfiguration<Opcion>
    {
        public void Configure(EntityTypeBuilder<Opcion> builder)
        {
            builder.HasKey("IdOpcion");
            builder.ToTable("Opcion", "EXAMEN");
        }
    }
}
