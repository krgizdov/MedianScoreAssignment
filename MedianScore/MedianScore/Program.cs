namespace MedianScore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var scoresArray = GetScoreArray();

            var medianScores = GetMedianScores(scoresArray);

            string output = string.Join(", ", medianScores);

            Console.WriteLine($"Median scores:\r\n{output}");
        }

        private static List<int> GetMedianScores(List<int> scoresArray)
        {
            var medianScores = new List<int>();
            var tempScores = new List<int>();

            for (int i = 0; i < scoresArray.Count; i++)
            {
                tempScores.Add(scoresArray[i]);

                tempScores = tempScores.OrderBy(x => x).ToList();

                var midIndex = tempScores.Count / 2;

                if (tempScores.Count % 2 != 0)
                {
                    medianScores.Add(tempScores[midIndex]);
                }
                else
                {
                    var midIndexesSum = tempScores[midIndex] + tempScores[midIndex - 1];

                    var medianRounded = (int)Math.Ceiling(midIndexesSum / 2.0);

                    medianScores.Add(medianRounded);
                }
            }

            return medianScores;
        }

        private static List<int> GetScoreArray()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter scores:");

                    var stringScoreArray = Console.ReadLine()
                       .Split(new string[] { " ", ", ", "," }, StringSplitOptions.RemoveEmptyEntries);

                    CheckInputArrayLength(stringScoreArray);

                    var intScoreArray = new List<int>();

                    for (int i = 0; i < stringScoreArray.Length; i++)
                    {
                        int score = int.Parse(stringScoreArray[i]);

                        CheckScore(score);

                        intScoreArray.Add(score);
                    }

                    return intScoreArray;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void CheckScore(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException($"Numbers cannot be negative!");
            }
            if (score > 1000000)
            {
                throw new ArgumentException($"Numbers cannot be more than 1000000!");
            }
        }

        private static void CheckInputArrayLength(string[] stringScoreArray)
        {
            if (stringScoreArray.Length < 1)
            {
                throw new ArgumentException($"Score length must be more than 0!");
            }
            if (stringScoreArray.Length > 50000)
            {
                throw new ArgumentException($"Score length cannot be more than 50000!");
            }
        }
    }
}
