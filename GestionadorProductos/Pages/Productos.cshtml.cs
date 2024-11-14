
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionadorProductos.Models;
using GestionadorProductos.Service;

namespace GestionadorProductos.Pages
{
    public class ProductosModel : PageModel
    {
        private readonly IProductoService _productoService;

        public ProductosModel(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public List<Productos> ListaProductos { get; set; } = new List<Productos>();
        [BindProperty]
        public Productos NuevoProducto { get; set; } = new Productos();
        [BindProperty]
        public string NombreBusqueda { get; set; }
        [BindProperty]
        public Productos ProductoEditar { get; set; }

        public async Task OnGetAsync()
        {
            ListaProductos = await _productoService.ConsultarProductos();
        }

        public async Task<IActionResult> OnPostBuscarAsync()
        {
            if (!string.IsNullOrEmpty(NombreBusqueda))
            {
                // Llama al servicio para obtener una lista de productos que coincidan con el nombre
                ListaProductos = await _productoService.ConsultarProducto(NombreBusqueda);

                if (ListaProductos == null || ListaProductos.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Producto no encontrado");
                    ListaProductos = await _productoService.ConsultarProductos(); // Recarga todos los productos si no se encuentra el producto buscado
                }
            }
            else
            {
                ListaProductos = await _productoService.ConsultarProductos();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCrearAsync()
        {
            
            var resultado = await _productoService.RegistrarProducto(NuevoProducto);
            if (resultado == "Producto registrado exitosamente")
                return RedirectToPage(); // Recargar
            else
                ModelState.AddModelError(string.Empty, resultado);
            

            ListaProductos = await _productoService.ConsultarProductos();
            return Page();
        }

        public async Task<IActionResult> OnPostModificarAsync()
        {
            var resultado = await _productoService.ModificarProducto(ProductoEditar);
            if (resultado == "Producto modificado exitosamente")
                return RedirectToPage(); // Recargar
            else
                ModelState.AddModelError(string.Empty, resultado);

            ListaProductos = await _productoService.ConsultarProductos();
            return Page();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            await _productoService.EliminarProducto(id);
            return RedirectToPage(); // Recargar
        }
    }
}
