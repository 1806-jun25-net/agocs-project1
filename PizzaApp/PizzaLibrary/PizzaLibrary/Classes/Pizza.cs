using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PizzaLibrary.Classes
{
    public class Pizza
    {

        public Pizza() { }

        public Pizza(int hasPepperoni, int hasHam, int hasSausage, int hasHotsauce, double basePrice, int ingredientCount)
        {
            this.hasPepperoni = hasPepperoni;
            this.hasHam = hasHam;
            this.hasSausage = hasSausage;
            this.hasHotsauce = hasHotsauce;
            this.price = basePrice;
            this.ingredientCount = ingredientCount;
        }

        public int hasPepperoni { get; set; } = 1;
        public int hasHam { get; set; } = 1;
        public int hasSausage { get; set; } = 1;
        public int hasHotsauce { get; set; } = 1;
        public double price { get; set; } = 12.50;
        public int ingredientCount { get; set; } = 0;
        public const int INGREDIENTAMOUNTMAX = 4;

        //test
        public string CalculatePizzaCost (int numIngredients)
        {
            return string.Format("{0:#.00}", Convert.ToDecimal(this.ingredientCount * this.price));

        }

        //test
        public bool ValidPizzaOrder(Pizza p, List<Order> orderlist, int ingredientAmount)
        {
            double price = 0.00;

            foreach (var order in orderlist)
            {
                price += (order.pizza.price + ingredientAmount);
            }

            if(ingredientAmount > INGREDIENTAMOUNTMAX)
            {
                Console.WriteLine("Error: too many toppings!");
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
            }
            return p;
        }

        //test
        public bool CheckStoreInventory(StoreLocation s)
        {

            return s.EmptyInventory(s);

        }

        public override string ToString()
        {
            return $"{{{nameof(hasPepperoni)}={hasPepperoni}, {nameof(hasHam)}={hasHam}, {nameof(hasSausage)}={hasSausage}, {nameof(hasHotsauce)}={hasHotsauce}, {nameof(ingredientCount)}={ingredientCount}}}" + "\nPizza price: " + CalculatePizzaCost(ingredientCount);
        }
    }
}
