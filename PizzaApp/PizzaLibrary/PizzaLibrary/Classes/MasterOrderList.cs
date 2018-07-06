using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Classes
{
    public class MasterOrderList
    {
        //test
        public static void AllOrdersInLocation(List<List<Order>> masterlist, string location)
        {

            if (masterlist.Count <= 0)
            {
                Console.WriteLine("Error: empty masterlist.");
            }

            foreach (var superList in masterlist)
            {

                foreach(var subList in superList)
                {

                    if (subList.user.UserCity == location)
                    {

                        Order.OrderString(subList.pizza, subList.loc, subList.user);

                    }
                }

               
            }
        }

        //test
        public static void AllOrdersInUser(List<List<Order>> masterlist, string user)
        {
            bool foundOrder = false;

            if (masterlist.Count <= 0)
            {
                Console.WriteLine("Error: empty masterlist.");
            }

            foreach (var listorder in masterlist)
            {

                foreach (var list in listorder)
                {

                    if (list.user.UserName == user)
                    {

                        Order.OrderString(list.pizza, list.loc, list.user);
                        foundOrder = true;

                    }


                }
            }

            if (!foundOrder)
            {
                Console.WriteLine("Order was not found under that username.");
            }
        }

        //test
        public static void SearchUser(List<List<Order>> masterlist, string user)
        {
            bool founduser = false;

            if (masterlist.Count <= 0)
            {
                Console.WriteLine("Error: empty masterlist.");
            }

            foreach (var sublist in masterlist)
            {

                for (int i = 0; i < sublist.Count; i++)
                {
                    foreach (var suborder in sublist)
                    {
                        if (user == suborder.user.UserName)
                        {
                            founduser = true;
                        }
                    }
                }
            }

            if(!founduser)
            {
                Console.WriteLine("Sorry, user was not found.\n");
            }

            else Console.WriteLine("User found.\n");

        }
    }
}
