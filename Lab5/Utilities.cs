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
            Stack<char> reversedStack = new Stack<char>();
            Stack<char> resultStack = new Stack<char>();
            for (int i = 0; i < task.Length; i++)
            {
                if (task[i] == '(')
                    tempStack.Push(task[i]);
                else if (task[i] == ')')
                {
                    while (tempStack.Count > 0 && tempStack.Peek() != '(')
                        reversedStack.Push(tempStack.Pop());
                    tempStack.Pop();
                }
                else if (IsNumber(task[i]) || IsVar(task[i]))
                    reversedStack.Push(task[i]);
                else if (IsOperator(task[i]))
                {
                    while (tempStack.Count > 0 && tempStack.Peek() != '(' && Priority(task[i]) <= Priority(tempStack.Peek()))
                        reversedStack.Push(tempStack.Pop());
                    tempStack.Push(task[i]);
                }
                else if(tempStack.Peek() != '(')
                    reversedStack.Push(tempStack.Pop());
            }
            while (tempStack.Count > 0) reversedStack.Push(tempStack.Pop());
            //while (reversedStack.Count > 0) resultStack.Push(reversedStack.Pop());
            return reversedStack;
        }

        public static OperatorNode StackToTree(Stack<char> stack)
        {   //5 6 - 7 *
            OperatorNode on = null;
            while (stack.Count > 0)
            {
                if (IsOperator(stack.Peek()))
                {
                    on = AddOperator(stack);
                }     
            }
            return on;
        }

        private static void AddNum(OperatorNode on, Stack<char> stack)
        {

        }

        private static OperatorNode AddOperator(Stack<char> stack)
        {
            switch (stack.Pop())
            {
                case '+':
                    return new OperatorNode(OperatorNode.OperationType.Sum);
                case '-':
                    return new OperatorNode(OperatorNode.OperationType.Subtraction);
                case '*':
                    return new OperatorNode(OperatorNode.OperationType.Multiplication);
                case '/':
                    return new OperatorNode(OperatorNode.OperationType.Division);
                default:
                    return new OperatorNode(OperatorNode.OperationType.Assign);
            }
        }

        private static bool IsNumber(char a) => a >= '0' && a <= '9';

        private static bool IsVar(char a) => (a >= 'a' && a <= 'z') || (a >= 'A' && a <= 'Z');

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
