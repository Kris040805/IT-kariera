using System;
using System.Collections.Generic;
using System.Linq;

namespace patients
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> patients = Console.ReadLine().Split(", ").Where(x => x != "").ToList();

            string name = "";
            int position = 0;

            string command = Console.ReadLine();

            while (command != "END OF PATIENTS")
            {
                switch (command)
                {
                    case "Add patient":
                        name = Console.ReadLine();
                        patients.Add(name);
                        break;
                    case "Add patient on position":
                        name = Console.ReadLine();
                        position = int.Parse(Console.ReadLine());
                        patients.Insert(position, name);
                        break;
                    case "Remove patient on position":
                        position = int.Parse(Console.ReadLine());
                        patients.RemoveAt(position);
                        break;
                    case "Remove last patient":
                        patients.RemoveAt(patients.Count - 1);
                        break;
                    case "Remove first patient":
                        patients.RemoveAt(0);
                        break;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", patients));
        }
    }
}
