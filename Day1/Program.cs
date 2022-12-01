using System.Collections.Generic;

namespace Day1
{
    internal class Program
    {
        private static List<int>? ElfCalories;

        static void Main(string[] args)
        {
            string[] list = File.ReadAllLines("C:/Users/lerich/OneDrive - Microsoft/source/advent-of-code-2022/Day1/input.txt");
            ElfCalories = new();

            Console.WriteLine(Part1(list));
            Console.WriteLine(Part2());
        }

        public static int Part1(string[] list)
        {
            int mostCalories = 0;
            int totalCalories = 0;

            foreach (string calorie in list)
            {
                if (!String.IsNullOrEmpty(calorie))
                {
                    totalCalories += int.Parse(calorie);
                }
                else
                {
                    if (totalCalories > mostCalories) mostCalories = totalCalories;
                    ElfCalories.Add(totalCalories);
                    totalCalories = 0;
                }
            }

            return mostCalories;
        }

        public static int Part2()
        {
            ElfCalories.Sort();
            return ElfCalories[ElfCalories.Count - 1] + ElfCalories[ElfCalories.Count - 2] + ElfCalories[ElfCalories.Count - 3];
        }
    }
}