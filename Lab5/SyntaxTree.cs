using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab5
{
    class SyntaxTree
    {
        private Hashtable _variables;
        public RootNode Root;
        public SyntaxTree()
        {
            _variables = new Hashtable();
            Root = new RootNode();
            
        }

        public void AddFromStringArray(string[] input)
        {
            foreach (var str in input)
            {
                string formatedString = FormatString(str);
                StackToTree(Parse(formatedString));
            }
        }

        public static string FormatString(string task)
        {
            task = task.Replace(" ", "");
            string[] operators = { "+", "-", "*", "/", "=", "(", ")", "?", ":" };
            foreach (var singleOperator in operators)
            {
                task = task.Replace(singleOperator, $" {singleOperator} ");
            }
            while (task.Contains("  ")) task = task.Replace("  ", " ");
            return task;
        }

        public static Stack<string> Parse(string task)
        {
            string[] tokens = task.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> tempStack = new Stack<string>();
            Stack<string> reversedStack = new Stack<string>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "(")
                    tempStack.Push(tokens[i]);
                else if (tokens[i] == ")")
                {
                    while (tempStack.Count > 0 && tempStack.Peek() != "(")
                        reversedStack.Push(tempStack.Pop());
                    tempStack.Pop();
                }
                else if (IsNumber(tokens[i]) || IsVar(tokens[i]))
                    reversedStack.Push(tokens[i]);
                else if (IsOperator(tokens[i]))
                {
                    while (tempStack.Count > 0 && tempStack.Peek() != "(" && Priority(tokens[i]) <= Priority(tempStack.Peek()))
                        reversedStack.Push(tempStack.Pop());
                    tempStack.Push(tokens[i]);
                }
                else if (tempStack.Peek() != "(")
                    reversedStack.Push(tempStack.Pop());
            }
            while (tempStack.Count > 0) reversedStack.Push(tempStack.Pop());
            return reversedStack;
        }

        public void StackToTree(Stack<string> stack)
        {   
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
        
        private static VariableNode AddVar(Stack<string> stack, Node node, Hashtable ht) => new VariableNode(stack.Pop(), node, ht);

        private static ConstantNode AddNum(Stack<string> stack, Node node) => new ConstantNode(Convert.ToDouble(stack.Pop()), node);

        private static OperatorNode AddOperator(Stack<string> stack, Node root)
        {
            switch (stack.Pop()[0])
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
                Console.WriteLine("Result: " + res);
            }
        }

        private static bool IsNumber(string a)
        {
            if (double.TryParse(a, out _)) return true;
            return false;
        }

        private static bool IsLetter(char a) => (a >= 'a' && a <= 'z') || (a >= 'A' && a <= 'Z');

        private static bool IsVar(string a)
        {
            char[] symbols = a.ToCharArray();
            foreach (var symbol in symbols)
            {
                if (!IsLetter(symbol)) return false;
            }
            return true;
        }

        private static bool IsOperator(string a) => a == "+" || a == "-" || a == "*" || a == "/" || a == "=" || a == ":" || a == "?";

        private static int Priority(string a)
        {
            if (IsOperator(a))
            {
                switch (a[0])
                {
                    case '=':
                        return -1;
                    case '?':
                        return 0;
                    case ':':
                        return 1;
                    case '+':
                        return 2;
                    case '-':
                        return 3;
                    case '*':
                        return 4;
                    case '/':
                        return 4;
                    default:
                        return 5;
                }
            }
            return 0;
        }
    }
}
