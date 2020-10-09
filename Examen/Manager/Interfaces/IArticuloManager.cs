using Examen.Models.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Manager
{
    public interface IArticuloManager
    {
        List<Articulo> ListAll();
    }
}
