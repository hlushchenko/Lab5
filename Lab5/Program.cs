using System;
using System.Collections;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable a = new Hashtable();
            VariableNode b = new VariableNode("abc", null, a);
            VariableNode c = new VariableNode("ak", b, a);
            c.Value = 12f;
            Console.WriteLine(c.Value);

        }
    }
}