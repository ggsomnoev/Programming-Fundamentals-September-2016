using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            string[] parts;
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string command, name, phone = "***", inputLine = Console.ReadLine();
            while (inputLine != "END") {
                parts = inputLine.Split(' ');
                command = parts[0];
                name = parts[1];
                if(parts.Length > 2) {
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
                    else {
                        Console.WriteLine("Contact {0} doesn't exist in the phonebook", name);
                    }
                }
                else {
                    Console.WriteLine("Invalid Command");
                } 

                inputLine = Console.ReadLine();
            }
        }
    }
}
