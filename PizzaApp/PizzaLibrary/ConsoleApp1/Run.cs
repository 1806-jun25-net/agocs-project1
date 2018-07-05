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

            //@DOHERE unserialize dictionary

            //temp empty dict
            Dictionary<string, List<Order>> orderDictionary = new Dictionary<string, List<Order>>();

            //Temporary objects
            Pizza p = new Pizza(true, false, false, false, false);
            User u = new User("bob", "reston", "md");
            StoreLocation s = new StoreLocation();
            List<Order> orderList = new List<Order>();
            orderList.Add(new Order(u, s, p, DateTime.Now));
            orderList.Add(new Order(u, s, p, DateTime.Now.AddHours(4)));

            //Temporary dict entries
            orderDictionary.Add("bob", orderList);
            orderDictionary.Add("reston", orderList);

            Console.WriteLine("Welcome to the Pizza App! Enter a username or location if it already exists for history!");
            string username = Console.ReadLine();

            foreach (var superList in orderDictionary)
            {
                if (superList.Key == username)
                {

                    foreach (var subList in superList.Value)
                    {
                        Console.WriteLine("Order history for " + superList.Key + "\n"
                                                              + subList.pizza.ToString() + "\n"
                                                              + subList.user.ToString() + "\n");
                    }

                }
            }

            LoadData(orderDictionary, p, u, orderList);

        }

        private static string LoadData(Dictionary<string, List<Order>> orderDictionary, Pizza p, User u, List<Order> orderList)

        {

            bool ordering = true;
            string username = "Unset";

            while (ordering)
            {

                    Console.WriteLine("Welcome to the Pizza App, press any key to continue.");


                    orderList.Add(createOrderList(orderDictionary));

                    Console.WriteLine("Do you want to order again? y/n");
                    var response = Console.ReadLine();

                    switch ((string)response)
                    {

                        case "y":
                            ordering = true;
                            break;
                        case "n":
                            Console.WriteLine("Thank you for using the pizza app!");
                            ordering = false;
                            break;
                        default: ordering = false;
                            break;
                    }




                
            }

            return username;
        }

        public static Order createOrderList(Dictionary<string, List<Order>> dict)
        {

            User user = new User();
            Order o = new Order();
            StoreLocation loc = new StoreLocation();
            Pizza pizza = new Pizza();


                Console.WriteLine("Please enter username and location in format 'username location state'");
                string userNameLocationState = Console.ReadLine();
                string[] userNameLocationStateArr = userNameLocationState.Split();
                bool createUserFlag = true;

                foreach (var list in dict)
                {

                if (userNameLocationStateArr[0] == list.Key)
                {
                    createUserFlag = false;
                    user.UserName = list.Key;
                }

                else createUserFlag = true;

                }

                if (userNameLocationStateArr.Length < 3)
                {

                    Console.WriteLine("Unknown '{0}'. Use 'username location state'\n\n", userNameLocationStateArr[0]);
                }

                while (createUserFlag)
                {

                    //@DOHERE provide 'n' functionality
                    Console.WriteLine("Welcome {0}!\nUser not found. Would you like to proceed with creating an account under {0}? 'y/n'", userNameLocationStateArr[0]);

                    switch (Console.ReadLine())
                    {
                        case "y":

                            Console.WriteLine(userNameLocationStateArr[0] + "'s account has been created.");
                            user.UserName = userNameLocationStateArr[0];
                            createUserFlag = false;
                            //Record userNameLocationStateArr
                            break;
                        case "n":

                            Console.Write("Please enter a suitable username now: ");
                            user.UserName = Console.ReadLine();
                            Console.WriteLine(user.UserName + " account created!");
                            createUserFlag = false;
                            break;
                        default:
                            Console.Write("Unknown '{0}'. Use y/n.", Console.ReadLine());
                            break;
                    }


                

                bool createPizzaFlag = true;
                Console.WriteLine("Welcome '{0}'!\nPlease choose your toppings.\n1: Pepperoni\n" +
                                                                "2: Ham\n" +
                                                                "3: Sausage\n" +
                                                                "4: Hotsauce\n", userNameLocationStateArr[0]);

                string toppingChoices = Console.ReadLine();
                string[] userChoices = toppingChoices.Split();

                while (createPizzaFlag)
                {
                    if (!loc.EmptyInventory(loc))
                    {
                        for (int i = 0; i < userChoices.Length; i++)
                        {
                            switch (userChoices[i])
                            {
                                case "1":
                                    loc.Pepperoni -= 1;
                                    pizza.hasPepperoni = true;
                                    break;
                                case "2":
                                    loc.Ham -= 1;
                                    pizza.hasHam = true;
                                    break;
                                case "3":
                                    loc.Sausage -= 1;
                                    pizza.hasSausage = true;
                                    break;
                                case "4":
                                    loc.Hotsauce -= 1;
                                    pizza.hasHotsauce = true;
                                    break;

                            }

                            createPizzaFlag = false;
                        }
                    }

                }

                try
                {
                    user.UserCity = userNameLocationStateArr[1];
                    user.UserState = userNameLocationStateArr[2];

                }

                catch
                {

                    Console.WriteLine("Bad ingredient choice!");


                }

            }

            Order order = new Order(user, loc, pizza, DateTime.Now);

            Console.WriteLine("New order created!\n" +
                              "Details: \n" +
                              order.user.ToString() +
                              order.pizza.ToString() + "\nTime created: " +
                              DateTime.Now + "\n");

            return order;

        }

        public class item
        {
            [XmlAttribute]
            public string key;
            [XmlAttribute]
            public List<Order> listOrders;
        }


    }



}
