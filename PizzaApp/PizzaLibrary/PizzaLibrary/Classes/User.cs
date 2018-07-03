using PizzaLibrary.Interfaces;
using System;

namespace PizzaLibrary.Classes
{
    class User : IUser
    {

        //user's complete name
        public string UserFullName { get; set; }
        //user's order location with default order location as 'Reston, VA'
        public string UserLocation { get; set; } = "Reston, VA";

        public void DisplayOrder()
        {
            throw new NotImplementedException();
        }

        public void DisplayPizza()
        {
            throw new NotImplementedException();
        }

        public void DisplayUser()
        {
            throw new NotImplementedException();
        }

        public void OrderValid()
        {
            throw new NotImplementedException();
        }

        public bool PizzaValid()
        {
            throw new NotImplementedException();
        }

        public bool UserValid()
        {
            throw new NotImplementedException();
        }
    }
}