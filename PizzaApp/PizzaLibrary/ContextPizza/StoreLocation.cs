using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class StoreLocation
    {
        public int StoreId { get; set; }
        public int Pepperoni { get; set; }
        public int Sausage { get; set; }
        public int Ham { get; set; }
        public int Hotsauce { get; set; }
        public string City { get; set; }
    }
}
