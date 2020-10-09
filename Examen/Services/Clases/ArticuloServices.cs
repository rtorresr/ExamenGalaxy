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
    public class ArticuloServices : IArticuloServices
    {
        private readonly ExamenContext examenContext;
        private readonly ILogger<ArticuloServices> log;
        public ArticuloServices(ExamenContext examenContext, ILogger<ArticuloServices> log)
        {
            this.examenContext = examenContext;
            this.log = log;
        }

        public List<Articulo> ListAll()
        {
            log.LogInformation("Llego Listall Articulo");
            return examenContext.Articulo.Include("TipoArticulo").ToList();
        }
    }
}
