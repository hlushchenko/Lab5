namespace Lab5
{
    public class ConstantNode : Node
    {
        public sealed override double Value { get; set; }
        public override NodeType GetNodeType() => NodeType.Constant;
        public ConstantNode(double value, Node parent)
        {
            Value = value;
            Parent = parent;
        }
    }
}