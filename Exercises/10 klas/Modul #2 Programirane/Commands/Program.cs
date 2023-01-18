using System;
using System.Collections.Generic;
using System.Linq;

namespace Commands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            
            while (command != "print")
            {
                string[] commandArgs = command.Split(' ').ToArray();

                if (commandArgs[0] == "push")
                {
                    int element = int.Parse(commandArgs[1]);
                    numbers.Add(element);
                }
                else if (commandArgs[0] == "pop")
                {
                    Console.WriteLine(numbers[numbers.Count - 1]);
                    numbers.RemoveAt(numbers.Count - 1);
                }
                else if (commandArgs[0] == "shift")
                {
                    int number = numbers[0];
                    numbers[0] = numbers.Last();
                    numbers[numbers.Count - 1] = number;
                }
                else if (commandArgs[0] == "remove")
                {
                    int position = int.Parse(commandArgs[1]);
                    
                    if (position > 0 && position < numbers.Count)
                    {
                        numbers.RemoveAt(position);
                    }
                }
                else if (commandArgs[0] == "addMany")
                {
                    int position = int.Parse(commandArgs[1]);
                    List<int> numbersToAdd = commandArgs.Skip(2).Select(int.Parse).ToList();

                    numbers.InsertRange(position, numbersToAdd);
                }
                
                command = Console.ReadLine();
            }

            numbers.Reverse();
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
