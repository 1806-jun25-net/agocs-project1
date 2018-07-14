using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExpertPizzaWebApp.Models
{
    public class StoreLocationContext : DbContext
    {
        public StoreLocationContext (DbContextOptions<StoreLocationContext> options)
            : base(options)
        {
        }

        public DbSet<ExpertPizzaWebApp.Models.StoreLocation> StoreLocation { get; set; }
    }
}
