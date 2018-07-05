using System;
using System.Collections.Generic;

namespace PizzaLibrary.Classes
{
    public class User
    {

        public User() { }

        //user's complete name
        public string UserName { get; set; }
        //user's order location with default order location as 'va'
        public string UserState { get; set; } = "va";
        public string UserCity { get; set; } = "reston";
        

        public User(string userName, string userState, string userCity)
        {
            UserName = userName;
            UserState = userState;
            UserCity = userCity;

        }

        public override string ToString()
        {
            return $"{{{nameof(UserName)}={UserName}, {nameof(UserState)}={UserState}, {nameof(UserCity)}={UserCity}}}";
        }
    }

}