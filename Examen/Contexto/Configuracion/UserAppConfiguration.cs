using Examen.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Contexto.Configuracion
{
    public class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.HasKey("UserId");
            builder.ToTable("UserApp", "EXAMEN");
        }
    }
}
