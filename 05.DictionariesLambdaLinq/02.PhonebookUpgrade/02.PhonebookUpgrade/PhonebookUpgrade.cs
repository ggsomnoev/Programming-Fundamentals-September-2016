using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PhonebookUpgrade
{
    class PhonebookUpgrade
    {
        static void Main(string[] args)
        {
            string[] parts;
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();
            string command, name = "no name", phone = "no number", inputLine = Console.ReadLine();
            while (inputLine != "END")
            {
                parts = inputLine.Split(' ');
                command = parts[0];
                if (parts.Length > 1)
                {
                    name = parts[1];
                }
                if (parts.Length > 2)
                {
                    phone = parts[2];
                }
                if (command == "A")
                {
                    phonebook[name] = phone;
                }
                else if (command == "S")
                {
                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine("{0} => {1}", name, phonebook[name]);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} doesn't exist in the phonebook", name);
                    }
                }
                else if (command == "ListAll")
                {
                    //var result = from pair in phonebook
                    //            orderby pair.Key ascending
                    //            select pair;
                    foreach (var item in phonebook)
                    {
                        Console.WriteLine("{0} => {1}", item.Key, item.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
