using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaApp.Controllers
{
    //not yet implemented route
    [Route("StoreLocation")]
    public class StoreLocationController : Controller
    {
        // GET: StoreLocation
        //not yet implemented route
        [Route("StoreLocation/Index")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: StoreLocation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreLocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreLocation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreLocation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreLocation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreLocation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreLocation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}