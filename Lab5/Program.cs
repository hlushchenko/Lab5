namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeFileReader codeFile = new CodeFileReader("D:/Code.txt");
            SyntaxTree syntaxTree = new SyntaxTree();
            syntaxTree.AddFromStringArray(codeFile.Read());
            syntaxTree.PrintResult();
        }
    }
}