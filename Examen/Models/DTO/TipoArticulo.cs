using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.DTO
{
    public class TipoArticulo
    {
        public int IdTipoArticulo { get; set; }
        public string NombreTipoArticulo { get; set; }

        public virtual List<Articulo> Articulo { get; set; }
    }
}
