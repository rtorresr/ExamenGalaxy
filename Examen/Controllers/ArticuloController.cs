using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : Controller
    {
        private readonly IArticuloManager articuloManager;
        public ArticuloController(IArticuloManager articuloManager)
        {
            this.articuloManager = articuloManager;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(articuloManager.ListAll());
        }
    }
}
