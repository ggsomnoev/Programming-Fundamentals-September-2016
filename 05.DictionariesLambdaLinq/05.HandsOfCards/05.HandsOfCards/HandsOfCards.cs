using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HandsOfCards
{
    class HandsOfCards
    {
        static void Main(string[] args)
        {
            int points = 0, power, type;
            string[] item;
            Dictionary<string, List<string>> records = new Dictionary<string, List<string>>();
            string elem = Console.ReadLine();
            while (elem != "JOKER" && elem != "joker")
            {
                item = elem.Split(new char[] { ' ', ',', ':' }).Where(x => x != "").Distinct().ToArray();

                if (records.ContainsKey(item[0]))
                {
                    //Console.WriteLine("trying to add: {0}", string.Join(" | ", item.Skip(1).Take(item.Length - 1).ToList()));
                    //Console.WriteLine("current entry: {0}", string.Join(" | ", records[item[0]]));
                    //Console.WriteLine("result entry: {0}", string.Join(" | ",
                    //    (records[item[0]].Concat(item.Skip(1).Take(item.Length - 1).ToList()).Distinct())
                    //));
                    records[item[0]] = (records[item[0]].Concat(item.Skip(1).Take(item.Length - 1).ToList())).Distinct().ToList();
                }
                else
                {
                    records[item[0]] = item.Skip(1).Take(item.Length - 1).ToList();
                }
                elem = Console.ReadLine();
            }

            foreach (var a in records)
            {
                //Console.WriteLine("{0} => {1}", a.Key, string.Join(" | ", a.Value));
                foreach (var b in a.Value)
                {
                    type = CardType(b.ToLower().Substring(0, b.Length - 1));
                    power = CardPower(b.ToLower()[b.Length - 1]);
                    points += type * power;
                }
                Console.WriteLine("{0} => {1}", a.Key, points);
                points = 0;
            }
            
        }
        static int CardType(string card) {
            switch (card)
            {
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "j":
                    return 11;
                case "q":
                    return 12;
                case "k":
                    return 13;
                case "a":
                    return 14;
                default:
                    Console.WriteLine("Invalid card type!");
                    return -1;
            }
        }
        static int CardPower(char cardPower) {
            switch (cardPower)
            {
                case 's':
                    return 4;
                case 'h':
                    return 3;
                case 'd':
                    return 2;
                case 'c':
                    return 1;
                default:
                    Console.WriteLine("Invalid card power!");
                    return -1;
            }
        }
    }
}
