﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _3te_nai_golemi_chisla
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(String.Join(" ", nums.OrderByDescending(x => x).Take(3)));
        }

    }
}
