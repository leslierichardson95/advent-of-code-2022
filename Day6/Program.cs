namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("C:/Users/lerich/OneDrive - Microsoft/source/advent-of-code-2022/Day6/input.txt");
            Console.WriteLine("Part 1: " + Part1(input, 4));
            Console.WriteLine("Part 2: " + Part1(input, 14));
        }
        
        static int Part1(string input, int markerSize)
        {
            int firstIndex = markerSize;
            for (int i = 0; firstIndex < input.Length; i++) 
            {
                HashSet<char> letters = new();
                bool foundMarker = true;
                foreach (char letter in input[i..firstIndex]) 
                {
                    if (letters.Contains(letter)) 
                    {
                        foundMarker = false;
                        break;
                    } 
                    else letters.Add(letter);
                }
                if (foundMarker) break;
                else firstIndex++;
            }
            return firstIndex;
        }
    }
}