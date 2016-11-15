using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            string country, city;
            int ppl;
            string[] parts;
            Dictionary<string, int> summed = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> pop = new Dictionary<string, Dictionary<string, int>>();
            string inputLine = Console.ReadLine();
            while (inputLine != "report" && inputLine != "")
            {
                parts = inputLine.Split('|');
                country = parts[1];
                city = parts[0];
                ppl = int.Parse(parts[2]);

                if (pop.ContainsKey(country))
                {
                    if (pop[country].ContainsKey(city))
                    {
                        pop[country][city] += ppl;
                    }
                    else
                    {
                        pop[country][city] = ppl;
                    }
                }
                else
                {
                    pop[country] = new Dictionary<string, int>();
                    pop[country][city] = ppl;
                }

                inputLine = Console.ReadLine();
            }

            foreach (var item in pop)
            {
                summed[item.Key] = item.Value.Values.Sum();
            }
            var test = from entr in summed orderby entr.Value descending select entr;

            foreach (var item in test)
            {
                Console.WriteLine("{0} (total population: {1})", item.Key, item.Value);
                foreach (var outer in pop)
                {
                    foreach (var inner in outer.Value)
                    {
                        Console.WriteLine("=>{0}: {1}", inner.Key, inner.Value);
                    }
                }
            }

        }
    }
}
