using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaLibrary.Classes;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PizzaApp
{
    class App
    {
        static void Main(string[] args)
        { 
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

            List<List<Order>> masterList = new List<List<Order>>();
            masterList = LoadTestData(masterList);

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
                    SuggestedOrder();
                    break;
                case "5":
                    CreateOrder();
                    break;
                case "6":
                    DisplayCurrentOrder();
                    break;
                default:
                    Console.WriteLine("Unknown choice. Please try again.\n");
                    UIPrompt();
                    break;
            }

        }

        private static void SearchUser(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a username to search.");
            string username = Console.ReadLine();
            MasterList.SearchUser(masterList, username);
            Console.ReadLine();
            UIPrompt();

        }

        private static void SuggestedOrder()
        {

        }

        private static void DisplayHistoryFromUser(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a username to return all orders made.");
            string location = Console.ReadLine();
            MasterList.AllOrdersInUser(masterList, location);

            Console.ReadLine();
            UIPrompt();

        }

        private static void DisplayHistoryFromLocation(List<List<Order>> masterList)
        {
            Console.WriteLine("\nPlease enter a location to return all orders made.");
            string location = Console.ReadLine();
            MasterList.AllOrdersInLocation(masterList, location);

            Console.ReadLine();
            UIPrompt();

        }

        private static void DisplayCurrentOrder()
        {

        }

        private static Order CreateOrder()
        {

            return new Order();
        }

        private void Serialize(List<Order> order)
        {
            //Temporary objects


        }

        private List<Order> Deserialize()
        {


            return new List<Order>();

        }

        private static List<List<Order>> LoadTestData(List<List<Order>> masterList)
        {

            Pizza p1 = new Pizza(true, false, false, false, 12.20);
            Pizza p2 = new Pizza(true, true, false, false, 50.00);
            Pizza p3 = new Pizza(true, false, true, false, 34.00);
            User u1 = new User("bob", "reston", DateTime.Now.AddDays(1));
            User u2 = new User("jay", "dullas", DateTime.Now.AddHours(2));
            User u3 = new User("eric", "dullas", DateTime.Now.AddMinutes(90));
            User u4 = new User("carl", "jupiter", DateTime.Now.AddMinutes(90));


            StoreLocation s = new StoreLocation();
            List<Order> userOrders1 = new List<Order>();
            List<Order> userOrders2 = new List<Order>();
            List<Order> userOrders3 = new List<Order>();

            userOrders1.Add(new Order(u1, s, p3, DateTime.Now));
            userOrders2.Add(new Order(u3, s, p2, DateTime.Now.AddHours(4)));
            userOrders2.Add(new Order(u4, s, p2, DateTime.Now.AddHours(4)));
            userOrders2.Add(new Order(u3, s, p2, DateTime.Now.AddHours(4)));
            userOrders3.Add(new Order(u2, s, p1, DateTime.Now.AddHours(1)));
            userOrders2.Add(new Order(u4, s, p1, DateTime.Now.AddHours(1)));
            userOrders1.Add(new Order(u2, s, p1, DateTime.Now.AddHours(1)));
            userOrders2.Add(new Order(u2, s, p1, DateTime.Now.AddHours(1)));

            masterList.Add(userOrders1);
            masterList.Add(userOrders2);
            masterList.Add(userOrders3);

            return masterList;
        }
    }
}
