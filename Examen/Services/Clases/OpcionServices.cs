using Examen.Contexto;
using Examen.Models.DTO;
using Examen.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Services.Clases
{
    public class OpcionServices : IOpcionServices
    {
        private readonly ExamenContext examenContext;
        private readonly ILogger<OpcionServices> log;
        public OpcionServices(ExamenContext examenContext, ILogger<OpcionServices> log)
        {
            this.examenContext = examenContext;
            this.log = log;
        }

        public async Task<List<Opcion>> ListarPaginado(ExtraPaginacion ent)
        {
            var query = (from x in examenContext.Opcion select x);

            if (!string.IsNullOrEmpty(ent.Filtro))
            {
                query = query.Where(t => (t.NombreOpcion).Contains(ent.Filtro, StringComparison.InvariantCultureIgnoreCase));
            }

            ent.NroRegTotal = await query.CountAsync();

            query = query.Skip(ent.NroPag * ent.RegPorPag).Take(ent.RegPorPag).OrderByDescending(e => e.IdOpcion).AsNoTracking();
            return await query.ToListAsync();
        }

        public Opcion Actualizar(Opcion ent)
        {
            var entidad = examenContext.Opcion.Find(ent.IdOpcion);
            entidad.NombreOpcion = ent.NombreOpcion;
            entidad.UrlOpcion = ent.UrlOpcion;
            entidad.NombreIcono = ent.NombreIcono;

            examenContext.SaveChanges();
            return ent;
        }

        public Opcion Agregar(Opcion ent)
        {
            examenContext.Opcion.Add(ent);
            examenContext.SaveChanges();
            return ent;
        }

        public Opcion Eliminar(Opcion ent)
        {
            var entidad = examenContext.Opcion.Find(ent.IdOpcion);
            if (entidad != null)
            {
                examenContext.Opcion.Remove(entidad);
                examenContext.SaveChanges();
            }
            
            return entidad;
        }
    }
}
