using System;
using System.Collections.Generic;

namespace PizzaLibrary.Classes
{
    public class User
    {

        public User() { }

        public User(string userName, string userCity, DateTime orderTime)
        {
            UserName = userName;
            UserCity = userCity;
            OrderTime = orderTime;
        }


        //user's complete name
        public string UserName { get; set; } = "?";
        public string UserCity { get; set; } = "reston";
        public DateTime OrderTime { get; set; } = DateTime.Now;

        public DateTime GetOrderTime()
        {
            return DateTime.Now;

        }

        public override string ToString()
        {
            return $"{{{nameof(UserName)}={UserName}, {nameof(UserCity)}={UserCity}, {nameof(OrderTime)}={OrderTime + ":00"}}}";
        }
    }
   }