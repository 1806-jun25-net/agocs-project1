using PizzaLibrary.Interfaces;
using System;

namespace PizzaLibrary.Classes
{
    class Inventory : IInventory
    {
        public void DisplayInventory()
        {
            Console.Write("Current inventory: Pepperoni: {0} " +
                                             "\n Onion: {1}" +
                                             "\n Ham: {2} " +
                                             "\n Cheese: {3} " +
                                             "\n Sauce: {4} " +
                                             "\n Dough: {5} \n", 
                                             pepperoni, onion, ham, cheese, sauce, dough);
        }

        public bool InventoryEmpty()
        {
            throw new NotImplementedException();
        }

        public void DisplayLocation()
        {
            throw new NotImplementedException();
        }

        public void LocationValid()
        {
            throw new NotImplementedException();
        }

        public void DisplayPizza()
        {
            throw new NotImplementedException();
        }

        public bool PizzaValid()
        {
            throw new NotImplementedException();
        }

        private int pepperoni { get; set; } = 500;
        private int onion     { get; set; } = 500;
        private int ham       { get; set; } = 500;
        private int cheese    { get; set; } = 500;
        private int sauce     { get; set; } = 500;
        private int dough     { get; set; } = 500;
    }
}
