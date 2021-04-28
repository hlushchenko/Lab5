namespace Lab5
{
    public abstract class Node
    {
        public double Value;
        public Node Parent;
        public abstract NodeType GetNodeType();
    }
}