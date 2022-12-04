namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pairs = File.ReadAllLines("C:/Users/lerich/OneDrive - Microsoft/source/advent-of-code-2022/Day4/input.txt");

            Console.WriteLine("Part 1: " + Part1(pairs));
            Console.WriteLine("Part 2: " + Part2(pairs));
        }

        static int Part1(string[] pairs)
        {
            int totalPairs = 0;
            foreach (string input in pairs)
            {
                string[] pair = input.Split(new char[] { ' ', ',', '-' });
                
                int lowSect1 = int.Parse(pair[0]);
                int highSect1 = int.Parse(pair[1]);
                int lowSect2 = int.Parse(pair[2]);
                int highSect2 = int.Parse(pair[3]);

                if ((lowSect2 >= lowSect1 && highSect2 <= highSect1) ||
                    (lowSect1 >= lowSect2 && highSect1 <= highSect2)) totalPairs++;
            }

            return totalPairs;
        }

        static int Part2(string[] pairs)
        {
            int totalPairs = 0;
            foreach (string input in pairs)
            {
                string[] pair = input.Split(new char[] { ' ', ',', '-' });

                int lowSect1 = int.Parse(pair[0]);
                int highSect1 = int.Parse(pair[1]);
                int lowSect2 = int.Parse(pair[2]);
                int highSect2 = int.Parse(pair[3]);

                if ((lowSect2 >= lowSect1 && lowSect2 <= highSect1) ||
                    (lowSect1 >= lowSect2 && lowSect1 <= highSect2)) totalPairs++;
            }

            return totalPairs;
        }
    }
}