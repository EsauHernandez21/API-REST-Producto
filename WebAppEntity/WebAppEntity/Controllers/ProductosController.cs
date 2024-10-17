using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityBLL.BLL;
using EntityModel.Model;
using EntityDTO.DTO;

namespace WebAppEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        //La BLL llama a la capa DAL para acceder a los datos necesarios
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoDto>> GetProductos()
        {
            return await _productoService.ObtenerTodosLosProductosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult> PostProducto(ProductoDto producto)
        {
            await _productoService.AgregarProductoAsync(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoId }, producto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id, ProductoDto producto)
        {
            if (id != producto.ProductoId)
            {
                return BadRequest();
            }

            await _productoService.ActualizarProductoAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            await _productoService.EliminarProductoAsync(id);
            return NoContent();
        }
    }
}
