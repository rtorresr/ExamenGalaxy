using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.BE
{
    public class OpcionRequest
    {
        public string Filtro { get; set; }
        public int NroPag { get; set; }
        public int RegPorPag { get; set; }
        public int NroRegTotal { get; set; }
    }
}
