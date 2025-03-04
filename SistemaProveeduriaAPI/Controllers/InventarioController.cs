using DTOs.ProyectoDTOs;
using Microsoft.AspNetCore.Mvc;
using SistemaProveeduriaCORE;

namespace SistemaProveeduriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : Controller
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Inventario inventory)
        {
            var um = new InventarioManager();

            //um.Create(inventory);

            return Ok();
        }
        [HttpGet]
        [Route("RetrieveById")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var um = new InventarioManager();

            var inventorySelected = um.RetrieveById(id);

            return Ok(inventorySelected);
        }
        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            var um = new InventarioManager();

            List<Inventario> inventoryList = um.RetrieveAll();

            return Ok(inventoryList);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Inventario inventory)
        {
            var um = new InventarioManager();

            um.Update(inventory);

            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Inventario inventory)
        {
            var um = new InventarioManager();

            um.Delete(inventory);

            return Ok();
        }
    }
}
