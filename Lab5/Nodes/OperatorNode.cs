﻿namespace Lab5
{
    public class OperatorNode : Node
    {
        public override NodeType GetNodeType() => NodeType.Operator;
        private OperationType Operation { get; }
        private Node[] _children;

        public enum OperationType
        {
            Sum,
            Multiplication,
            Division,
            Subtraction
        }
        public OperatorNode(OperationType operation, Node parent)
        {
            _children = new Node[2];
            Operation = operation;
            Parent = parent;
        }

        public void AddLeftOperand(Node left)
        {
            _children[0] = left;
            left.Parent = this;
        }

        public void AddRightOperand(Node right)
        {
            _children[1] = right;
            right.Parent = this;
        }

        public override double Value
        {
            get
            {
                switch (Operation)
                {
                    case OperationType.Sum:
                        return _children[0].Value + _children[1].Value;
                    case OperationType.Division:
                        return _children[0].Value / _children[1].Value;
                    case OperationType.Multiplication:
                        return _children[0].Value * _children[1].Value;
                    case OperationType.Subtraction:
                        return _children[0].Value - _children[1].Value;
                }

                return 0;
            }
            set => throw new System.NotImplementedException();
        }
    }
}