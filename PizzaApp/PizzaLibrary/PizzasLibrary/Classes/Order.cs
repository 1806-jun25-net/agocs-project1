using PizzaLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaLibrary.Classes
{
    public class Order
    {
        public Order() { }

        public Order(User user, StoreLocation store, Pizza pizza, DateTime timeStamp)
        {
            User = user;
            Store = store;
            Pizza = pizza;
            TimeStamp = timeStamp;
        }

        public Order(User user, StoreLocation store, Pizza pizza)
        {
            User = user;
            Store = store;
            Pizza = pizza;
        }

        /*u, s, p, DateTime.Now);*/

        public int OrderId { get; set; }
        public int StoreId { get; set; }

        internal static void OrderString(Pizza pizza, StoreLocation store, User user)
        {
            throw new NotImplementedException();
        }

        public int PizzaId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }

        public Pizza Pizza { get; set; }
        public StoreLocation Store { get; set; }
        public User User { get; set; }

        public static void UserOrderString(Pizza p, User u)
        {
            throw new NotImplementedException();
        }
    }
}
