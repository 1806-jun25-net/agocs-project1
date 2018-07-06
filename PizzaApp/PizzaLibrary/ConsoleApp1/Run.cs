using System;
using System.Collections.Generic;
using PizzaLibrary.Classes;

namespace PizzaApp
{
    class App
    {

        //Test instantiations
        private static List<List<Order>> masterList = new List<List<Order>>();
        private static List<Order> orderList = new List<Order>();

        static void Main(string[] args)
        {
            //Test
            LoadTestData(masterList);
            UIPrompt();
        }

        private static void UIPrompt()
        { 

            Console.WriteLine("Welcome to the Pizza App!\nWhat would you like to do?\n" +
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
                    SuggestedOrder(orderList);
                    break;
                case "5":
                    if (orderList.Count < 12)
                    {
                        masterList.Add(CreateOrders());

                        foreach (var order in orderList)
                        {
                            if (!order.pizza.ValidPizzaOrder(order.pizza, orderList))
                            {
                                Console.WriteLine("Error, a pizza order for " + order.user.UserName +
                                                   " is too expensive!\n" +
                                                   "Current price: $" +
                                                   order.pizza.CalculatePizzaCost(order.pizza.ingredientCount));
                            }
                        }
                    }
                    else if (orderList.Count > 12)
                    {
                        Console.WriteLine("You've ordered too much pizza. Sorry.");
                    }
                    UIPrompt();
                    break;
                case "6":
                    DisplayCurrentOrder(orderList);
                    break;
                default:
                    Console.WriteLine("Unknown choice. Please try again.\n");
                    UIPrompt();
                    break;
            }

        }

        private static void SuggestedOrder(List<Order> masterList)
        {
            throw new NotImplementedException();
        }

        private static List<Order> CreateOrders()
        { 
            //Test order
            Pizza p3 = new Pizza(1, 0, 1, 0, 34.00, 3);
            User u1 = new User("bob", "reston", DateTime.Now.AddDays(1));
            StoreLocation s = new StoreLocation();
            orderList.Add(new Order(u1, s, p3, DateTime.Now));

            Console.WriteLine("New order created!");
            Order.OrderString(p3, s, u1);
            s.UseInventory(s, p3);
            Console.ReadLine();

            return orderList;
        }

        private static void SearchUser(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a username to search.");
            string username = Console.ReadLine();
            MasterOrderList.SearchUser(masterList, username);

            Console.ReadLine();
            UIPrompt();

        }

        private static void DisplayHistoryFromUser(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a username to return all orders made.");
            string username = Console.ReadLine();
            MasterOrderList.AllOrdersInUser(masterList, username);

            Console.ReadLine();
            UIPrompt();

        }

        private static void DisplayHistoryFromLocation(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a location to return all orders made.");
            string location = Console.ReadLine();
            MasterOrderList.AllOrdersInLocation(masterList, location);

            Console.ReadLine();
            UIPrompt();

        }

        private static void DisplayCurrentOrder(List<Order> currentUserOrderList)
        {
            foreach (var orders in currentUserOrderList)
            {
                Order.UserOrderString(orders.pizza, orders.user);
            }
            Console.ReadLine();
            UIPrompt();
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
            User u1 = new User("bob", "reston", DateTime.Now.AddDays(1));
            User u2 = new User("jay", "dullas", DateTime.Now.AddHours(2));
            User u3 = new User("eric", "dullas", DateTime.Now.AddMinutes(90));
            User u4 = new User("carl", "jupiter", DateTime.Now.AddMinutes(90));


            StoreLocation s = new StoreLocation();
            List<Order> userOrders1 = new List<Order>();
            List<Order> userOrders2 = new List<Order>();

            orderList.Add(new Order(u1, s, p3, DateTime.Now));
            orderList.Add(new Order(u3, s, p2, DateTime.Now.AddHours(4)));
            orderList.Add(new Order(u4, s, p2, DateTime.Now.AddHours(4)));
            orderList.Add(new Order(u3, s, p2, DateTime.Now.AddHours(4)));
            orderList.Add(new Order(u2, s, p1, DateTime.Now.AddHours(1)));
            orderList.Add(new Order(u4, s, p1, DateTime.Now.AddHours(1)));
            orderList.Add(new Order(u2, s, p1, DateTime.Now.AddHours(1)));
            orderList.Add(new Order(u2, s, p1, DateTime.Now.AddHours(1)));

            masterList.Add(orderList);
            return masterList;
        }
    }
}
