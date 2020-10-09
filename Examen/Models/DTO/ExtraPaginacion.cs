using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.DTO
{
    public class ExtraPaginacion
    {
        public string Filtro { get; set; }
        public int NroPag { get; set; }
        public int RegPorPag { get; set; }
        public int NroRegTotal { get; set; }
    }
}
