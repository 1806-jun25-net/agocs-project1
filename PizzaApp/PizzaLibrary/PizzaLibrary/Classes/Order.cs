using PizzaLibrary;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaLibrary.Classes
{
    public class Order
    {
        public Order() { }

        public User user;
        public StoreLocation loc;
        public Pizza pizza;

        public Order(User user, StoreLocation loc, Pizza pizza, DateTime order)
        {
            this.user = user;
            this.loc = loc;
            this.pizza = pizza;

        }

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

        //test done
        public static bool OrderValid(Order o, string orderLocationToBeMade)
        {
            bool ValidOrder = true;

            TimeSpan span = DateTime.Now.Subtract(o.user.OrderTime);

            if ((span.Hours) < 2 && o.user.UserCity == orderLocationToBeMade)
            {
                Console.Write("\nSorry. You've made a complete order in the last two hours. At this location.\n" +
                    "Please wait and try again!");
                ValidOrder = false;
            }


            return ValidOrder;
        }
    }
}
