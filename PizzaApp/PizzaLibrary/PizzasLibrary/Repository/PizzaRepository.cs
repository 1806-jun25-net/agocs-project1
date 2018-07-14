using ContextPizza;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using P = PizzaLibrary.Classes;

namespace pizzalibrary
{
    public class pizzarepository
    {
        private readonly pizzadatabaseContext _db;


        public pizzarepository(pizzadatabaseContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public pizzarepository()
        {

        }

        public string Findnamewithid(int userid)
        {
            var users = _db.User;
            foreach (var user in users)
            {
                if (user.UserId == userid)
                {
                    return user.Firstname + user.Lastname;
                }
            }
            return "user not found";

        }

        public int Findidwithname(string firstname, string lastname)
        {
            var users = _db.User;
            foreach (var user2 in users)
            {
                if (firstname == user2.Firstname &&
                     lastname == user2.Lastname)
                {
                    return user2.UserId;
                }
            }
            return -1;
        }

        public int Findidwithstore(P.StoreLocation store1)
        {
            var stores = _db.StoreLocation;
            foreach (var store2 in stores)
            {
                if (store1.Ham == store2.Ham &&
                    store1.Hotsauce == store2.Hotsauce &&
                    store1.Pepperoni == store2.Pepperoni &&
                    store1.Sausage == store2.Sausage)
                {
                    return store2.StoreId;
                }
            }
            return -1;
        }


        public List<P.Order> GetAllOrders()
        {
            var orders = P.Mapper.Map(_db.Order.Include(a => a.Pizza).Include
                                                       (b => b.Store).Include
                                                       (c => c.User));
            return orders;

        }

        public void Useradd(P.User user)
        {

            _db.Add(P.Mapper.Map(user));

        }

        public void Userremove(string fn, string ln)
        {

            var users = _db.User;

            foreach (var user in users)
            {
                if (fn == user.Firstname &&
                    ln == user.Lastname)
                {
                    _db.Remove(user);
                }
            }

        }


        public Order FindOrderWithIDs(int storenum, int pizzanum, int usernum)
        {
            var orders = _db.Order;

            foreach (var order in orders)
            {
                if (storenum == order.StoreId && 
                    pizzanum == order.PizzaId &&
                    usernum  == order.UserId)
                {
                    //User user, StoreLocation store, Pizza pizza
                }
            }

            return null;
        }

        public void FindOrderWithObjects(StoreLocation s, User u, Pizza p)
        {
            var orders = _db.Order;

            foreach (var order in orders)
            {
                {
                    _db.Order.Remove(order);
                }
            }

        }

        public void Addorder(P.Order order)
        {
            _db.Add(P.Mapper.Map(order));
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}

