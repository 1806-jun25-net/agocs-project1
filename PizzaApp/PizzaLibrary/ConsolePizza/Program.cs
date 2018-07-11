using Context = ContextPizza;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaLibrary.Classes;
using System;
using System.Collections.Generic;
using System.IO;


namespace PizzaApp
{
    class ConsolePizza
    {

        private static List<List<Order>> masterList = new List<List<Order>>();
        private static List<Order> currentListOfUserOrders = new List<Order>();

        static void Main(string[] args)
        {

            var configBuilder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<Context.pizzadatabaseContext>(); //DbContext?
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("pizzadatabase"));
            var options = optionsBuilder.Options;

            var dbContext = new Context.pizzadatabaseContext(options);
            var repository = new PizzaLibrary.PizzaRepository(dbContext);

            //get data
            LoadTestData(masterList);
            UIPrompt();
        }

        private static void UIPrompt()
        {

            Console.WriteLine("\nWelcome to the Pizza App!\nWhat would you like to do?\n" +
                              "1. Search users by name.\n" +
                              "2. Display all order history of a location (city name).\n" +
                              "3. Display all order history of username.\n" +
                              "4. Get a suggested order for a username.\n" +
                              "5  Place an order under a username and location.\n" +
                              "6. Display current order.\n");

            UIPromptChoice(Console.ReadLine());
        }

        private static void UIPromptChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    SearchUser(masterList);
                    break;
                case "2":
                    DisplayHistoryFromLocation(masterList);
                    break;
                case "3":
                    DisplayHistoryFromUser(masterList);
                    break;
                case "4":
                    //SuggestedOrder(currentlist);
                    break;
                case "5":
                    if (MasterOrderList.NumberOfOrdersValid(currentListOfUserOrders.Count))
                    {

                        masterList.Add(UsersListOfOrders());

                        foreach (var order in currentListOfUserOrders)
                        {
                            if (!order.pizza.ValidPizzaOrder(order.pizza, currentListOfUserOrders))
                            {
                                Console.WriteLine("\nError, a pizza order for " + order.user.UserName +
                                                   " is too expensive!\n" +
                                                   "Current price: $" +
                                                   order.pizza.CalculatePizzaCost(order.pizza.ingredientCount));
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou've ordered too much pizza. Sorry.");
                    }
                    UIPrompt();
                    break;
                case "6":
                    DisplayCurrentOrder(currentListOfUserOrders);
                    break;
                default:
                    Console.WriteLine("\nUnknown choice. Please try again.");
                    UIPrompt();
                    break;
            }

        }

        private static List<Order> UsersListOfOrders()
        {
            bool ordering = true;
            PizzaLibrary.PizzaRepository db = new PizzaLibrary.PizzaRepository();


            while (ordering)
            {
                Console.WriteLine("\nPlease enter a username and user lastname for this new pizza.");
                string user = Console.ReadLine();
                string[] userinfo = user.Split();

                if (!MasterOrderList.SearchUser(masterList, userinfo))
                {
                    Console.Write("Would you like to add it? y/n\n");
                    string userCreateAnswer = Console.ReadLine();


                    switch (userCreateAnswer)
                    {
                        case "y":
                            Console.WriteLine("\nLogged in as " + userinfo[0] + ".");
                            break;
                        case "n":
                            Console.WriteLine("\nUsername required to complete order.");
                            UsersListOfOrders();
                            break;
                        default:
                            Console.WriteLine("\nError: unknown input. Restarting order process.");
                            UsersListOfOrders();
                            break;
                    }
                }

                else if (userinfo.Length < 2)
                {
                    Console.WriteLine("\nInvalid format.");
                    UsersListOfOrders();
                }

                bool chooseLocation = true;
                string location = "";
                StoreLocation s = new StoreLocation();

                while (chooseLocation)
                {

                    Console.WriteLine("\nPlease enter a location for which this pizza may be ordered.");
                    location = Console.ReadLine();

                    if (!MasterOrderList.SearchLocation(masterList, location))
                    {
                        Console.Write("\nSorry. Invalid location. Please try again.");
                    }

                    else if (s.CheckIfEmptyInventory(s))
                    {
                        Console.Write("\nThat location has an empty ingredient! Please order later.");
                    }

                    else
                    {
                        Console.WriteLine("\n" + location + " has been confirmed.");
                        s.Location = location;
                        User u = new User(userinfo[0], userinfo[1], location, DateTime.Today);
                        db.UserAdd(u);
                        db.Save();
                        chooseLocation = false;
                    }


                }

                return MakePizzas(currentListOfUserOrders, s, new User(userinfo[0], userinfo[1], location, DateTime.Now));

            }

            return currentListOfUserOrders;
        }

        private static List<Order> MakePizzas(List<Order> currentList, StoreLocation s, User u)
        {
            bool makingPizza = true;

            while (makingPizza)

            {
                Console.WriteLine("\nWelcome '{0}'!\nPlease choose your toppings.\n1: Pepperoni\n" +
                                            "2: Ham\n" +
                                            "3: Sausage\n" +
                                            "4: Hotsauce\n", u.UserName);

                string toppingChoices = Console.ReadLine();
                string[] userChoices = toppingChoices.Split();
                Pizza p = new Pizza();

                if (userChoices.Length <= 4)
                {

                    for (int i = 0; i < userChoices.Length; i++)
                    {
                        switch (userChoices[i])
                        {
                            case "1":
                                p.hasPepperoni = 1;
                                break;
                            case "2":
                                p.hasHam = 1;
                                break;
                            case "3":
                                p.hasSausage = 1;
                                break;
                            case "4":
                                p.hasHotsauce = 1;
                                break;
                            default:
                                Console.WriteLine("\nError. Invalid topping choices");
                                break;

                        }
                    }

                    Order o = new Order(u, s, p, DateTime.Now);

                    if (p.ValidPizzaOrder(p, currentList))
                    {
                        s.UseInventory(s, p);
                        Console.WriteLine("\nPizza is now baking. Order appended to current list.");

                        Console.WriteLine("\nWhat would you like to do?\n1. Check current orders.\n2. Order another pizza.\n3. Stop ordering.");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                currentListOfUserOrders.Add(o);
                                foreach (var list in currentListOfUserOrders)
                                {
                                    Order.UserOrderString(p, u);
                                }
                                break;
                            case "2":
                                p.CalculatePizzaCost(p.ingredientCount);
                                currentListOfUserOrders.Add(o);
                                break;
                            case "3":
                                currentListOfUserOrders.Add(o);
                                makingPizza = false;
                                Console.WriteLine("\nSaving information to database..." +
                                    "\nThank you for using Pizza app.");
                                Console.ReadLine();
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("\nUnknown choice.");
                                break;

                        }
                        makingPizza = false;

                    }
                }

                else { Console.WriteLine("Error. Too many topping choices.\n"); }

            }

            return currentList;
        }


        private static void SearchUser(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a username to search.");
            string username = Console.ReadLine();
            string[] answer = username.Split();
            MasterOrderList.SearchUser(masterList, answer);
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadLine();
            UIPrompt();

        }

        private static void DisplayHistoryFromUser(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a username and lastname to return all orders made.");
            string response = Console.ReadLine();
            string[] username = response.Split();
            MasterOrderList.AllOrdersInUser(masterList, username);
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadLine();
            UIPrompt();

        }

        private static void DisplayHistoryFromLocation(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a location to return all orders made.");
            string location = Console.ReadLine();
            MasterOrderList.AllOrdersInLocation(masterList, location);
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadLine();
            UIPrompt();

        }

        private static void DisplayCurrentOrder(List<Order> currentUserOrderList)
        {
            if (currentUserOrderList.Count != 0)
            {
                foreach (var orders in currentUserOrderList)
                {
                    Order.UserOrderString(orders.pizza, orders.user);
                }

            }
            else { Console.WriteLine("\nYou have no current order."); }

            UIPrompt();
            Console.WriteLine("\nPress any key to continue..");

        }

        private void Serialize(List<Order> order)
        {
            //Temporary objects


        }

        private List<Order> Deserialize()
        {
            return null;
        }

        private static List<List<Order>> LoadTestData(List<List<Order>> masterList)
        {
            Pizza p1 = new Pizza(1, 0, 1, 1, 12.20, 3);
            Pizza p2 = new Pizza(1, 1, 1, 1, 50.00, 1);
            Pizza p3 = new Pizza(1, 0, 1, 0, 34.00, 2);
            User u1 = new User("bob", "cray", "herndon", DateTime.Now.AddDays(1));
            User u2 = new User("jay", "day", "dullas", DateTime.Now.AddHours(2));
            User u3 = new User("eric", "io", "reston", DateTime.Now.AddMinutes(90));
            User u4 = new User("carl", "mads", "reston", DateTime.Now.AddMinutes(90));
            User u5 = new User("eric", "ago", "reston", DateTime.Now.AddMinutes(90));

            StoreLocation s1 = new StoreLocation(10, 10, 10, 10, "reston");
            StoreLocation s2 = new StoreLocation(10, 20, 40, 3, "dullas");
            StoreLocation s3 = new StoreLocation(10, 2, 30, 300, "herndon");

            PizzaLibrary.PizzaRepository pizzaRepo = new PizzaLibrary.PizzaRepository();
            pizzaRepo.UserAdd(u1);
            pizzaRepo.Save();
            Order o3 = new Order(u3, s3, p3, DateTime.Now.AddHours(-10));
            Order o4 = new Order(u5, s3, p3, DateTime.Now.AddHours(-10));

            List<Order> userOrders1 = new List<Order>();
            List<Order> userOrders2 = new List<Order>();

            userOrders1.Add(o4);
            userOrders2.Add(o3);
            userOrders1.Add(o4);
            userOrders2.Add(o3);

            masterList.Add(userOrders1);
            masterList.Add(userOrders2);
            return masterList;
        }
    }
}
