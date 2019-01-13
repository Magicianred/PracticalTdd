using System;
using System.Linq;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Split frames
            string[] frames = args[1].Split(",");

            // Split and convert each roll in order to have partial score of each frame
            int[] partialScores = frames
                .Select(frameStr => frameStr.Split("-"))
                .Select(rolls => rolls.Select(roll => Convert.ToInt32(roll)).Sum())
                .ToArray();

            int totalScore = partialScores.Sum();

            Console.WriteLine(args[1]);
            Console.WriteLine(partialScores
                .Aggregate("", (acc, score) => $"{acc}{(acc == string.Empty ? string.Empty : ",")}{score}"));
            Console.WriteLine(totalScore);
        }
    }
}
