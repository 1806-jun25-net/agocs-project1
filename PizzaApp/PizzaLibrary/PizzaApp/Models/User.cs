using System;

namespace PizzaLibrary.Classes
{
    public class User
    {

        public User() { }

        public User(string userName, string userLastName, string userCity, DateTime orderTime)
        {
            UserName = userName;
            UserLastName = userLastName;
            UserCity = userCity;
            OrderTime = orderTime;
        }

        public User(string userName, string userLastName)
        {
            UserName = userName;
            UserLastName = userLastName;

        }

        public string UserName { get; set; } = "?";
        public string UserLastName { get; set; } = "?";
        public string UserCity { get; set; } = "reston";
        public DateTime OrderTime { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(UserName)}={UserName}, {nameof(UserLastName)}={UserLastName}, {nameof(UserCity)}={UserCity}, {nameof(OrderTime)}={OrderTime}}}";
        }
    }

   }