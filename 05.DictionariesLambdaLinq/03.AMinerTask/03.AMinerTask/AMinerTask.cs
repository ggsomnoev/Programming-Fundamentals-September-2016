using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AMinerTask
{
    class AMinerTask
    {
        static void Main(string[] args)
        {
            int c = 2;
            string key = "empty";
            Dictionary<string, int> records = new Dictionary<string, int>();
            string elem = Console.ReadLine();
            while (elem != "stop")
            {
                if (c % 2 == 0)
                {
                    key = elem;
                }
                else {
                    records[key] = int.Parse(elem);
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
