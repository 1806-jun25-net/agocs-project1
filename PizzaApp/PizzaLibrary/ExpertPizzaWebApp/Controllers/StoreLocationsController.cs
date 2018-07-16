using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpertPizzaWebApp.Models;

namespace ExpertPizzaWebApp.Controllers
{
    public class StoreLocationsController : Controller
    {
        private readonly StoreLocationContext _context;

        public StoreLocationsController(StoreLocationContext context)
        {
            _context = context;
        }

        // GET: StoreLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoreLocation.ToListAsync());
        }

        // GET: StoreLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocation = await _context.StoreLocation
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (storeLocation == null)
            {
                return NotFound();
            }

            return View(storeLocation);
        }

        private bool StoreLocationExists(int id)
        {
            return _context.StoreLocation.Any(e => e.StoreId == id);
        }
    }
}
