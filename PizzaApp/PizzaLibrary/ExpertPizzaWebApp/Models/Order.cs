using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertPizzaWebApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public Pizza Pizza { get; set; }
        public StoreLocation Store { get; set; }
        public User User { get; set; }
    }
}
