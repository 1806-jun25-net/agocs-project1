﻿using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class Pizza
    {
        public Pizza()
        {
            Order = new HashSet<Order>();
        }

        public int PizzaId { get; set; }
        public int HasHotsauce { get; set; }
        public int HasHam { get; set; }
        public int HasSausage { get; set; }
        public int HasPepperoni { get; set; }
        public int IngredientCount { get; set; }
        public int PizzaCount { get; set; }
        public double? Price { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
