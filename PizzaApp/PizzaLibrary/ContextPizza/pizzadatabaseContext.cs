using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContextPizza
{
    public partial class pizzadatabaseContext : DbContext
    {
        public pizzadatabaseContext()
        {
        }

        public pizzadatabaseContext(DbContextOptions<pizzadatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<StoreLocation> StoreLocation { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:agocsamerica.database.windows.net,1433;Initial Catalog=pizzadatabase;Persist Security Info=False;User ID=agocs;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.HasHam).HasColumnName("hasHam");

                entity.Property(e => e.HasHotsauce).HasColumnName("hasHotsauce");

                entity.Property(e => e.HasPepperoni).HasColumnName("hasPepperoni");

                entity.Property(e => e.HasSausage).HasColumnName("hasSausage");

                entity.Property(e => e.IngredientCount).HasColumnName("ingredientCount");

                entity.Property(e => e.PizzaCount).HasColumnName("pizzaCount");
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ham).HasColumnName("ham");

                entity.Property(e => e.Hotsauce).HasColumnName("hotsauce");

                entity.Property(e => e.Pepperoni).HasColumnName("pepperoni");

                entity.Property(e => e.Sausage).HasColumnName("sausage");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ordertime)
                    .HasColumnName("ordertime")
                    .HasColumnType("datetime");
            });
        }
    }
}
