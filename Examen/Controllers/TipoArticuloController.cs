using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Manager;
using Examen.Services;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoArticuloController : ControllerBase
    {
        private readonly ITipoArticuloManager tipoArticuloManager;
        public TipoArticuloController(ITipoArticuloManager tipoArticuloManager)
        {
            this.tipoArticuloManager = tipoArticuloManager;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(tipoArticuloManager.ListAll());
        }
    }
}
