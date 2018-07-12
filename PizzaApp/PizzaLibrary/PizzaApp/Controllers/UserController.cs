﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library = PizzaLibrary.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Context = ContextPizza;

namespace PizzaApp.Controllers
{
    public class UserController : Controller
    {
        private readonly Context.pizzadatabaseContext _context;


        public UserController(Context.pizzadatabaseContext context)
        {
            _context = context;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_context.User.ToList());

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            ContextPizza.User user = new ContextPizza.User();

            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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