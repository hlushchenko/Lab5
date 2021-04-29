using System;
using System.Collections;

namespace Lab5
{
    public class VariableNode : Node
    {
        public override NodeType GetNodeType() => NodeType.Variable;

        public string Name;
        public Hashtable Ht;

        public VariableNode(string name, Node parent, Hashtable ht)
        {
            Name = name;
            Parent = parent;
            Ht = ht;
            ht.Add(name, 0f);
        }

        private new double Value
        {
            get => Convert.ToDouble(Ht[Name]);
            set => Ht[Name] = value;
        }

    }
}