namespace GestionadorProductos.Service
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using GestionadorProductos.Models;
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Productos>> ConsultarProductos()
        {
            var response = await _httpClient.GetAsync("ConsultarProductos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Productos>>();
        }

        public async Task<List<Productos>> ConsultarProducto(string nombre)
        {
            var response = await _httpClient.GetAsync($"ConsultarProducto/{nombre}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Productos>>();
        }
        //public async Task<Productos> ConsultarProducto(string nombre)
        //{
        //    var response = await _httpClient.GetAsync($"ConsultarProducto/{nombre}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadFromJsonAsync<Productos>();
        //    }
        //    return null; // Manejo de errores: Producto no encontrado
        //}

        public async Task<string> RegistrarProducto(Productos producto)
        {
            var response = await _httpClient.PostAsJsonAsync("RegistrarProducto", producto);
            if (response.IsSuccessStatusCode)
            {
                return "Producto registrado exitosamente";
            }
            else
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                return errorMsg.Contains("Ya existe") ? "Ya existe un producto con este nombre" : "Error";
            }
        }

        public async Task<string> ModificarProducto(Productos producto)
        {
            var response = await _httpClient.PostAsJsonAsync("ModificarProducto", producto);
            if (response.IsSuccessStatusCode)
            {
                return "Producto modificado exitosamente";
            }
            else
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                return errorMsg.Contains("Ya existe") ? "Ya existe un producto con este nombre" : "Error";
            }
        }

        public async Task<string> EliminarProducto(int id)
        {
            var response = await _httpClient.GetAsync($"EliminarProducto/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
