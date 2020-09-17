using Examen.Contexto;
using Examen.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Services
{
    public class TipoArticuloServices : ITipoArticuloServices
    {
        private readonly ExamenContext examenContext;
        private readonly ILogger<TipoArticuloServices> log;
        public TipoArticuloServices(ExamenContext examenContext, ILogger<TipoArticuloServices> log)
        {
            this.examenContext = examenContext;
            this.log = log;
        }
        public List<TipoArticulo> ListAll()
        {
            log.LogInformation("Llego Listall tipo articulo");
            var result = examenContext.TipoArticulo.Include("Articulo").ToList();
            return result;
        }
    }
}
