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
            Dictionary<string, int> records = new Dictionary<string, int>();
            string elem = Console.ReadLine();
            while (elem != "JOKER" && elem != "joker")
            {
                item = elem.Split(new char[] { ' ', ',', ':' }).Where(x => x != "").ToArray();
                for (int i = 1; i < item.Length; i++)
                {
                    type = CardType(item[i].ToLower().Substring(0, item[i].Length - 1));
                    power = CardPower(item[i].ToLower()[item[i].Length - 1]);
                    points += type + power; 
                }
                if (records.ContainsKey(item[0])) {
                    records[item[0]] += points;
                }
                else
                {
                    records[item[0]] = points;
                }
                //Console.WriteLine("{0}", string.Join(" | ", item));
                Console.WriteLine("{0} -> {1}", item[0], records[item[0]]);
                elem = Console.ReadLine();
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
