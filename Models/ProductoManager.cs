using Microsoft.EntityFrameworkCore;

namespace Tienda.Models
{
    public class ProductoManager : IDisposable
    {
        private readonly Context _context;
        public ProductoManager(Context context) { _context = context; }


        public IEnumerable<Producto> GetAllProductos()
        {
            var productos = from producto in _context.producto
                            select producto;
            return productos;
        }

        public Producto GetProductoById(int id)
        {
            return (Producto)_context.producto.FirstOrDefault(producto => producto.codigo == id);
        }

        public bool BorrarProductoById(int id)
        {
            bool isBorrarOk = false;
            Producto producto = _context.producto.FirstOrDefault(producto => producto.codigo == id);
            if (producto != null)
            {
                _context.producto.Remove(producto);
                _context.SaveChanges();
                isBorrarOk = true;
            }
            return isBorrarOk;
        }

		public bool EditProducto(int id, string nombre, double precio)
		{
			bool isEditOk = false;
			Producto producto = _context.producto.FirstOrDefault(producto => producto.codigo == id);
			if (producto != null)
			{
				producto.nombre= nombre;
                producto.precio= precio;
				_context.SaveChanges();
				isEditOk = true;
			}
			return isEditOk;
		}

		public void Dispose()
        {
            _context.Dispose();
        }
    }
}
