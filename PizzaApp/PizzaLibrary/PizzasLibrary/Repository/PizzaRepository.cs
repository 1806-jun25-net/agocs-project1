using System;
using System.Collections.Generic;
using ContextPizza;
using Microsoft.EntityFrameworkCore;
using PizzaLibrary.Classes;


namespace PizzaLibrary
{
    public class PizzaRepository
    {
        private readonly pizzadatabaseContext _db;


        public PizzaRepository(pizzadatabaseContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public PizzaRepository()
        {
        }

        public int userIDMatch(string fn, string ln)
        {
            var users = _db.User;
            foreach (var user in users)
            {
                if ((user.Firstname.Equals(fn)) && (user.Lastname.Equals(ln)))
                {
                    return user.UserId;
                }
            }
            return -1;
        }

        public void UserAdd(Classes.User u)
        {

            _db.Add(Mapper.Map(u));

        }


        public void AddPizzaOrders(int orderID, int pizzaId)
        {
            /*        public int PizzaId { get; set; }
                      public int OrderId { get; set; }
                      public int PizzaOrderId { get; set; } */

            ContextPizza.PizzaOrder pizzaorderjunction = new ContextPizza.PizzaOrder { OrderId = orderID, PizzaId = pizzaId };
            _db.Add(pizzaorderjunction);
        }

        public void AddOrder(Classes.Order order)
        {
            _db.Add(Mapper.Map(order));
        }


        public List<Classes.Pizza> FindOrderPizzaID(int id)
        {
            List<Classes.Pizza> pl = new List<Classes.Pizza>();
            foreach (var pizzaorder in _db.PizzaOrder)
            {
                if (pizzaorder.OrderId == id)
                {
                    pl.Add(Mapper.Map(_db.Pizza.Find(pizzaorder.PizzaId)));
                }
            }
            return pl;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}

