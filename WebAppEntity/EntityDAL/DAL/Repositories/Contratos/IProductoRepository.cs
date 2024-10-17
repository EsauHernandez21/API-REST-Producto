using EntityModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDTO.DTO;

namespace EntityDAL.DAL.Repositories.Contratos
{
    public interface IProductoRepository
    {
        Task<ProductoDto> GetProductoByIdAsync(int id);
        Task<IEnumerable<ProductoDto>> GetAllProductosAsync();
        Task AddProductoAsync(ProductoDto producto);
        Task UpdateProductoAsync(ProductoDto producto);
        Task DeleteProductoAsync(int id);
    }
}
