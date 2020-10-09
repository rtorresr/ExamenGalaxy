using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Manager.Interfaces;
using Examen.Models.BE;
using Examen.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcionController : ControllerBase
    {
        private readonly IOpcionManager opcionManager;

        public OpcionController(IOpcionManager opcionManager)
        {
            this.opcionManager = opcionManager;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPag(int NroPag, int RegPorPag, string filtro = "")
        {
            var res = await opcionManager.ListarPaginado(new Models.DTO.ExtraPaginacion { NroPag = NroPag, RegPorPag = RegPorPag, Filtro = filtro });
            return Ok(res);
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] OpcionBE a)
        {
            if (string.IsNullOrEmpty(a.Nombre))
            {
                return BadRequest("Debe enviar el nombre");
            }
            opcionManager.Actualizar(a);
            return Ok(a);

        }
    }
}
