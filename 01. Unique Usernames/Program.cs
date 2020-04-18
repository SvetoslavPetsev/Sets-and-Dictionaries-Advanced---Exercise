using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main()
        {
            HashSet<string> uniqe = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                uniqe.Add(name);
            }
            Console.WriteLine(string.Join(Environment.NewLine,uniqe));
        }
    }
}
