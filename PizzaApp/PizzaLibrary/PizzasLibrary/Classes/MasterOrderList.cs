using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaLibrary.Classes
{
    public class MasterOrderList
    {
        //test
        public static void AllOrdersInLocation(List<List<Order>> masterlist, string location)
        {
            bool orderLocationFound = false;

            if (masterlist.Count <= 0)
            {
                Console.WriteLine("\nError: empty masterlist.");
                orderLocationFound = false;
            }

            foreach (var superList in masterlist)
            {

                foreach (var subList in superList)
                {

                    if (subList.User.UserCity == location)
                    {

                        Order.OrderString(subList.Pizza, subList.Store, subList.User);
                        orderLocationFound = true;
                    }
                }


            }

            if (!orderLocationFound)
            {
                Console.WriteLine("\nSorry. That location was not found!");
            }
        }


        //test
        public static bool NumberOfOrdersValid(int orders)
        {
            return (orders > 12) ? false : true;
        }


        //test
        public static void AllOrdersInUser(List<List<Order>> masterlist, string[] userInfo)
        {
            bool foundOrder = false;

            if (masterlist.Count <= 0)
            {
                Console.WriteLine("\nError: empty masterlist.");
                foundOrder = false;
            }

            foreach (var listorder in masterlist)
            {

                foreach (var list in listorder)
                {

                    if (list.User.UserName == userInfo[0] && list.User.UserLastName == userInfo[1])
                    {

                        Order.OrderString(list.Pizza, list.Store, list.User);
                        foundOrder = true;

                    }


                }
            }

            if (!foundOrder)
            {
                Console.WriteLine("\nOrder was not found under that username.");
            }
        }

        //test
        public static bool SearchLocation(List<List<Order>> masterlist, string location)
        {
            bool foundlocation = false;


            if (masterlist.Count <= 0)
            {
                Console.WriteLine("Error: empty masterlist.");
                foundlocation = false;
            }


            foreach (var sublist in masterlist)
            {

                for (int i = 0; i < sublist.Count(); i++)
                {
                    foreach (var suborder in sublist)
                    {
                        if (suborder.User.UserCity == location)
                        {
                            foundlocation = true;
                            
                        }
                    }
                }
            }

            if (!foundlocation)
            {
                Console.WriteLine("Sorry, user was not found.\n");
                return foundlocation;
            }

            if (foundlocation)
            {
                Console.WriteLine("Found location " + location);
            }


            return foundlocation;

        }


        //test
        public static bool SearchUser(List<List<Order>> masterlist, string[] userInfo)
        {



            bool founduser = false;

            if (masterlist.Count <= 0)
            {
                Console.WriteLine("Error: empty masterlist.");
                founduser = false;
            }


            foreach (var sublist in masterlist)
            {

                for (int i = 0; i < sublist.Count(); i++)
                {
                    foreach (var suborder in sublist)
                    {
                        if (suborder.User.UserName == userInfo[0])
                        {
                            Console.WriteLine("Found username " + suborder.User.UserName + " " + suborder.User.UserLastName);
                            founduser = true;

                        }
                    }
                }
            }

            if (!founduser)
            {
                Console.WriteLine("Sorry, user was not found.\n");
                return founduser;
            }

            else return founduser;

        }
    }
}

