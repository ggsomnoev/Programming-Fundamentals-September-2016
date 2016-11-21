using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.DragonsArmy
{
    class DragonsArmy
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] value;
            Dictionary<string, Dictionary<string, List<string>>> data = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                value = Console.ReadLine().Split(' ');
                if (value[2] == "null")
                {
                    value[2] = "45";
                }
                if (value[3] == "null")
                {
                    value[3] = "250";
                }
                if (value[4] == "null")
                {
                    value[4] = "10";
                }

                if (data.ContainsKey(value[0]))
                {
                    data[value[0]][value[1]] = new List<string>();
                    data[value[0]][value[1]].Add(value[2]);
                    data[value[0]][value[1]].Add(value[3]);
                    data[value[0]][value[1]].Add(value[4]);
                }
                else
                {
                    data[value[0]] = new Dictionary<string, List<string>>();
                    data[value[0]][value[1]] = new List<string>();

                    data[value[0]][value[1]].Add(value[2]);
                    data[value[0]][value[1]].Add(value[3]);
                    data[value[0]][value[1]].Add(value[4]);
                }
            }

            foreach (var item in data)
            {
                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", item.Key, item.Value.Values.ToArray().Select(x => int.Parse(x[0])).Average(), item.Value.Values.ToArray().Select(x => int.Parse(x[1])).Average(), item.Value.Values.ToArray().Select(x => int.Parse(x[2])).Average());
                foreach (var inner in item.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", inner.Key, inner.Value[0], inner.Value[1], inner.Value[2]);
                }
            }
        }
    }
}
