using AutoMapper;
using Examen.Manager.Interfaces;
using Examen.Models.BE;
using Examen.Models.DTO;
using Examen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Manager.Clases
{
    public class OpcionManager : IOpcionManager
    {
        private readonly IOpcionServices opcionServices;
        private readonly IMapper mapper;

        public OpcionManager(IOpcionServices opcionServices, IMapper mapper)
        {
            this.opcionServices = opcionServices;
            this.mapper = mapper;
        }

        public OpcionBE Actualizar(OpcionBE ent)
        {
            var request = mapper.Map<Opcion>(ent);

            var res = opcionServices.Actualizar(request);

            var result = mapper.Map<OpcionBE>(res);

            return result;
        }

        public OpcionBE Agregar(OpcionBE ent)
        {
            var request = mapper.Map<Opcion>(ent);

            var res = opcionServices.Agregar(request);

            var result = mapper.Map<OpcionBE>(res);

            return result;
        }

        public OpcionBE Eliminar(OpcionBE ent)
        {
            var request = mapper.Map<Opcion>(ent);

            var res = opcionServices.Eliminar(request);

            var result = mapper.Map<OpcionBE>(res);

            return result;
        }

        public async Task<OpcionListar> ListarPaginado(ExtraPaginacion ent)
        {
            List<Opcion> listaOpcion = await opcionServices.ListarPaginado(ent);

            var listaRes = mapper.Map<List<OpcionBE>>(listaOpcion);
            OpcionListar res = new OpcionListar { ListaOpcion = listaRes, TotalReg = ent.NroRegTotal };
            return res;
        }
    }
}
