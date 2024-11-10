namespace Tienda.Models
{
    public class ProductoConImagenes
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public decimal Calificacion { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string  ImagenUrl { get; set; }
    }
}
