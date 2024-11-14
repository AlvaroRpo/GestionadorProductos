

namespace GestionadorProductos.Service
{
    using GestionadorProductos.Models;
    public interface IProductoService
    {
        Task<List<Productos>> ConsultarProductos();
        Task<List<Productos>> ConsultarProducto(string nombre);
        Task<string> RegistrarProducto(Productos producto);
        Task<string> ModificarProducto(Productos producto);
        Task<string> EliminarProducto(int id);
    }
}
