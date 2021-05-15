using System.Collections.Generic;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp = "x= a? b:c";
            string temp2 = SyntaxTree.FormatString(temp);
            Stack<string> a = SyntaxTree.Parse(temp2);
            SyntaxTree syntaxTree = new SyntaxTree();
            string[] arr = { temp2 };
            syntaxTree.AddFromStringArray(arr);
            /*CodeFileReader codeFile = new CodeFileReader(args[0]);
            SyntaxTree syntaxTree = new SyntaxTree();
            syntaxTree.AddFromStringArray(codeFile.Read());
            syntaxTree.PrintResult();*/
        }
    }
}