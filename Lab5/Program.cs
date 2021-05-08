using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string task = "5*(2+3)";
            Stack<char> poland = Utilities.Parse(task);
            Console.ReadKey();
        }
    }
}