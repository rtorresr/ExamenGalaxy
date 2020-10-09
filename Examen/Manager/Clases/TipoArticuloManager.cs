using Examen.Models.DTO;
using Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Manager
{
    public class TipoArticuloManager : ITipoArticuloManager
    {
        private readonly ITipoArticuloServices tipoArticuloServices;
        public TipoArticuloManager(ITipoArticuloServices tipoArticuloServices)
        {
            this.tipoArticuloServices = tipoArticuloServices;
        }
        public List<TipoArticulo> ListAll()
        {
            var resultado = tipoArticuloServices.ListAll();
            return resultado;
        }
    }
}
