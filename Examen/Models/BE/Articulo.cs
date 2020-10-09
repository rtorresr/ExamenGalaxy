using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.BE
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string TipoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public decimal Margen { get; set; }
    }
}
