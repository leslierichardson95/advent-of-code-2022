namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rounds = File.ReadAllLines("C:/Users/lerich/OneDrive - Microsoft/source/advent-of-code-2022/Day2/input.txt");
            Console.WriteLine("Part 1: " + Part1(rounds));
            Console.WriteLine("Part 2: " + Part2(rounds));
        }

        static int Part1(string[] rounds)
        {
            int totalScore = 0;

            // A = rock, B = paper, C = scissors
            // X(1) = rock, Y(2) = paper, Z(3) = scissors
            foreach (string round in rounds)
            {
                if (round[0] == 'A') // rock
                {
                    if (round[2] == 'X') totalScore += (1 + 3);
                    else if (round[2] == 'Y') totalScore += (2 + 6);
                    else totalScore += (3 + 0);
                }
                else if (round[0] == 'B') // paper
                {
                    if (round[2] == 'X') totalScore += (1 + 0);
                    else if (round[2] == 'Y') totalScore += (2 + 3);
                    else totalScore += (3 + 6);
                }
                else // scissors
                {
                    if (round[2] == 'X') totalScore += (1 + 6);
                    else if (round[2] == 'Y') totalScore += (2 + 0);
                    else totalScore += (3 + 3);
                }
            }
            return totalScore;
        }

        static int Part2(string[] rounds)
        {
            int totalScore = 0;

            // A = rock, B = paper, C = scissors
            // X(1) = rock, Y(2) = paper, Z(3) = scissors
            foreach (string round in rounds)
            {
                if (round[0] == 'A') // rock
                {
                    if (round[2] == 'X') totalScore += (3 + 0);
                    else if (round[2] == 'Y') totalScore += (1 + 3);
                    else totalScore += (2 + 6);
                }
                else if (round[0] == 'B') // paper
                {
                    if (round[2] == 'X') totalScore += (1 + 0);
                    else if (round[2] == 'Y') totalScore += (2 + 3);
                    else totalScore += (3 + 6);
                }
                else // scissors
                {
                    if (round[2] == 'X') totalScore += (2 + 0);
                    else if (round[2] == 'Y') totalScore += (3 + 3);
                    else totalScore += (1 + 6);
                }
            }

            return totalScore;
        }
    }
}