using System.Linq;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rucksacks = File.ReadAllLines("C:/Users/lerich/OneDrive - Microsoft/source/advent-of-code-2022/Day3/input.txt");
            Console.WriteLine("Part 1: " + Part1(rucksacks));
            Console.WriteLine("Part 2: " + Part2(rucksacks));
        }

        static int Part1(string[] rucksacks)
        {
            int sum = 0;

            foreach (string rucksack in rucksacks)
            {
                int halfIndex = rucksack.Length / 2;
                string compartment1 = rucksack[0..halfIndex];
                string compartment2 = rucksack[halfIndex..rucksack.Length];

                foreach (char item in compartment1)
                {
                    if (compartment2.Contains(item))
                    {
                        if (!Char.IsUpper(item)) sum += (item - 'a' + 1);
                        else sum += (item - 'A' + 27);
                        break;
                    }
                }
            }
            return sum;
        }

        static int Part2(string[] rucksacks)
        {
            int sum = 0;
            for (int i = 0; i < rucksacks.Length; i += 3)
            {
                string rucksack1 = rucksacks[i];
                string rucksack2 = rucksacks[i + 1];
                string rucksack3 = rucksacks[i + 2];

                foreach (char item in rucksack1)
                {
                    if (rucksack2.Contains(item) && rucksack3.Contains(item))
                    {
                        if (!Char.IsUpper(item)) sum += (item - 'a' + 1);
                        else sum += (item - 'A' + 27);
                        break;
                    }
                }
            }   

            return sum;
        }
    }
}