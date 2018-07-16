using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpertPizzaWebApp.Models;

namespace ExpertPizzaWebApp.Controllers
{
    public class PizzasController : Controller
    {
        private readonly PizzaContext _context;

        public PizzasController(PizzaContext context)
        {
            _context = context;
        }

        // GET: Pizzas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pizza.ToListAsync());
        }

        // GET: Pizzas/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FirstOrDefaultAsync(m => m.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // GET: Pizzas/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult SortByCheapest()
        {

            var pizza = _context.Pizza.OrderBy(p => p.Price);
            return View(pizza);
        }

        // POST: Pizzas/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Hotsauce, Ham, Sausage, Pepperoni, Ingredient Count, Pizza Count, Pizza Price")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizza.Any(e => e.PizzaId == id);
        }
    }
}
