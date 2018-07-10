using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            Order = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public int Pepperoni { get; set; }
        public int Sausage { get; set; }
        public int Ham { get; set; }
        public int Hotsauce { get; set; }
        public string City { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
