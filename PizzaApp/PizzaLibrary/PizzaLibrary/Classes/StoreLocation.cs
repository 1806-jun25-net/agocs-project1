using PizzaLibrary.Interface;
using System;

namespace PizzaLibrary.Classes
{
    class StoreLocation : IStoreLocation
    {
        private int pepperoni { get; set; } = 500;
        private int onion { get; set; } = 500;
        private int ham { get; set; } = 500;
        private int cheese { get; set; } = 500;
        private int sauce { get; set; } = 500;
        private int dough { get; set; } = 500;

        //Displays
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

        public void DisplayLocation()
        {
            throw new NotImplementedException();
        }

        public void DisplayOrder()
        {
            throw new NotImplementedException();
        }

        public void DisplayPizza()
        {
            throw new NotImplementedException();
        }

        //inventory is available for creating pizza
        public bool InventoryValid()
        {
            throw new NotImplementedException();
        }

        //location exists check
        public void LocationValid()
        {
            throw new NotImplementedException();
        }

        //The order has all prerequesites 
        public void OrderValid()
        {
            throw new NotImplementedException();
        }

        //The pizza has ingredient(s) that are out of stock or not an option
        public bool PizzaValid()
        {
            throw new NotImplementedException();
        }

        //The store location does not map to anything [in xml]
        bool IStoreLocation.LocationValid()
        {
            throw new NotImplementedException();

        }
    }
}
