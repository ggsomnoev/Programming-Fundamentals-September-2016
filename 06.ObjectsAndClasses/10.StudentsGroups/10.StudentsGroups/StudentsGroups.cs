using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.StudentsGroups
{
    class StudentsGroups
    {
        static void Main(string[] args)
        {
            string[] parts;
            List<Town> groups = new List<Town>();
            Town town = new Town();
            Student student;

            string inputLine = Console.ReadLine();
            while (inputLine.ToLower() != "end")
            {
                parts = inputLine.Split(new char[] {' ', '|'}).Where(x => x != "").ToArray();

                //Console.WriteLine("{0}", string.Join(", ", parts));
                if (parts[parts.Length - 3] == "=>")
                {
                    town = new Town();
                    town.Students = new List<Student>();
                    town.Name = parts[0];
                    town.SeatsCount = int.Parse(parts[parts.Length - 2]);
                    if (parts[1] != "=>")
                    {
                        town.Name = string.Concat(parts[0], " ", parts[1]);
                    }
                }
                else
                {
                    student = new Student();
                    student.Name = string.Concat(parts[0], " ", parts[1]);
                    student.Email = parts[2];
                    student.Date = DateTime.Parse(parts[3]);
                    town.Students.Add(student);                    
                }
                inputLine = Console.ReadLine();

                if (parts[parts.Length - 3] == "=>") {
                    groups.Add(town);
                }
            }

            foreach (var item in groups)
            {
                int counter = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(item.Students.Count) / item.SeatsCount));
                Console.WriteLine(counter);
            }
        }
    }
}
