using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Manager.Interfaces;
using Examen.Models.BE;
using Examen.Models.DTO;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("PublicApi")]
        public async Task<IActionResult> ListarPag(int NroPag, int RegPorPag, string filtro = "")
        {
            var res = await opcionManager.ListarPaginado(new Models.DTO.ExtraPaginacion { NroPag = NroPag, RegPorPag = RegPorPag, Filtro = filtro });
            return Ok(res);
        }

        [HttpPut]
        [EnableCors("PublicApi")]
        public IActionResult Actualizar([FromBody] OpcionBE a)
        {
            if (string.IsNullOrEmpty(a.Nombre))
            {
                return BadRequest("Debe enviar el nombre");
            }
            opcionManager.Actualizar(a);
            return Ok(a);
        }

        [HttpPost]
        [EnableCors("PublicApi")]
        public IActionResult Agregar([FromBody] OpcionBE a)
        {
            if (string.IsNullOrEmpty(a.Nombre))
            {
                return BadRequest("Debe enviar el nombre");
            }
            opcionManager.Agregar(a);
            return Ok(a);
        }

        [HttpDelete]
        [EnableCors("PublicApi")]
        public IActionResult Eliminar(int id)
        {          
            var result = opcionManager.Eliminar(new OpcionBE() { Codigo = id});
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No existe opcion");
        }
    }
}
