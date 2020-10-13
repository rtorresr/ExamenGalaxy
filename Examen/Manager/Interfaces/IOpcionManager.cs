using Examen.Models.BE;
using Examen.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Manager.Interfaces
{
    public interface IOpcionManager
    {
        Task<OpcionListar> ListarPaginado(ExtraPaginacion ent);
        OpcionBE Actualizar (OpcionBE ent);
        OpcionBE Agregar(OpcionBE ent);
        OpcionBE Eliminar(OpcionBE ent);
    }
}
