using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Hashtable a = new Hashtable();
            var sumNode = new OperatorNode(OperatorNode.OperationType.Sum, null);
            var multNode = new OperatorNode(OperatorNode.OperationType.Multiplication, null);
            var assignNode = new OperatorNode(OperatorNode.OperationType.Assign, null);
            var AssVar = new VariableNode("oleg", null, a);
            var const12 = new VariableNode("oleg", null, a);
            var const13 = new VariableNode("oleg", null, a);
            var const5 = new ConstantNode(5, null);

            assignNode.AddLeftOperand(AssVar);
            assignNode.AddRightOperand(new ConstantNode(10, null));
            multNode.AddLeftOperand(const13);
            multNode.AddRightOperand(const5);
            sumNode.AddLeftOperand(const12);*/
            
            string task = "a=(1+2)*3";
            string[] arr = { "1+2", "3+5" };
            Tree tree = new Tree(arr);
            Console.WriteLine(tree.Root.Value);
           // Console.ReadKey();
            //-+222
        }
    }
}