using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            int c = 2;
            string key = "empty";
            Dictionary<string, string> records = new Dictionary<string, string>();
            string elem = Console.ReadLine();
            while (elem != "stop")
            {
                if (c % 2 == 0)
                {
                    key = elem;
                }
                else
                {
                    if (elem.Substring(elem.Length - 2) != "us" && elem.Substring(elem.Length - 2) != "uk")
                    {
                        records[key] = elem;
                    }
                }
                c++;
                elem = Console.ReadLine();
            }
            foreach (var item in records)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
