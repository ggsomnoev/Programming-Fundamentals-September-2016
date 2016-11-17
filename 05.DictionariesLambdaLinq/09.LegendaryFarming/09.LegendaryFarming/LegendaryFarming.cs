using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            Dictionary<string, int> sortedLegendaries = new Dictionary<string, int>();

            int i = 1;
            string[] input = Console.ReadLine().ToLower().Split();
            while (i < input.Length)
            { 
                if (items.ContainsKey(input[i]))
                {
                    items[input[i]] += int.Parse(input[i - 1]);
                }
                else
                {
                    items[input[i]] = int.Parse(input[i - 1]);
                }

                i += 2;
            }
            if (items.ContainsKey("shards"))
            {
                if (items["shards"] >= 250)
                {
                    items["shards"] -= 250;
                    Console.WriteLine("Shadowmourne obtained!");
                }
            }
            else
            {
                items["shards"] = 0;
            }

            if (items.ContainsKey("fragments"))
            {
                if (items["fragments"] >= 250)
                {
                    items["fragments"] -= 250;
                    Console.WriteLine("Valanyr obtained!");
                }
            }
            else
            {
                items["fragments"] = 0;
            }

            if (items.ContainsKey("motes"))
            {
                if (items["motes"] >= 250)
                {
                    items["motes"] -= 250;
                    Console.WriteLine("Dragonwrath obtained!");
                }
            }
            else
            {
                items["motes"] = 0;
            }

            sortedLegendaries["fragments"] = items["fragments"];
            sortedLegendaries["shards"] = items["shards"];
            sortedLegendaries["motes"] = items["motes"];


            items = items.OrderBy(x => x.Value).ToDictionary(p => p.Key, p => p.Value);
            sortedLegendaries = sortedLegendaries.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(p => p.Key, p => p.Value);

            //Console.WriteLine("{0}", string.Join(", ", items));
            foreach (var sortedMats in sortedLegendaries)
            {
                Console.WriteLine("{0}: {1}", sortedMats.Key, sortedMats.Value);
            }

            foreach (var item in items)
            {
                if (item.Key != "motes" && item.Key != "fragments" && item.Key != "shards")
                {
                    Console.WriteLine("{0}: {1}", item.Key, item.Value);
                }
                
            }
        }
    }
}
