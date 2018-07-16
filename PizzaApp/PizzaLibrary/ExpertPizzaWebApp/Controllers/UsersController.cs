using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpertPizzaWebApp.Models;

namespace ExpertPizzaWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersContext _context;

        public UsersController(UsersContext context)
        {
            _context = context;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(_context.User.OrderByDescending(x => x.Ordertime).ToList());
        }

        public ActionResult Search(string fn, string ln, string city, DateTime ordertime)
        {
       
            var user = from u in _context.User select u;

            user = _context.User.Where(u => (u.Firstname == fn) &&
                                            (u.Lastname == ln)  ||
                                            (u.City == city));
           
            return View(user);

        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =  _context.User
                .FirstOrDefault(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("UserId,Firstname,Lastname,City,Ordertime")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Ordertime = DateTime.Now;
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
