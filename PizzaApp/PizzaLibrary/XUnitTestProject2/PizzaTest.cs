using System;
using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using PizzaLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace PizzaUnitTester
{
    public class PizzaTester
    {

        private static readonly Pizza GoodPizza1 = new Pizza(1, 1, 1, 1, 50.00, 1);
        private static readonly Pizza BadPizza1 = new Pizza(1, 0, 1, 1, 512.20, 1);
        private static readonly Pizza BadPizza2 = new Pizza(1, 0, 1, 0, 34.00, 40);
        private static readonly User BadUser1 = new User("bob", "cray", "herndon", DateTime.Now.AddHours(2));
        private static readonly User BadUser2 = new User("jay", "day", "dullas", DateTime.Now.AddHours(-3));
        private static readonly User GoodUser1 = new User("eric", "io", "reston", DateTime.Now);
        private static readonly User GoodUser2 = new User("carl", "mads", "reston", DateTime.Now);
        private static readonly StoreLocation GoodStore1 = new StoreLocation(10, 10, 10, 10, "reston");
        private static readonly StoreLocation BadStore1 = new StoreLocation(0, 20, 40, 3, "herndon");
        private static readonly StoreLocation BadStore2 = new StoreLocation(10, 2, 30, 0, "dullas");
        private static readonly Order BadOrder1 = new Order(BadUser1, BadStore1, BadPizza1, DateTime.Now);
        private static readonly Order GoodOrder2 = new Order(GoodUser1, GoodStore1, GoodPizza1, DateTime.Now);

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        //helper func
        public List<List<Order>> CreateTestMasterList(List<Order> o)
        {
            List<List<Order>> ml = new List<List<Order>>();
            ml.Add(o);

            return ml;
        }

        //helper func
        public List<Order> CreateTestListOrder(Order o)
        {
            List<Order> lo = new List<Order>();
            lo.Add(o);
            return lo;

        }

        //helper func
        public Order CreateTestOrders (User u, StoreLocation s, Pizza p)
        {

            Order o = new Order(u, s, p, DateTime.Now);
            return o;

        }


        [Fact]
        public void AddOrderToDb()
        {
            var configBuilder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ContextPizza.pizzadatabaseContext>(); //DbContext?
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("pizzadatabase"));
            var options = optionsBuilder.Options;
            var dbContext = new ContextPizza.pizzadatabaseContext(options);
            var repository = new PizzaLibrary.PizzaRepository(dbContext);

            string rs1 = RandomString(3);
            string rs2 = RandomString(3);

            User u = new User(rs1, rs2, "reston", DateTime.Now);

            repository.UserAdd(u);
            repository.Save();

            int userID = repository.IDUserMatch(rs1, rs2);

            Order o = new Order(u, GoodStore1, GoodPizza1, DateTime.Now);
            o.UpdateUserId(userID);

            repository.AddOrder(o);
            repository.Save();

        }

        [Fact]
        public void AddUserToDb()
        {
             var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ContextPizza.pizzadatabaseContext>(); //DbContext?
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("pizzadatabase"));
            var options = optionsBuilder.Options;
            var dbContext = new ContextPizza.pizzadatabaseContext(options);
            var repository = new PizzaLibrary.PizzaRepository(dbContext);

            string rs1 = RandomString(3);
            string rs2 = RandomString(3);

            User u = new User(rs1, rs2, "reston", DateTime.Now);

            repository.UserAdd(u);
            repository.Save();
            Assert.Equal(repository.userIDMatch(rs1, rs2), repository.IDUserMatch(rs1, rs2));
            
            
        }

        [Fact]
        public void DBSearchUserByNameAndLastName()
        {
            var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ContextPizza.pizzadatabaseContext>(); //DbContext?
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("pizzadatabase"));
            var options = optionsBuilder.Options;
            var dbContext = new ContextPizza.pizzadatabaseContext(options);
            var repository = new PizzaLibrary.PizzaRepository(dbContext);


            Assert.Equal(1, repository.userIDMatch("taste", "taset"));
            Assert.Equal(-1, repository.userIDMatch("taste", "tast"));


        }

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(12)]
        [InlineData(1)]
        public void NumberOfOrdersValidLessThan12(int orders)
        {

            var result = MasterOrderList.NumberOfOrdersValid(orders);
            Assert.True(result, $"{result} should be valid.");


        }

        [CustomAssertion]
        [Fact]
        public void StoreInventoryDecreaseInventoryOnPizzaCreation() {

            StoreLocation s = new StoreLocation(1, 1, 1, 1, "dullas");
            StoreLocation s2 = new StoreLocation(0, 0, 0, 0, "dullas");
            Pizza p = new Pizza(1, 1, 1, 1, 25.00, 4);
            s.UseInventory(s, p);
            s.Should().BeEquivalentTo(s2);
        }

        [Fact]
        public void StoreInventoryCheckIfAnyIngredientIsZero()
        {
            StoreLocation s = new StoreLocation(0, 1, 1, 1, "reston");
            Assert.True(s.CheckIfEmptyInventory(s));


        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void CalculatePizzaCostTest(int count)
        {
            Pizza p = new Pizza(1, 1, 1, 1, 25.00, count);

            Assert.Equal((25.00) * p.ingredientCount, p.CalculatePizzaCost(p.ingredientCount));

        }

        [Fact]
        public void CheckPizzaValidityShouldReturnTrueIfPizzaValid()
        { 

            List<Order> lo = new List<Order>();
            List<Order> lo2 = new List<Order>();
            List<Order> lo3 = new List<Order>();
            //this orderlist is invalid due to price
            lo.Add(CreateTestOrders(BadUser2, BadStore2, BadPizza1));
            //this orderlist is invalid due to topping amount
            lo2.Add(CreateTestOrders(BadUser2, BadStore2, BadPizza2));
            //this orderlist should be valid
            lo3.Add(CreateTestOrders(GoodUser2, GoodStore1, GoodPizza1));

            Assert.False(BadPizza1.ValidPizzaOrder(BadPizza1, lo));
            Assert.False(BadPizza2.ValidPizzaOrder(BadPizza2, lo2));
            Assert.True(GoodPizza1.ValidPizzaOrder(GoodPizza1, lo3));

        }

        [Fact]
        public void CheckStoryInventoryShouldReturnTrueIfEmpty()
        {
            Assert.True(GoodPizza1.CheckStoreInventory(BadStore1));
            Assert.False(GoodPizza1.CheckStoreInventory(GoodStore1));
        }

        [Fact]
        public void CheckIfOrderValidOnlyIfMadeWithin2Hours()
        {

           Assert.True(Order.OrderValid(GoodOrder2, "reston"));
           Assert.False(Order.OrderValid(BadOrder1, "herndon"));


        }
    }
}
