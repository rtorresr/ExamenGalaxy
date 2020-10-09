using Examen.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.BE
{
    public class OpcionListar
    {
        public int TotalReg { get; set; }
        public List<OpcionBE> ListaOpcion { get; set; }
    }
}
