using System;
using System.Collections.Generic;

namespace Lab5
{
    public class RootNode : Node
    {
        private List<Node> _children;

        public RootNode()
        {
            _children = new List<Node>();
        }

        public void AddChild(Node newNode) 
        {
            _children.Add(newNode);
        }
        public override double Value {
            get
            {
                double value = 0;
                foreach (var node in _children)
                {
                    value += node.Value;
                }
                return value;
            }
            set => throw new NotImplementedException(); }
        public override NodeType GetNodeType() => NodeType.Root;
    }
}