using System;

namespace Lab5
{
    public class ConditionalNode : Node
    {
        
        public override NodeType GetNodeType() => NodeType.Conditional;
        private Node[] _children;

        public ConditionalNode(Node parent)
        {
            Parent = parent;
            _children = new Node[3];
        }

        public override void AddChild(Node node)
        {
            if (IsFull)
            {
                int current = 0;
                while (_children[current] != null)
                {
                    current++;
                }
                _children[current] = node;
                if (current == 2)
                {
                    IsFull = true;
                }
            }
        }
        
        public override double Value {
            get
            {
                if (_children[0].Value > 0) return _children[1].Value;
                return _children[2].Value;
            }
            set => throw new Exception();
        }
    }
}