using System;

namespace PizzaLibrary.Classes
{
    public interface IUser
    {
        DateTime OrderTime { get; set; }
        string UserCity { get; set; }
        string UserName { get; set; }

        DateTime GetOrderTime();
        string ToString();
    }
}