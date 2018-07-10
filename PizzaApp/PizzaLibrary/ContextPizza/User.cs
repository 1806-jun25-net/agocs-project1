using System;
using System.Collections.Generic;

namespace ContextPizza
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public DateTime Ordertime { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
