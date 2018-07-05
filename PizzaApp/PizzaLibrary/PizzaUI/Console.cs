using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaUI
{
    class Console
    {
        public static void Display()
        {

            WriteLine("Welcome!\n\nPlease enter your name and location delimited by whitespace (eg: user location state");
            string Userinformation = ReadLine();
            string[] Userinformation = Split(' ');
             

        }
    }
}
