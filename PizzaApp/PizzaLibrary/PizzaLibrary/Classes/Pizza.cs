using System;
using System.Xml.Serialization;

namespace PizzaLibrary.Classes
{
    public class Pizza : IPizza
    {

        public Pizza() { }

        public Pizza(bool hasPepperoni, bool hasHam, bool hasSausage, bool hasHotsauce, double price)
        {
            this.hasPepperoni = hasPepperoni;
            this.hasHam = hasHam;
            this.hasSausage = hasSausage;
            this.hasHotsauce = hasHotsauce;
            this.price = price;
        }

        public bool hasPepperoni { get; set; } = false;
        public bool hasHam { get; set; } = false;
        public bool hasSausage { get; set; } = false;
        public bool hasHotsauce { get; set; } = false;
        public double price { get; set; } = 12.50;

        public string CalculatePizzaCost (int numIngredients)
        {
            return string.Format("{0:#.00}", Convert.ToDecimal(numIngredients * numIngredients));

        }

        public bool ValidPizza(Pizza p)
        {
            return (p.price > 500.00) ? false : true;
        }

        public Pizza ChangeTopping(Pizza p, StoreLocation s, string topping, bool remove)
        {
            switch (topping)
            {
                case "pepperoni":
                    p.hasPepperoni = (remove) ? true : false;
                    break;
                case "sausage":
                    p.hasSausage = (remove) ? true : false;
                    break;
                case "ham":
                    p.hasHam = (remove) ? true : false;
                    break;
                case "hotsauce":
                    p.hasHotsauce = (remove) ? true : false;
                    break;
            }
            return p;
        }

        public bool CheckStoreInventory(StoreLocation s)
        {

            return s.EmptyInventory(s);

        }

        public override string ToString()
        {
            return $"{{{nameof(hasPepperoni)}={hasPepperoni}, {nameof(hasHam)}={hasHam}, {nameof(hasSausage)}={hasSausage}, {nameof(hasHotsauce)}={hasHotsauce}, {nameof(price)}={price}}}";
        }
    }
}
