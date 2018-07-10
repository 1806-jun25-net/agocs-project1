using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int PizzaId { get; set; }
        public bool HasHotsauce { get; set; }
        public bool HasHam { get; set; }
        public bool HasSausage { get; set; }
        public bool HasPepperoni { get; set; }
        public int IngredientCount { get; set; }

        public ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
