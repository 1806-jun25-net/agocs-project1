﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertPizzaWebApp.Models
{
    public class StoreLocation
    {
        public int StoreId { get; set; }
        public int Pepperoni { get; set; }
        public int Sausage { get; set; }
        public int Ham { get; set; }
        public int Hotsauce { get; set; }
        public string City { get; set; }
    }
}
