using System;
using System.Collections.Generic;

namespace personValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), double.Parse(cmdArgs[3]));
                people.Add(person);
            }

            double bonus = double.Parse(Console.ReadLine());
            foreach (var person in people)
            {
                person.IncreaseSalary(bonus);
            }

            people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
