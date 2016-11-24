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
                parts = inputLine.Split(new char[] { ' ', '|' }).Where(x => x != "").ToArray();

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

                if (parts[parts.Length - 3] == "=>")
                {
                    groups.Add(town);
                }
            }
            groups = groups.OrderBy(x => x.Name).ToList();
            foreach (var outer in groups)
            {
                outer.Students = outer.Students.OrderBy(x => x.Date).ThenBy(x => x.Name).ThenBy(x => x.Email).ToList();
                //Console.WriteLine("{0}:", outer.Name);
                //for (int i = 0; i < outer.Students.Count; i++)
                //{
                //    Console.WriteLine("{0}, ".TrimEnd(new char[] { ' ', ',' }), outer.Students[i].Email);
                //}
            }

            double totalGroups = groups.Select(x => (Math.Ceiling(Convert.ToDouble(x.Students.Count) / x.SeatsCount))).Sum();
            Console.WriteLine("Created {0} groups in {1} towns:", totalGroups, groups.Count);

            foreach (var outer in groups)
            {
                int counter = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(outer.Students.Count) / outer.SeatsCount));
                int n = 0;
                for (int i = 0; i < counter; i++)
                {
                    if (n + outer.SeatsCount >= outer.Students.Count)
                    {
                        Console.WriteLine("{0} => {1}", outer.Name, string.Join(", ", outer.Students.Skip(n).Take(outer.Students.Count - n).Select(x => x.Email)));
                    }
                    else
                    {
                        Console.WriteLine("{0} => {1}", outer.Name, string.Join(", ", outer.Students.Skip(n).Take(outer.SeatsCount).Select(x => x.Email)));
                        n = outer.SeatsCount;
                    }
                }
            }
        }
    }
}
