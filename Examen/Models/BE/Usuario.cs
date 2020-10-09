using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.BE
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Credencial { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
    }
}
