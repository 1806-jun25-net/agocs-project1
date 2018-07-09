using System;

namespace PizzaLibrary.Classes
{
    public class StoreLocation
    {

        public StoreLocation() { }

        public StoreLocation(int pepperoni, int ham, int sausage, int hotsauce, string location)
        {
            Pepperoni = pepperoni;
            Ham = ham;
            Sausage = sausage;
            Hotsauce = hotsauce;
            Location = location;
        }

        //At least 32 pizzas per store location can be made
        public int Pepperoni { get; set; } = 32;
        public int Ham { get; set; } = 32;
        public int Sausage { get; set; } = 32;
        public int Hotsauce { get; set; } = 32;
        public string Location { get; set; } = "reston";


        //test done
        public StoreLocation UseInventory(StoreLocation s, Pizza p)
        {
            //if a pizza has an ingredient, "use" that ingredient at target store
            //using discrete units of 'one'
            for (int i = 0; i < p.ingredientCount; i++)
            {
                if (s.Pepperoni > 0 && p.hasPepperoni == 1)
                {
                    s.Pepperoni--;
                }
                if (s.Ham > 0 && p.hasHam == 1)
                {
                    s.Ham--;
                }
                if (s.Hotsauce > 0 && p.hasHotsauce == 1)
                {
                    s.Hotsauce--;
                }
                if (s.Sausage > 0 && p.hasSausage == 1)
                {
                    s.Sausage--;
                }


            }
            return s;
        }

        public void DisplayInventory()
        {
            Console.Write("Pepperoni : " + this.Pepperoni +
                          "Ham       : " + this.Ham +
                          "Sausage   : " + this.Sausage +
                          "Hotsauce  : " + this.Hotsauce);
        }


        //test done
        public bool CheckIfEmptyInventory(StoreLocation s)
        {
            bool hasEmptyIngredient = false;
            
            if (s.Ham <= 0 || s.Pepperoni  <= 0
                || s.Sausage <= 0 || s.Hotsauce <= 0)
            {
                hasEmptyIngredient = true;

            }

            return hasEmptyIngredient;
            
        }

        public override string ToString()
        {
            return $"{{{nameof(Pepperoni)}={Pepperoni}, {nameof(Ham)}={Ham}, {nameof(Sausage)}={Sausage}, {nameof(Hotsauce)}={Hotsauce}}}";
        }
    }

}
