using System.Text.Json.Serialization;

namespace Tienda.Models
{
    
    public class Compra
    {
        public int CompraID { get; set; }
        public int ProductoID { get; set; }  
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCompra { get; set; }
        
        public Producto Producto { get; set; }
    }
}

