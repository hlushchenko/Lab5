using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Utilities
    {
        public static Stack<char> Parse(string task)
        {
            Stack<char> tempStack = new Stack<char>();
            Stack<char> resultStack = new Stack<char>();
            for (int i = 0; i < task.Length; i++)
            {
                if (IsNumber(task[i])) resultStack.Push(task[i]);
                else if ()
            }
            return null;
        }

        private static bool IsNumber(char a) => a >= '0' && a <= '9';

        private static bool IsOperator(char a) => a == '+' || a == '-' || a == '*' || a == '/';
    }
}
