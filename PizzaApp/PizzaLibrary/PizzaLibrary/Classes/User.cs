using System;
using System.Collections.Generic;

namespace PizzaLibrary.Classes
{
    public class User
    {

        public User() { }

        public User(string userName, string userState, string userCity, int orderTime)
        {
            UserName = userName;
            UserState = userState;
            UserCity = userCity;
            this.orderTime = orderTime;
        }

        //user's complete name
        public string UserName { get; set; }
        //user's order location with default order location as 'va'
        public string UserState { get; set; } = "va";
        public string UserCity { get; set; } = "reston";
        public int orderTime
        {
            get; set;

        }

        public override string ToString()
        {
            return $"{{{nameof(UserName)}={UserName}, {nameof(UserState)}={UserState}, {nameof(UserCity)}={UserCity}, {nameof(orderTime)}={orderTime + ":00"}}}";
        }
    }
   }