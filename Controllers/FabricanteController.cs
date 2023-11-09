using Microsoft.AspNetCore.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class FabricanteController : Controller
    {
        private readonly Context _context;
        public FabricanteController(Context context) { _context = context; }
        public IActionResult Index()
        {
            var manager= new FabricanteManager(_context);
            var fabricantes= manager.GetAllFabricantes();
            return View(fabricantes.ToList());
        }
    }
}
