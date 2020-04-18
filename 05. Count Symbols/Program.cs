using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main()
        {
            var elementsCount = new SortedDictionary<char, int>();

            var input = Console.ReadLine().ToCharArray();
            foreach (char symbol in input)
            {
                if (!elementsCount.ContainsKey(symbol))
                {
                    elementsCount.Add(symbol, 0);
                }
                elementsCount[symbol]++;
            }
            foreach (var (key, value) in elementsCount)
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
        }
    }
}
