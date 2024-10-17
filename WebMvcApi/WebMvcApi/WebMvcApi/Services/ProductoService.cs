using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebMvcApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebMvcApi.Services
{
    public class ProductoService
    {

        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los productos
        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            var response = await _httpClient.GetAsync("/api/Productos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Producto>>(content);
        }


        // Obtener un producto por ID
        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Productos/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Producto>(content);
        }

       
        // Crear un producto
        public async Task<bool> CrearProductoAsync(Producto producto)
        {
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Productos", content);
            return response.IsSuccessStatusCode;
        }

        // Actualizar un producto
        public async Task<bool> ActualizarProductoAsync(int id, Producto producto)
        {
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Productos/{id}", content);
            return response.IsSuccessStatusCode;
        }

        // Eliminar un producto
        public async Task<bool> EliminarProductoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Productos/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
