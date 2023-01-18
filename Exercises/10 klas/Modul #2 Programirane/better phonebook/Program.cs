﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace better_phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new SortedDictionary<string, string>();
            var line = Console.ReadLine().Split().ToArray();

            while (line[0]!= "END")
            {
                switch (line[0])
                {
                    case "A":
                        {
                            phonebook[line[1]] = line[2];
                            break;
                        }
                    case "S":
                        {
                            if (phonebook.ContainsKey(line[1]))
                            {
                                var phone = phonebook[line[1]];
                                Console.WriteLine($"{line[1]} -> {phone}");
                            }
                            else 
                            {
                                Console.WriteLine($"Contact {line[1]} does not exist."); 
                            }
                            break;
                        }
                    case "ListAll":
                        {
                            foreach (var key in phonebook.Keys)
                            {
                                Console.WriteLine($"{0} -> {1}", key, phonebook[key]);
                            }
                            break;
                        }
                }

                line = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
