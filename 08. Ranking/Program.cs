using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main()
        {
            var contest = new Dictionary<string, string>();
            string info;
            while ((info = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = info.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var contestName = contestInfo[0];
                var contestPassword = contestInfo[1];
                if (!contest.ContainsKey(contestName))
                {
                    contest.Add(contestName, contestPassword);
                }
            }
            var studentList = new SortedDictionary<string, Dictionary<string, int>>();
            string input;
            while ((input = Console.ReadLine())!= "end of submissions")
            {
                string[] submInfo = input.Split("=>",StringSplitOptions.RemoveEmptyEntries);
                var contestName = submInfo[0];
                var contestPassword = submInfo[1];
                var studentName = submInfo[2];
                var studentPoints = int.Parse(submInfo[3]);

                if (contest.ContainsKey(contestName))
                {
                    if (contest[contestName] == contestPassword)
                    {
                        if (!studentList.ContainsKey(studentName))
                        {
                            var contestPoint = new Dictionary<string, int>();
                            contestPoint.Add(contestName, studentPoints);
                            studentList.Add(studentName, contestPoint);
                        }
                        else if (!studentList[studentName].ContainsKey(contestName))
                        {
                            studentList[studentName].Add(contestName, studentPoints);
                        }
                        else if (studentList[studentName][contestName] < studentPoints)
                        {
                            studentList[studentName][contestName] = studentPoints;
                        }
                    }
                }
            }
            string bestStudentName = string.Empty;
            int bestStudentTotalScore = 0;
            foreach (var studentSummary in studentList)
            {
                int currScore = 0;
                foreach (var contestInfo in studentSummary.Value)
                {
                    int score = contestInfo.Value;
                    currScore += score;
                }
                if (currScore > bestStudentTotalScore)
                {
                    bestStudentTotalScore = currScore;
                    bestStudentName = studentSummary.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestStudentName} with total {bestStudentTotalScore} points.");
            Console.WriteLine("Ranking:");
            foreach (var studentSummary in studentList)
            {
                Console.WriteLine(studentSummary.Key);
                foreach (var contestInfo in studentSummary.Value.OrderByDescending(x=> x.Value))
                {
                    Console.WriteLine($"#  {contestInfo.Key} -> {contestInfo.Value}");
                }
            }
        }
    }
}
