using System;

namespace PizzaLibrary.Classes
{
    public class Pizza
    {

        public Pizza() { }

        public Pizza(bool inventoryavailableForPizza, bool hasPepperoni, bool hasHam, bool hasSausage, bool hasHotsauce)
        {
            this.hasPepperoni = hasPepperoni;
            this.hasHam = hasHam;
            this.hasSausage = hasSausage;
            this.hasHotsauce = hasHotsauce;
        }

        public bool hasPepperoni { get; set; } = false;
        public bool hasHam { get; set; } = false;
        public bool hasSausage { get; set; } = false;
        public bool hasHotsauce { get; set; } = false;


        public bool CheckStoreInventory(StoreLocation s)
        {

            return s.EmptyInventory(s);

        }

        public override string ToString()
        {
            return $"{{{nameof(hasPepperoni)}={hasPepperoni}, {nameof(hasHam)}={hasHam}, {nameof(hasSausage)}={hasSausage}, {nameof(hasHotsauce)}={hasHotsauce}}}";
        }

    }
}
