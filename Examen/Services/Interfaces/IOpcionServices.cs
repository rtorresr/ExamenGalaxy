using Examen.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Services.Interfaces
{
    public interface IOpcionServices
    {
        Task<List<Opcion>> ListarPaginado(ExtraPaginacion ent);
        Opcion Actualizar(Opcion ent);
    }
}
