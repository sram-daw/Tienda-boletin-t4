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
			if (producto != null)
			{
				return View(producto);
			}
			else {
				TempData["MessageKo"] = "El producto introducido no existe.";
				var productos = manager.GetAllProductos();
				return View("Index",productos); }

		}

		public IActionResult Borrar(int id)
		{
			var manager = new ProductoManager(_context);
			var isBorradoOk = manager.BorrarProductoById(id);
			if (!isBorradoOk)
			{
				TempData["MessageKo"] = "El producto introducido no existe.";
			}
			else
			{
				TempData["MessageOk"] = "Producto eliminado con éxito";

			}
			return RedirectToAction("Index");
		}

		public IActionResult ConsultarPorId()
		{
			return View();
		}

		public IActionResult ModificarByIdForm(int id)
		{
			var manager = new ProductoManager(_context);
			var producto = manager.GetProductoById(id);
			if (producto != null)
			{
				return View(producto);
			}
			else
			{
				TempData["MessageKo"] = "El producto introducido no existe.";
				var productos = manager.GetAllProductos();
				return View("Index", productos);
			}
		}

        public IActionResult ModificarProducto(int id, string nombre, double precio)
        {
            var manager = new ProductoManager(_context);
            var isEditOk = manager.EditProducto(id, nombre, precio);
			if (!isEditOk)
			{
				TempData["MessageKo"] = "No existe un producto con ese ID";
				var productos = manager.GetAllProductos();
				return RedirectToAction("Index",productos);
			}
			else
			{
				TempData["MessageOk"] = "Producto modificado con éxito";
				var producto = manager.GetProductoById(id);
				return View("Detalles",producto); //aquí mejor poner return view en vez de redirectToAction porque si no sale el mensaje de error de la acción "Detalles" porque no obtiene bien el código ya que se está pasando por "id"
			}
			
		}

    }
}
