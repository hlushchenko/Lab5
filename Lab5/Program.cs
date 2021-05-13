using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable a = new Hashtable();
            OperatorNode sumNode = new OperatorNode(OperatorNode.OperationType.Sum,null);
            ConstantNode const21 = new ConstantNode(2, null);
            ConstantNode const22 = new ConstantNode(2, null);
            sumNode.AddLeftOperand(const21);
            sumNode.AddRightOperand(const22);
            Console.WriteLine(sumNode.Value);
        }
    }
}