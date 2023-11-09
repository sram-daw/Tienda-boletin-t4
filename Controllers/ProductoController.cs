using Microsoft.AspNetCore.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class ProductoController : Controller
    {
        private readonly Context _context;
        public ProductoController(Context context) { _context = context; }

        public IActionResult Index()
        {
            var manager = new ProductoManager(_context);
            var productos = manager.GetAllProductos();
            return View(productos);
        }

        public IActionResult Detalles(int id)
        {
            var manager = new ProductoManager(_context);
            var producto = manager.GetProductoById(id);
            return View(producto);
        }

        public IActionResult Borrar(int id)
        {
            var manager = new ProductoManager(_context);
            var isBorradoOk = manager.BorrarProductoById(id);
            if (!isBorradoOk)
            {
                TempData["MessageKo"] = "El producto introducido no existe.";
            }
            else {
                TempData["MessageOk"] = "Producto eliminado con éxito";
                
            }
			return RedirectToAction("Index");
		}

        public IActionResult ConsultarPorId()
        {
            return View();
        }
    }
}
