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

        public static RootNode StackToTree(Stack<char> stack)
        {   //5 6 - 7 *


            //2 2 2 * +
            RootNode root = new RootNode();
            Node cursor = root;
            while (stack.Count > 0)
            {
                if (IsOperator(stack.Peek()))
                {
                    Node newNode = AddOperator(stack, root);
                    cursor.AddChild(newNode);
                    cursor = newNode;
                }
                else if (IsNumber(stack.Peek()))
                {
                    Node newNode = AddNum(stack, root);
                    cursor.AddChild(newNode);
                }
                while (cursor.IsFull && cursor.Parent != null) cursor = cursor.Parent;
            }
            return root;
        }

        private static ConstantNode AddNum(Stack<char> stack, Node node) => new ConstantNode(stack.Pop() - '0', node);

        private static OperatorNode AddOperator(Stack<char> stack, RootNode root)
        {
            switch (stack.Pop())
            {
                case '+':
                    return new OperatorNode(OperatorNode.OperationType.Sum, root);
                case '-':
                    return new OperatorNode(OperatorNode.OperationType.Subtraction, root);
                case '*':
                    return new OperatorNode(OperatorNode.OperationType.Multiplication, root);
                case '/':
                    return new OperatorNode(OperatorNode.OperationType.Division, root);
                default:
                    return new OperatorNode(OperatorNode.OperationType.Assign, root);
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
