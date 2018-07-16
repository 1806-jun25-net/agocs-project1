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
            return View(await _context.Pizza.OrderByDescending(x => x.PizzaId).ToListAsync());
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

        public IActionResult Create()
        {
            return View();
        }

        public ActionResult SortByCheapest()
        {

            var pizza = _context.Pizza.OrderBy(p => p.Price);
            return View(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("HasHotsauce, hasHam, hasSausage, HasPepperoni, PizzaCount")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                pizza.IngredientCount = pizza.HasPepperoni +
                                        pizza.HasSausage +
                                        pizza.HasHotsauce +
                                        pizza.HasHam;
                pizza.Price = 12.50 + (pizza.IngredientCount * pizza.PizzaCount);
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
