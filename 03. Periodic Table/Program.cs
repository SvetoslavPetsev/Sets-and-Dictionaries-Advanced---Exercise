using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main()
        {
            SortedSet<string> uniqueElements = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputElements = Console.ReadLine().Split();
                foreach (var element in inputElements)
                {
                    uniqueElements.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}
