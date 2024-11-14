using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionadorProductosBack.Models;
using GestionadorProductosBack.Service;
namespace GestionadorProductosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService _service;
        public ProductosController(ProductosService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("ConsultarProductos")]
        public async Task<ActionResult<List<Productos>>> ConsultarProductos()
        {
            return Ok(await _service.ConsultarProductos());
        }

        [HttpGet]
        [Route("ConsultarProducto/{Nombre}")]
        public async Task<ActionResult<Productos>> ConsultarProducto(string Nombre)
        {
            return Ok(await _service.ConsultarProducto(Nombre));
        }
        //[HttpGet]
        //[Route("ConsultarProducto/{Nombre}")]
        //public async Task<ActionResult<Productos>> ConsultarProducto(string Nombre)
        //{
        //    var producto = await _service.ConsultarProducto(Nombre);

        //    if(producto == null)
        //        return NotFound("No se encontró el producto");
        //    else
        //        return Ok(producto);
        //}

        [HttpPost]
        [Route("RegistrarProducto")]
        public async Task<ActionResult<Productos>> RegistrarProducto(Productos objProducto)
        {
            var respuesta = await _service.RegistrarProducto(objProducto);

            if (respuesta == 1)
                return Ok("Producto registrado exitosamente");
            else if (respuesta == 2)
                return BadRequest("Ya existe un producto con este nombre");
            else
                return BadRequest("Error");
        }

        [HttpPost]
        [Route("ModificarProducto")]
        public async Task<ActionResult<Productos>> ModificarProducto(Productos objProducto)
        {
            var respuesta = await _service.ModificarProducto(objProducto);

            if (respuesta == 1)
                return Ok("Producto modificado exitosamente");
            else if (respuesta == 2)
                return BadRequest("Ya existe un producto con este nombre");
            else
                return BadRequest("Error");
        }

        [HttpGet]
        [Route("EliminarProducto/{Id}")]
        public async Task<ActionResult<List<Productos>>> EliminarProducto(int Id)
        {
            return Ok(await _service.EliminarProducto(Id));
        }
    }
}
