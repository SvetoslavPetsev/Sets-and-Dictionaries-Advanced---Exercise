using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> someNumbers = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                if (!someNumbers.ContainsKey(element))
                {
                    someNumbers.Add(element, 0);
                }
                someNumbers[element]++;
            }
            foreach (var element in someNumbers.Where( x => x.Value % 2 == 0))
            {
                Console.WriteLine(element.Key);
            }
        }
    }
}
