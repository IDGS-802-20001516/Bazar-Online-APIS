using Microsoft.EntityFrameworkCore;

namespace Tienda.Models
{
    public class TiendaDbContext : DbContext
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Compra> Compras { get; set; } 
      
        public DbSet<ProductoConImagenes> ProductoConImagenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoConImagenes>()
                .HasNoKey()
                .ToView("vw_ProductoConImagenes");
        }
    }
}