namespace Lab5
{
    public abstract class Node
    {
        public double Value { get; set;}
        public Node Parent;
        public abstract NodeType GetNodeType();
    }
}