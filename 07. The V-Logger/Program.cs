using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    public class VloggerStatus
    {
        public List<string> Followers { get; set; }
        public int Following { get; set; }
        public VloggerStatus(List<string> followers, int following)
        {
            this.Followers = followers;
            this.Following = following;
        }
    }
    class Program
    {
        static void Main()
        {
            // vloger - /follower - following/
            var community = new Dictionary<string, VloggerStatus>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info.Contains("joined"))
                {
                    string vloggerName = info[0];
                    if (!community.ContainsKey(vloggerName))
                    {
                        community.Add(vloggerName, new VloggerStatus(new List<string>(), 0));
                    }
                }
                else if (info.Contains("followed"))
                {
                    string follower = info[0];
                    string following = info[2];
                    if (follower == following)
                    {
                        continue;
                    }
                    if (community.ContainsKey(follower) && community.ContainsKey(following))
                    {
                        if (!community[following].Followers.Contains(follower))
                        {
                            community[following].Followers.Add(follower);
                            community[follower].Following++;
                        }
                    }
                }
            }
            int counter = 1;
            Console.WriteLine($"The V-Logger has a total of {community.Count} vloggers in its logs.");
            foreach (var vlogger in community.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following} following");
                if (counter == 1)
                {
                    foreach (var name in vlogger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
                counter++;
            }
        }
    }
}
