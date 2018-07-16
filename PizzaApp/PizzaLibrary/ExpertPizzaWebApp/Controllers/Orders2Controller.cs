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

        public ActionResult Index()
        {
            var orderContext = _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User);
            return View(orderContext.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).FirstOrDefault(m => m.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public ActionResult SortByExpensive()
        {
            var orders =  _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).OrderByDescending(o => o.Pizza.Price);
            return View(orders);

        }

        public ActionResult SortByCheapest()
        {
            var orders = _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).OrderBy(o => o.Pizza.Price);
            return View(orders);

        }

        public ActionResult SortByMostRecent()
        {
            var orders = _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).OrderByDescending(o => o.TimeStamp);
            return View(orders);

        }

        public ActionResult Search(string fn, string ln, string city)
        {

            var orders = _context.Order.Include(o => o.Pizza).Include(o => o.Store).Include(o => o.User).Where(o => (o.User.Firstname == fn) &&
                                              (o.User.Lastname == ln) || (o.User.City == city));




            return View(orders);

        }

        public ActionResult Create()
        {
            ViewData["PizzaId"] = new SelectList(_context.Set<Pizza>(), "PizzaId", "PizzaId");
            ViewData["StoreId"] = new SelectList(_context.Set<StoreLocation>(), "StoreId", "StoreId");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("OrderId,PizzaId,StoreId,UserId,TimeStamp")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PizzaId"] = new SelectList(_context.Set<Pizza>(), "PizzaId", "PizzaId", order.PizzaId);
            ViewData["StoreId"] = new SelectList(_context.Set<StoreLocation>(), "StoreId", "StoreId", order.StoreId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", order.UserId);
            return View(order);
        }
    }
}
