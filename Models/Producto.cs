using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tienda.Models
{
    public class Producto
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public double precio { get; set;}
        [ForeignKey("Fabricante")]
        [Column("codigo_fabricante")]
        public int codigo_fabricante { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}
