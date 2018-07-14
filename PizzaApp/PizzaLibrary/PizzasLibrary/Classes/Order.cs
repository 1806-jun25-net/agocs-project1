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
        public int PizzaId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }

        public Pizza Pizza { get; set; }
        public StoreLocation Store { get; set; }
        public User User { get; set; }




        public static void OrderString(Pizza p, StoreLocation l, User u)
        {
            Console.WriteLine("Pizza ordered: " + p.ToString() + "\n" +
                              "Location info: " + l.ToString() + "\n" +
                              "User info    : " + u.ToString() + "\n");

        }

        public static void UserOrderString(Pizza p, User u)
        {
            Console.WriteLine("Pizza ordered: " + p.ToString() + "\n" +
                              "User info    : " + u.ToString() + "\n");

        }

        //test 
        public static bool OrderValid(Order o, string orderLocationToBeMade)
        {
            bool ValidOrder = true;

            TimeSpan span = DateTime.Now.Subtract(o.User.OrderTime);

            if ((span.Hours) < 2 && o.User.UserCity == orderLocationToBeMade)
            {
                Console.Write("\nSorry. You've made a complete order in the last two hours. At this location.\n" +
                    "Please wait and try again!");
                ValidOrder = false;
            }


            return ValidOrder;
        }
    }
}
