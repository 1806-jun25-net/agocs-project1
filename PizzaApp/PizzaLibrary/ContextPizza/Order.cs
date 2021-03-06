﻿using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }

        public Pizza Pizza { get; set; }
        public StoreLocation Store { get; set; }
        public User User { get; set; }
    }
}
