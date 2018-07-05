using System;

namespace PizzaLibrary.Classes
{
    public class StoreLocation : IStoreLocation
    {

        public StoreLocation() { }

        public int Pepperoni { get; set; } = 32;
        public int Ham { get; set; } = 31;
        public int Sausage { get; set; } = 32;
        public int Hotsauce { get; set; } = 32;
        public string Location { get; set; } = "reston";

        public StoreLocation(int pepperoni, int ham, int sausage, int hotsauce, string city, string state)
        {
            this.Pepperoni = pepperoni;
            this.Ham = ham;
            this.Sausage = sausage;
            this.Hotsauce = hotsauce;
            this.Location = city;
        }

        public void DisplayInventory()
        {
            Console.Write("Pepperoni : " + this.Pepperoni +
                          "Ham       : " + this.Ham +
                          "Sausage   : " + this.Sausage +
                          "Hotsauce  : " + this.Hotsauce);
        }

        public bool EmptyInventory(StoreLocation s)
        {
            int[] ingredients = {   this.Pepperoni,
                                    this.Ham,
                                    this.Sausage,
                                    this.Hotsauce };

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Equals(0))
                {
                    switch (i)
                    {
                        case 0:
                            Console.Write("Pepperoni");
                            break;
                        case 1:
                            Console.Write("Ham");
                            break;
                        case 2:
                            Console.Write("Sausage");
                            break;
                        case 3:
                            Console.Write("Hot Sauce");
                            break;
                        default:
                            Console.Write("Unknown '{0}' reference!", ingredients[i]);
                            break;

                    }

                    Console.Write(" is gone at this location! Cannot make that pizza.");
                    return true;
                }

            }

            return false;

        }

        public override string ToString()
        {
            return $"{{{nameof(Pepperoni)}={Pepperoni}, {nameof(Ham)}={Ham}, {nameof(Sausage)}={Sausage}, {nameof(Hotsauce)}={Hotsauce}, {nameof(Location)}={Location}}}";
        }
    }

}
