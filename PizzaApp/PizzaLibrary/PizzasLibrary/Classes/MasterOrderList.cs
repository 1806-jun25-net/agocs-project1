using PizzaLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

                    if (subList.user.UserCity == location)
                    {

                        Order.OrderString(subList.pizza, subList.loc, subList.user);
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

                    if (list.user.UserName == userInfo[0] && list.user.UserLastName == userInfo[1])
                    {

                        Order.OrderString(list.pizza, list.loc, list.user);
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

                var DistinctLocation = sublist.GroupBy(x => x.user.UserCity).Select(y => y.First());

                for (int i = 0; i < DistinctLocation.Count(); i++)
                {
                    foreach (var suborder in DistinctLocation)
                    {
                        if (suborder.user.UserCity == location)
                        {
                            Console.WriteLine("Found location " + suborder.user.UserCity);
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

            else return foundlocation;

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

                var DistinctFullUserName = sublist.GroupBy(x => x.user.UserLastName).Select(y => y.First());

                for (int i = 0; i < DistinctFullUserName.Count(); i++)
                {
                    foreach (var suborder in DistinctFullUserName)
                    {
                        if (suborder.user.UserName == userInfo[0])
                        {
                            Console.WriteLine("Found username " + suborder.user.UserName + " " + suborder.user.UserLastName);
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

