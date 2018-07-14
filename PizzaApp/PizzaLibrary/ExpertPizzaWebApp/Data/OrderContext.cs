using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExpertPizzaWebApp.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext (DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<ExpertPizzaWebApp.Models.Order> Order { get; set; }
    }
}
