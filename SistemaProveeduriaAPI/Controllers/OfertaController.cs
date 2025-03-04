using DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaProveeduriaCORE;

namespace SistemaProveeduriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Oferta oferta)
        {
            var ofertaManager = new OfertaManager();
            ofertaManager.Create(oferta);
            return Ok();
        }

        [HttpGet]
        [Route("RetrieveById")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var ofertaManager = new OfertaManager();
            var oferta = ofertaManager.RetrieveById(id);
            return Ok(oferta);
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            var ofertaManager = new OfertaManager();
            List<Oferta> ofertas = ofertaManager.RetrieveAll();
            return Ok(ofertas);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Oferta oferta)
        {
            var ofertaManager = new OfertaManager();
            ofertaManager.Update(oferta);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Oferta oferta)
        {
            var ofertaManager = new OfertaManager();
            ofertaManager.Delete(oferta);
            return Ok();
        }
    }
}
