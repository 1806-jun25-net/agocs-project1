using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpertPizzaWebApp.Models;

namespace ExpertPizzaWebApp.Controllers
{
    public class Orders2Controller : Controller
    {
        private readonly OrderContext _context;

        public Orders2Controller(OrderContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orderContext = _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User);
            return View(await orderContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).FirstOrDefaultAsync(m => m.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult SortByExpensive()
        {
            var orders =  _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).OrderByDescending(o => o.Pizza.Price);
            return View(orders);

        }

        public IActionResult SortByCheapest()
        {
            var orders = _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).OrderBy(o => o.Pizza.Price);
            return View(orders);

        }

        public IActionResult SortByMostRecent()
        {
            var orders = _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).OrderByDescending(o => o.TimeStamp);
            return View(orders);

        }

        public IActionResult Create()
        {
            ViewData["PizzaId"] = new SelectList(_context.Set<Pizza>(), "PizzaId", "PizzaId");
            ViewData["StoreId"] = new SelectList(_context.Set<StoreLocation>(), "StoreId", "StoreId");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("OrderId,PizzaId,StoreId,UserId,TimeStamp")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PizzaId"] = new SelectList(_context.Set<Pizza>(), "PizzaId", "PizzaId", order.PizzaId);
            ViewData["StoreId"] = new SelectList(_context.Set<StoreLocation>(), "StoreId", "StoreId", order.StoreId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", order.UserId);
            return View(order);
        }
    }
}
