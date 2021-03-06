using System;

namespace Lab5
{
    public class OperatorNode : Node
    {
        private OperationType Operation { get; }
        private Node[] _children;
        
        public enum OperationType
        {
            Sum,
            Multiplication,
            Division,
            Subtraction,
            Assign
        }
        public override NodeType GetNodeType()
        {
            if (Operation == OperationType.Assign)
            {
                return NodeType.Assign;
            }
            else
            {
                return NodeType.Operator;
            }
        }
        public OperatorNode(OperationType operation, Node parent)
        {
            _children = new Node[2];
            Operation = operation;
            Parent = parent;
        }

        public OperatorNode(OperationType operation)
        {
            _children = new Node[2];
            Operation = operation;
            Parent = null;
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
            IsFull = true;
        }

        public override void AddChild(Node newNode)
        {
            if (!IsFull)
            {
                if (_children[0] == null)
                {
                    _children[0] = newNode;
                }
                else
                {
                    _children[1] = newNode;
                    IsFull = true;
                }
            }
        }

        public override double Value
        {
            get
            {
                switch (Operation)
                {
                    case OperationType.Sum:
                        return _children[1].Value + _children[0].Value;
                    case OperationType.Division:
                        return _children[1].Value / _children[0].Value;
                    case OperationType.Multiplication:
                        return _children[1].Value * _children[0].Value;
                    case OperationType.Subtraction:
                        return _children[1].Value - _children[0].Value;
                    case OperationType.Assign:
                        if (_children[1].GetNodeType() == NodeType.Variable)
                        {
                            _children[1].Value = _children[0].Value;
                        }
                        return _children[1].Value;
                }
                return 0;
            }
            set => throw new Exception();
        }
    }
}