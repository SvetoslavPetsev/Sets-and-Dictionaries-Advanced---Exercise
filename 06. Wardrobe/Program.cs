using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main()
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] storage = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                }

                foreach (var item in storage)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }
                    wardrobe[color][item]++;
                }
            }

            string[] find = Console.ReadLine().Split();
            string findColor = find[0];
            string findItem = find[1];
            foreach (var (key, value) in wardrobe)
            {
                Console.WriteLine($"{key} clothes:");
                foreach (var item in value)
                {
                    if (key == findColor && item.Key == findItem)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {item.Key} - {item.Value}");
                }
            }
        }
    }
}
