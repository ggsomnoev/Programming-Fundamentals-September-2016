using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SrubskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parts;
            string performer, venue, inputLine = Console.ReadLine();
            int money;
            Dictionary<string, Dictionary<string, int>> records = new Dictionary<string, Dictionary<string, int>>();
            
            while (inputLine.ToLower() != "end")
            {
                string[] input = inputLine.Split('@');

                if (InputValidation(input[0], input[1]))
                {
                    parts = input[1].Split(' ');

                    performer = input[0].TrimEnd(' ');
                    venue = string.Join(" ", parts.Reverse().Skip(2).Take(parts.Length - 2).Reverse());
                    money = int.Parse(parts[parts.Length - 1]) * int.Parse(parts[parts.Length - 2]);

                    if (records.ContainsKey(performer))
                    {
                        if (records[performer].ContainsKey(venue))
                        {
                            records[performer][venue] += money;
                        }
                        else
                        {
                            records[performer][venue] = money;
                        }
                    }
                    else
                    {
                        records[performer] = new Dictionary<string, int>();
                        records[performer][venue] = money;
                    }
                    //Console.WriteLine("{0}, {1}, {2}", performer, venue, money);      
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                inputLine = Console.ReadLine();
            }

            records = records.OrderByDescending(x => x.Value.Values).ToDictionary(p => p.Key, p => p.Value);

            foreach (var outer in records)
            {
                Console.WriteLine(outer.Key);
                foreach (var inner in outer.Value)
                {
                    Console.WriteLine("#  {0} -> {1}", inner.Key, inner.Value);
                }
            }
        }
        static bool InputValidation(string a, string b)
        {
            string[] parts = b.Split(' ');
            int container;

            if (a.EndsWith(" ") && 
                parts.Length >= 3 && (
                int.TryParse(parts[parts.Length - 1], out container) &&
                int.TryParse(parts[parts.Length - 2], out container)
                ))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
