using System.Collections.Generic;
using System.IO;

namespace Lab5
{
    public class CodeFileReader
    {
        private string _path;
        public CodeFileReader(string path)
        {
            _path = path;
        }

        public string[] Read()
        {
            List<string> output = new List<string>();
            using (var sr = new StreamReader(_path))
            {
                string current;
                while ((current = sr.ReadLine()) != null) 
                {
                    output.Add(current);
                }
            }
            return output.ToArray();
        }
    }
}