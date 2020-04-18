using System;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            List<int> firstSet = new List<int>();
            List<int> secondSet = new List<int>();
            var repeatSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var first in firstSet)
            {
                foreach (var second in secondSet)
                {
                    if (first == second)
                    {
                        repeatSet.Add(first);
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", repeatSet));
        }
    }
}
