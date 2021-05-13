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
            IsFull = true;
            Name = name;
            Parent = parent;
            Ht = ht;
            if (!ht.ContainsKey(name))
            {
                Ht.Add(name, 0f);
            }
        }
        
        public override double Value
        {
            get => Convert.ToDouble(Ht[Name]);
            set
            {
                Ht[Name] = value;
            }
        }
    }
}