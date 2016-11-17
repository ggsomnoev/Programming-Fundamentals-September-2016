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
            Dictionary<string, int> junk = new Dictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();

            int i = 1;
            string[] input = Console.ReadLine().ToLower().Split();
            while (i < input.Length)
            {
                if (keyMaterials.ContainsKey(input[i]) && (input[i] == "shards" || input[i] == "fragments" || input[i] == "motes"))
                {
                    keyMaterials[input[i]] += int.Parse(input[i - 1]);
                }
                else if(input[i] == "shards" || input[i] == "fragments" || input[i] == "motes")
                {
                    keyMaterials[input[i]] = int.Parse(input[i - 1]);
                }
                else if(!junk.ContainsKey(input[i]))
                {
                    junk[input[i]] = int.Parse(input[i - 1]);
                }

                i += 2;
            }

            Container(keyMaterials);

            junk = junk.OrderBy(x => x.Key).ToDictionary(p => p.Key, p => p.Value);
            keyMaterials = keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(p => p.Key, p => p.Value);

            foreach (var sortedMats in keyMaterials)
            {
                Console.WriteLine("{0}: {1}", sortedMats.Key, sortedMats.Value);
            }

            foreach (var item in junk)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }       
        }
        static void Container(Dictionary<string, int> junk) {
            if (junk.ContainsKey("shards"))
            {
                if (junk["shards"] >= 250)
                {
                    junk["shards"] -= 250;
                    Console.WriteLine("Shadowmourne obtained!");
                }
            }
            else
            {
                junk["shards"] = 0;
            }

            if (junk.ContainsKey("fragments"))
            {
                if (junk["fragments"] >= 250)
                {
                    junk["fragments"] -= 250;
                    Console.WriteLine("Valanyr obtained!");
                }
            }
            else
            {
                junk["fragments"] = 0;
            }

            if (junk.ContainsKey("motes"))
            {
                if (junk["motes"] >= 250)
                {
                    junk["motes"] -= 250;
                    Console.WriteLine("Dragonwrath obtained!");
                }
            }
            else
            {
                junk["motes"] = 0;
            }
        }
    }
}
