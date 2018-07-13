
using System;
using System.Collections.Generic;
using System.Linq;
using ContextPizza;

namespace PizzaLibrary.Classes
{
    public static class Mapper
    {

        public static Pizza Map(ContextPizza.Pizza pizza) => new Pizza
        {

            numberOfPizzas = pizza.PizzaCount,
            hasPepperoni = pizza.HasPepperoni,
            hasHam = pizza.HasHam,
            hasHotsauce = pizza.HasHotsauce,
            hasSausage = pizza.HasSausage,
            ingredientCount = pizza.IngredientCount

        };

        public static ContextPizza.Pizza Map(Pizza pizza) => new ContextPizza.Pizza
        {
            PizzaCount = pizza.numberOfPizzas,
            HasPepperoni = pizza.hasPepperoni,
            HasHam = pizza.hasHam,
            HasHotsauce = pizza.hasHotsauce,
            HasSausage = pizza.hasSausage,
            IngredientCount = pizza.ingredientCount

        };


        public static User Map(ContextPizza.User user) => new User
        {
            UserName = user.Firstname,
            UserLastName = user.Lastname,
            UserCity = user.City,
            OrderTime = user.Ordertime

        };

        public static ContextPizza.User Map(User user) => new ContextPizza.User
        {

            Firstname = user.UserName,
            Lastname = user.UserLastName,
            City = user.UserCity,
            Ordertime = user.OrderTime


        };


        public static StoreLocation Map(ContextPizza.StoreLocation store) => new StoreLocation
        {
            Pepperoni = store.Pepperoni,
            Sausage = store.Sausage,
            Ham = store.Ham,
            Hotsauce = store.Hotsauce,
            Location = store.City

        };

        public static ContextPizza.StoreLocation Map(StoreLocation store) => new ContextPizza.StoreLocation
        {
            Pepperoni = store.Pepperoni,
            Sausage = store.Sausage,
            Ham = store.Ham,
            Hotsauce = store.Hotsauce,
            City = store.Location

        };


        public static ContextPizza.Order Map(Order order) => new ContextPizza.Order
        {
            Store = Map(order.Store),
            Pizza = Map(order.Pizza),
            User = Map(order.User),
            TimeStamp = order.TimeStamp

        };


        public static Order Map(ContextPizza.Order order) => new Order
        {

            Store = Map(order.Store),
            Pizza = Map(order.Pizza),
            User = Map(order.User),
            TimeStamp = order.TimeStamp

        };


        public static List<Pizza> Map(IEnumerable<ContextPizza.Pizza> pizzas) => pizzas.Select(Map).ToList();
        public static List<ContextPizza.Pizza> Map(IEnumerable<Pizza> pizzas) => pizzas.Select(Map).ToList();
        public static List<User> Map(IEnumerable<ContextPizza.User> users) => users.Select(Map).ToList();
        public static List<ContextPizza.User> Map(IEnumerable<User> users) => users.Select(Map).ToList();
        public static List<StoreLocation> Map(IEnumerable<ContextPizza.StoreLocation> locations) => locations.Select(Map).ToList();
        public static List<ContextPizza.StoreLocation> Map(IEnumerable<StoreLocation> locations) => locations.Select(Map).ToList();
        public static List<Order> Map(IEnumerable<ContextPizza.Order> orders) => orders.Select(Map).ToList();
        public static List<ContextPizza.Order> Map(IEnumerable<Order> orders) => orders.Select(Map).ToList();


    }
}