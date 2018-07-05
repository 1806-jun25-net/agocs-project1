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
        public DateTime OrderTime { get; set; }

        public Order(User user, StoreLocation loc, Pizza pizza, DateTime order)
        {
            this.user = user;
            this.loc = loc;
            this.pizza = pizza;
            this.OrderTime = order;
        }

        public override string ToString()
        {
            return $"{{{nameof(OrderTime)}={OrderTime}}}" +
               this.user.ToString()   + "\n"
              + this.pizza.ToString() + "\n"
              + this.loc.City         + "\n" 
              + this.loc.State;
        }

        
    }

}
