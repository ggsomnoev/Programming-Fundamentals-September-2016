using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            string address, username;
            SortedDictionary<string, Dictionary<string, int>> logs = new SortedDictionary<string, Dictionary<string, int>>();
            string inputLine = Console.ReadLine();
            while (inputLine != "end" && inputLine != "")
            {
                address = inputLine.Split(new char[] { ' ' })[0].Substring(3);
                username = inputLine.Split(new char[] { ' ' })[2].Substring(5);

                if (logs.ContainsKey(username))
                {
                    if (logs[username].ContainsKey(address))
                    {
                        logs[username][address]++;
                    }
                    else
                    {
                        logs[username][address] = 1;
                    }
                }
                else {
                    logs[username] = new Dictionary<string, int>();

                    logs[username][address] = 1;
                }

                inputLine = Console.ReadLine();
            }

            foreach (var item in logs)
            {
                Console.WriteLine("{0}:", item.Key);
                foreach (var itemTwo in item.Value)
                {
                    Console.WriteLine("{0} => {1}.", itemTwo.Key, itemTwo.Value);
                }
            }
        }
    }
}
