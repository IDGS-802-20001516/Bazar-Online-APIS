using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tienda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly TiendaDbContext _context;

        public ProductosController(TiendaDbContext context)
        {
            _context = context;
        }




        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Producto>>> SearchProducts(string query)
        {
            var products = await _context.Productos
                .Where(p => p.Titulo.Contains(query) ||
                            p.Descripcion.Contains(query) ||
                            p.Marca.Contains(query)||
                            p.Categoria.Contains(query))
                .ToListAsync();
            return Ok(products);
        }


        

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDetalleDto>> GetProductDetails(int id)
        {
            var productoConImagenes = await _context.ProductoConImagenes
                .Where(p => p.ProductoId == id)
                .ToListAsync();

            if (productoConImagenes == null || productoConImagenes.Count == 0)
                return NotFound();

            var productoDetalle = new ProductoDetalleDto
            {
                ProductoId = productoConImagenes.First().ProductoId,
                Titulo = productoConImagenes.First().Titulo,
                Descripcion = productoConImagenes.First().Descripcion,
                Precio = productoConImagenes.First().Precio,
                PorcentajeDescuento = productoConImagenes.First().PorcentajeDescuento,
                Calificacion = productoConImagenes.First().Calificacion,
                Stock = productoConImagenes.First().Stock,
                Marca = productoConImagenes.First().Marca,
                Categoria = productoConImagenes.First().Categoria,
                Imagenes = productoConImagenes.Select(p => p.ImagenUrl).ToList()
            };

            return Ok(productoDetalle);
        }


    }
}
