using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        private int pepperoni { get; set; } = 500;
        private int onion     { get; set; } = 500;
        private int ham       { get; set; } = 500;
        private int cheese    { get; set; } = 500;
        private int sauce     { get; set; } = 500;
        private int dough     { get; set; } = 500;
    }
}
