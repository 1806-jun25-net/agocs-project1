using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public int HasHotsauce { get; set; }
        public int HasHam { get; set; }
        public int HasSausage { get; set; }
        public int HasPepperoni { get; set; }
        public int IngredientCount { get; set; }
        public int PizzaCount { get; set; }
    }
}
