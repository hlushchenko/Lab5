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
                if (task[i] == '(')
                    tempStack.Push(task[i]);
                else if (task[i] == ')')
                {
                    while (tempStack.Peek() != '(')
                        resultStack.Push(tempStack.Pop());
                    tempStack.Pop();
                }
                if (IsNumber(task[i])) 
                    resultStack.Push(task[i]);
                else if (IsOperator(task[i]))
                {
                    while(tempStack.Count > 0 && tempStack.Peek() != '(' && Priority(task[i]) <= Priority(tempStack.Peek())) 
                        resultStack.Push(tempStack.Pop());
                    tempStack.Push(task[i]);
                }
                else if(tempStack.Peek() != '(')
                    resultStack.Push(tempStack.Pop());
            }
            while (tempStack.Count > 0) resultStack.Push(tempStack.Pop());
            return resultStack;
        }

        private static bool IsNumber(char a) => a >= '0' && a <= '9';

        private static bool IsOperator(char a) => a == '+' || a == '-' || a == '*' || a == '/';

        private static int Priority(char a)
        {
            if (IsOperator(a))
            {
                switch (a)
                {
                    case '+':
                        return 1;
                    case '-':
                        return 1;
                    case '*':
                        return 2;
                    case '/':
                        return 2;
                    default:
                        return 3;
                }
            }
            else
                throw new Exception();
        }
    }
}
