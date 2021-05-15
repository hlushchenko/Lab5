namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeFileReader codeFile = new CodeFileReader(args[0]);
            SyntaxTree syntaxTree = new SyntaxTree();
            syntaxTree.AddFromStringArray(codeFile.Read());
            syntaxTree.PrintResult();
        }
    }
}