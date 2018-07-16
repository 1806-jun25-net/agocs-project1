using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index()
        {
            return View(_context.StoreLocation.ToList());
        }

        // GET: StoreLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeLocation = _context.StoreLocation
                .FirstOrDefault(m => m.StoreId == id);
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
