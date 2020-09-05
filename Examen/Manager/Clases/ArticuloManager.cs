using Examen.Manager;
using Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Manager
{
    using BE = Examen.Models.BE;
    using DTO = Examen.Models.DTO;
    public class ArticuloManager : IArticuloManager
    {
        private readonly IArticuloServices articuloServices;
        public ArticuloManager(IArticuloServices articuloServices)
        {
            this.articuloServices = articuloServices;
        }
        public List<BE.Articulo> ListAll()
        {
            return (from x in articuloServices.ListAll()
                    select new BE.Articulo()
                    {
                       IdArticulo = x.IdArticulo,
                       //TipoArticulo = x.TipoArticulo.NombreTipoArticulo,
                       NombreArticulo = x.NombreArticulo,
                       Margen = (x.PrecioVenta - x.Costo)
                    }).ToList();
        }
    }
}
