using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PizzaLibrary.Classes
{
    public class Pizza
    {

        public Pizza() { }

        public Pizza(int hasPepperoni, int hasHam, int hasSausage, int hasHotsauce, double price, int ingredientCount)
        {
            this.hasPepperoni = hasPepperoni;
            this.hasHam = hasHam;
            this.hasSausage = hasSausage;
            this.hasHotsauce = hasHotsauce;
            this.price = price;
            this.ingredientCount = ingredientCount;
        }

        //If hasX = 1, then 'has', else has not
        public int hasPepperoni { get; set; } = 0;
        public int hasHam { get; set; } = 0;
        public int hasSausage { get; set; } = 0;
        public int hasHotsauce { get; set; } = 0;
        public double price { get; set; } = 12.50;
        public int ingredientCount { get; set; } = 0;
        public const int INGREDIENTAMOUNTMAX = 4;

        //test
        public double CalculatePizzaCost (int numIngredients)
        {
            return numIngredients * this.price;

        }

        //test
        public bool ValidPizzaOrder(Pizza p, List<Order> orderlist)
        {
            if (p.ingredientCount > INGREDIENTAMOUNTMAX)
            {
                Console.WriteLine("Error: too many toppings!");
            }

            else if (orderlist.Count <= 0)
            {
                Console.WriteLine("Error: user order list is empty.");
            }

            double price = 0.00;

            foreach (var order in orderlist)
            {
                price += (p.CalculatePizzaCost(p.ingredientCount));
            }

            return (price > 500.00) ? false : true;
        }

        //test
        public Pizza ChangeTopping(Pizza p, StoreLocation s, string topping, int remove)
        {
            switch (topping)
            {
                case "pepperoni":
                    p.hasPepperoni = (remove == 1) ? 0 : 1;
                    
                    break;
                case "sausage":
                    p.hasSausage = (remove == 1) ? 0 : 1;
                    break;
                case "ham":
                    p.hasHam = (remove == 1) ? 0 : 1;
                    break;
                case "hotsauce":
                    p.hasHotsauce = (remove == 1) ? 0 : 1;
                    break;
                default: Console.WriteLine("Error, invalid topping.\n");
                    break;
            }

            //Simulate "using the inventory" from target store.
            s.UseInventory(s, p);
            return p;
        }

        //test
        public bool CheckStoreInventory(StoreLocation s)
        {

            return s.CheckIfEmptyInventory(s);

        }

        public override string ToString()
        {
            return $"{{{nameof(hasPepperoni)}={hasPepperoni}, {nameof(hasHam)}={hasHam}, {nameof(hasSausage)}={hasSausage}, {nameof(hasHotsauce)}={hasHotsauce}, {nameof(ingredientCount)}={ingredientCount}}}" + "\nPizza price: " + CalculatePizzaCost(ingredientCount);
        }
    }
}
