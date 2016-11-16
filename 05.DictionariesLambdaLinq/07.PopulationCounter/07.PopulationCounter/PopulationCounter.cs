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

            var sortedContries = pop.OrderByDescending(x => x.Value.Values.Sum());

            foreach (var outer in sortedContries)
            {
                var sortedCities = outer.Value.OrderByDescending(x => x.Value);
                Console.WriteLine("{0} (total population: {1})", outer.Key, outer.Value.Sum(c => c.Value));

                foreach (var inner in sortedCities)
                {
                    Console.WriteLine("=>{0}: {1}", inner.Key, inner.Value);
                }
            }
        }
    }
}
