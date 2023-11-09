using System.ComponentModel.DataAnnotations;

namespace Tienda.Models
{
    public class Fabricante
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }

    }
}
