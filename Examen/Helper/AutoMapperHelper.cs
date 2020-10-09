using AutoMapper;
using Examen.Models.BE;
using Examen.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Helper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Opcion, OpcionBE>()
                .ForMember(t => t.Codigo, u => u.MapFrom(src => src.IdOpcion))
                .ForMember(t => t.Nombre, u => u.MapFrom(src => src.NombreOpcion))
                .ForMember(t => t.Url, u => u.MapFrom(src => src.UrlOpcion))
                .ForMember(t => t.Icono, u => u.MapFrom(src => src.NombreIcono));
        }
    }
}
