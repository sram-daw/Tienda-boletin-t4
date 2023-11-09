namespace Tienda.Models
{
    public class FabricanteManager : IDisposable
    {

        private readonly Context _context;
        public FabricanteManager(Context context) { _context = context; }


        public IEnumerable<Fabricante> GetAllFabricantes()
        {
            var fabricantes= from fabricante in _context.fabricante
                             select fabricante;
            return fabricantes;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
