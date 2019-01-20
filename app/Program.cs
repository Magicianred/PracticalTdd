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
            int[] rolls = frames
                .SelectMany(frameStr => frameStr.Split("-"))
                .Select(roll => Convert.ToInt32(roll))
                .ToArray();


            int[] partialScores = new int[frames.Length];
            // Let's first compute partial scores
            for(int i = 0; i < partialScores.Length; i++)
            {
                // if it is a strike compute the bonus
                if(rolls[i] == 10){
                    int bonus = rolls[i + 1] + rolls[i + 2];
                    partialScores[i] = rolls[i] + bonus;
                }
                else
                {
                    // otherwise just sum the rolls
                    int rollsIndex = i * 2;
                    partialScores[i] = rolls[rollsIndex] + rolls[rollsIndex + 1];
                }
            }

            int totalScore = partialScores.Sum();

            //output the results
            Console.WriteLine(args[1]);
            Console.WriteLine(partialScores
                .Aggregate("", (acc, score) => $"{acc}{(acc == string.Empty ? string.Empty : ",")}{score}"));
            Console.WriteLine(totalScore);
        }
    }
}
