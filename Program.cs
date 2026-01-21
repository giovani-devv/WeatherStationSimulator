using System;

namespace WeatherStationSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of days: ");
            int days = int.Parse(Console.ReadLine());

            int[] temperatures = new int[days];
            string[] possibleConditions = { "snowing", "cloudy", "Sunny", "Rainy", "Storm" };
            string[] weatherConditions = new string[days];

            Random random = new Random();

            for (int i = 0; i < days; i++)
            {
                temperatures[i] = random.Next(-5, 40);

                if (temperatures[i] < 0)
                {
                    weatherConditions[i] = possibleConditions[0];
                }
                else
                {
                    int index;
                    do
                    {
                        index = random.Next(possibleConditions.Length);
                    } while (index == 0);

                    weatherConditions[i] = possibleConditions[index];
                }
            }

            Console.WriteLine("Average Temperature is: " + CalculateAverage(temperatures));
            Console.WriteLine("The max Temperature was: " + temperatures.Max());
            Console.WriteLine("The min Temperature was: " + CalculateMin(temperatures));
            Console.WriteLine("The most common condition is: " + MostCommonCondition(weatherConditions));

            Console.ReadKey();
        }


        static double CalculateAverage(int[] temperatures)
        {
            double sum = 0;

            foreach (int temp in temperatures)
            {
                sum += temp;
            }

            return sum / temperatures.Length;
        }


        static int CalculateMin(int[] temperatures)
        {
            int min = temperatures[0];

            foreach (int temp in temperatures)
            {
                if (temp < min)
                    min = temp;
            }

            return min;
        }


        static string MostCommonCondition(string[] conditions)
        {
            int count = 0;
            string mostCommon = conditions[0];

            for (int i = 0; i < conditions.Length; i++)
            {
                int tempCount = 0;

                for (int j = 0; j < conditions.Length; j++)
                {
                    if (conditions[j] == conditions[i])
                        tempCount++;
                }

                if (tempCount > count)
                {
                    count = tempCount;
                    mostCommon = conditions[i];
                }
            }

            return mostCommon;
        }
    }
}
