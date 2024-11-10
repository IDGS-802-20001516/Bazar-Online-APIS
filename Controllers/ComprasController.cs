using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Tienda.Models;

namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly TiendaDbContext _context;

        public ComprasController(TiendaDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            return await _context.Compras.Include(c => c.Producto).ToListAsync();
        }

        

        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(CompraDto compraRequest)
        {
            
            var producto = await _context.Productos.FindAsync(compraRequest.ProductoID);

            if (producto == null)
            {
                return NotFound("Producto no encontrado.");
            }

            
            var compra = new Compra
            {
                ProductoID = compraRequest.ProductoID,
                FechaCompra = compraRequest.FechaCompra,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion
            };

            
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompra", new { id = compra.CompraID }, compra);
        }


       
    }
}
