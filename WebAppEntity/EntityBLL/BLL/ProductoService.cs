using EntityModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDAL.DAL.Repositories.Contratos;
using EntityDTO.DTO;

namespace EntityBLL.BLL
{
    public class ProductoService:IProductoService
    {
        
        private readonly IProductoRepository _productoRepository;

        // Constructor que inyecta el repositorio
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // Implementación para obtener todos los productos
        public async Task<IEnumerable<ProductoDto>> ObtenerTodosLosProductosAsync()
        {
            return await _productoRepository.GetAllProductosAsync();
        }

        // Implementación para obtener un producto por ID
        public async Task<ProductoDto> ObtenerProductoPorIdAsync(int id)
        {
            return await _productoRepository.GetProductoByIdAsync(id);
        }

        // Implementación para agregar un nuevo producto
        public async Task AgregarProductoAsync(ProductoDto producto)
        {
            // Lógica de negocio (ejemplo: validación)
            if (producto.Precio < 0)
            {
                throw new Exception("El precio no puede ser negativo.");
            }
            await _productoRepository.AddProductoAsync(producto);
        }

        // Implementación para actualizar un producto
        public async Task ActualizarProductoAsync(ProductoDto producto)
        {
            if (producto.Precio < 0)
            {
                throw new Exception("El precio no puede ser negativo.");
            }
            await _productoRepository.UpdateProductoAsync(producto);
        }

        // Implementación para eliminar un producto
        public async Task EliminarProductoAsync(int id)
        {
            await _productoRepository.DeleteProductoAsync(id);
        }
    }
}
