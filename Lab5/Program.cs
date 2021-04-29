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
            var sumNode = new OperatorNode(OperatorNode.OperationType.Sum, null);
            var multNode = new OperatorNode(OperatorNode.OperationType.Multiplication, null);
            var const12 = new ConstantNode(12, null);
            var const13 = new ConstantNode(13, null);
            var const5 = new ConstantNode(5, null);
            multNode.AddLeftOperand(const13);
            multNode.AddRightOperand(const5);
            sumNode.AddLeftOperand(const12);
            sumNode.AddRightOperand(multNode);
            Console.WriteLine(sumNode.Value);
        }
    }
}