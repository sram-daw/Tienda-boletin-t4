using Microsoft.EntityFrameworkCore;

namespace Tienda.Models
{
    public class Context : DbContext

    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Fabricante> fabricante { get; set; } //EL NOMBRE DEL ATRIBUTO DEBE SER IGUAL AL DE LA TABLA
        public DbSet<Producto> producto { get; set; }
    }
}
