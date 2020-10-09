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

        public OpcionManager(IOpcionServices opcionServices)
        {
            this.opcionServices = opcionServices;
        }

        public OpcionBE Actualizar(OpcionBE ent)
        {
            var request = new Opcion()
            {
                IdOpcion = ent.Codigo,
                NombreOpcion = ent.Nombre,
                UrlOpcion = ent.Url,
                NombreIcono = ent.Icono
            };

            var res = opcionServices.Actualizar(request);

            var result = new OpcionBE()
            {
                Codigo = res.IdOpcion,
                Nombre = res.NombreOpcion,
                Url = res.UrlOpcion,
                Icono = res.NombreIcono
            };

            return result;
        }

        public async Task<OpcionListar> ListarPaginado(ExtraPaginacion ent)
        {
            List<Opcion> listaOpcion = await opcionServices.ListarPaginado(ent);

            var listaRes = new List<OpcionBE>();

            foreach (var item in listaOpcion)
            {
                var elem = new OpcionBE()
                {
                    Codigo = item.IdOpcion,
                    Nombre = item.NombreOpcion,
                    Url = item.UrlOpcion,
                    Icono = item.NombreIcono
                };

                listaRes.Add(elem);
            }

            //var listaRes = mapper.Map<List<OpcionBE>>(listaOpcion);
            OpcionListar res = new OpcionListar { ListaOpcion = listaRes, TotalReg = ent.NroRegTotal };
            return res;
        }
    }
}
