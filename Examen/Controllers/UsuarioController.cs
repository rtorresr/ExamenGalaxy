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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioManager usuarioManager;
        public UsuarioController(IUsuarioManager usuarioManager)
        {
            this.usuarioManager = usuarioManager;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuarioManager.ListAll());
        }
    }
}
