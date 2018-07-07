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

        //test
        public static bool OrderValid(DateTime userOrdertime)
        {
            bool ValidOrder = true;

            DateTime now = DateTime.Now;
            DateTime twoHours = now.AddHours(-2);
            if (userOrdertime > twoHours && userOrdertime <= now)
            {
                Console.Write("\nSorry. You've made a complete order in the last two hours.\n" +
                    "Please wait and try again!");
            }

            return ValidOrder;
        }
    }
}
