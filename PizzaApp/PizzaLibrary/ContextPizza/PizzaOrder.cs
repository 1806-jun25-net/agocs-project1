using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class PizzaOrder
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public int PizzaOrderId { get; set; }

        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
    }
}
