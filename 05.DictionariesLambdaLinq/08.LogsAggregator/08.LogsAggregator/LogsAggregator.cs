using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.LogsAggregator
{
    class LogsAggregator
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string ip, name;
            int value;
            string[] inputLine;
            SortedDictionary<string, SortedDictionary<string, int>> userBase = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < num; i++)
            {
                inputLine = Console.ReadLine().Split(' ');
                ip = inputLine[0];
                name = inputLine[1];
                value = Convert.ToInt32(inputLine[2]);

                if (userBase.ContainsKey(name))
                {
                    if (userBase[name].ContainsKey(ip))
                    {
                        userBase[name][ip] += value;
                    }
                    else
                    {
                        userBase[name][ip] = value;
                    }
                }
                else
                {
                    userBase[name] = new SortedDictionary<string, int>();
                    userBase[name][ip] = value;
                }
            }
            foreach (var item in userBase)
            {
                var sum = item.Value.Values.Sum();

                Console.WriteLine("{0}: {1} [{2}]", item.Key, sum, string.Join(", ", item.Value.Keys));
            }

        }
    }
}
