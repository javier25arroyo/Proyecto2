using DTOs;
using Microsoft.AspNetCore.Mvc;
using SistemaProveeduriaCORE;

namespace SistemaProveeduriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicitacionController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Licitacion licitacion)
        {
            var licitacionManager = new LicitacionManager();
            licitacionManager.Create(licitacion);
            return Ok();
        }

        [HttpGet]
        [Route("RetrieveById")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var licitacionManager = new LicitacionManager();
            var licitacion = licitacionManager.RetrieveById(id);
            return Ok(licitacion);
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            var licitacionManager = new LicitacionManager();
            List<Licitacion> licitacion = licitacionManager.RetrieveAll();
            return Ok(licitacion);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Licitacion licitacion)
        {
            var licitacionManager = new LicitacionManager();
            licitacionManager.Update(licitacion);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Licitacion licitacion)
        {
            var licitacionManager = new LicitacionManager();
            licitacionManager.Delete(licitacion);
            return Ok();
        }
    }
}
