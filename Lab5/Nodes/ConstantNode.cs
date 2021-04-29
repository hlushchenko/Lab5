namespace Lab5
{
    public class ConstantNode : Node
    {
        public override NodeType GetNodeType() => NodeType.Constant;
        public ConstantNode(double value, Node parent)
        {
            Value = value;
            Parent = parent;
        }
    }
}