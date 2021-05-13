using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Tree
    {
        private Hashtable _variables;
        public RootNode Root;
        public Tree(string[] input)
        {
            _variables = new Hashtable();
            Root = new RootNode();
            foreach (var str in input)
            {
                StackToTree(Parse(str));
            }
        }

        public static Stack<char> Parse(string task)
        {
            Stack<char> tempStack = new Stack<char>();
            Stack<char> reversedStack = new Stack<char>();
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
            return reversedStack;
        }

        public void StackToTree(Stack<char> stack)
        {   //5 6 - 7 *
            Node cursor = Root;
            while (stack.Count > 0)
            {
                if (IsOperator(stack.Peek()))
                {
                    Node newNode = AddOperator(stack, cursor);
                    cursor.AddChild(newNode);
                    cursor = newNode;
                }
                else if (IsNumber(stack.Peek()))
                {
                    Node newNode = AddNum(stack, cursor);
                    cursor.AddChild(newNode);
                }
                else if (IsVar(stack.Peek()))
                {
                    Node newNode = AddVar(stack, cursor, _variables);
                    cursor.AddChild(newNode);
                }
                while (cursor.IsFull && cursor.Parent != null) cursor = cursor.Parent;
            }
        }
        
        private static VariableNode AddVar(Stack<char> stack, Node node, Hashtable ht) => new VariableNode((stack.Pop()).ToString(), node, ht);

        private static ConstantNode AddNum(Stack<char> stack, Node node) => new ConstantNode(stack.Pop() - '0', node);

        private static OperatorNode AddOperator(Stack<char> stack, Node root)
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

        public void PrintResult()
        {
            foreach (var res in Root.Result())
            {
                Console.WriteLine(res);
            }
        }

        private static bool IsNumber(char a) => a >= '0' && a <= '9';

        private static bool IsVar(char a) => (a >= 'a' && a <= 'z') || (a >= 'A' && a <= 'Z');

        private static bool IsOperator(char a) => a == '+' || a == '-' || a == '*' || a == '/' || a == '=';

        private static int Priority(char a)
        {
            if (IsOperator(a))
            {
                switch (a)
                {
                    case '=':
                        return 0;
                    case '+':
                        return 1;
                    case '-':
                        return 2;
                    case '*':
                        return 3;
                    case '/':
                        return 3;
                    default:
                        return 4;
                }
            }
            else
                throw new Exception();
        }
    }
}
