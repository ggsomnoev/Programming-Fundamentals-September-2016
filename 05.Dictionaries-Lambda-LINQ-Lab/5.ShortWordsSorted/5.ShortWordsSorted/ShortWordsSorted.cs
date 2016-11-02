using System;
using System.Linq;

namespace _5.ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            char[] sep = new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '\"', '\'', '\\', '/', '!', '?', ' ' };
            string[] words = Console.ReadLine().ToLower().Split(sep).Where(x => x != "" && x.Length < 5).OrderBy(x => x).Distinct().ToArray();
            Console.WriteLine(string.Join(", ", words));               
        }
    }
}
