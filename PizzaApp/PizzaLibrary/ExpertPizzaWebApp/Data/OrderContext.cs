using Microsoft.EntityFrameworkCore;

namespace ExpertPizzaWebApp.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext (DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
    }
}
