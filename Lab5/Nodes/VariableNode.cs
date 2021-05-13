using System;
using System.Collections;

namespace Lab5
{
    public class VariableNode : Node
    {
        public override NodeType GetNodeType() => NodeType.Variable;
        
        public string Name;
        private Hashtable _variables;

        public VariableNode(string name, Node parent, Hashtable variables)
        {
            IsFull = true;
            Name = name;
            Parent = parent;
            _variables = variables;
            if (!variables.ContainsKey(name))
            {
                _variables.Add(name, 0f);
            }
        }
        
        public override double Value
        {
            get => Convert.ToDouble(_variables[Name]);
            set => _variables[Name] = value;
        }
    }
}