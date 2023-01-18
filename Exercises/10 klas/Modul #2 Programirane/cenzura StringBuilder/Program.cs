using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cenzura_StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split();
            StringBuilder sen = Console.ReadLine();
            
            foreach (var banWord in banWords)
            {
                if (sen.Contains(banWord))
                {
                    sen = sen.Replace(banWord, new String('*', banWord.Length));
                }
            }

            Console.WriteLine(sen);
        }
    }
}
