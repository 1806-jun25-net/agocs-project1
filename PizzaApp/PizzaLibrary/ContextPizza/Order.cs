using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class Order
    {
        public Order()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }

        public StoreLocation Store { get; set; }
        public User User { get; set; }
        public ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
