using System.Reflection.Metadata.Ecma335;

namespace Day5
{
    internal class Program
    {
        static string[]? StackRows;
        static string[]? Instructions;
        static List<Stack<char>>? Stacks;
        static void Main(string[] args)
        {
            string file = File.ReadAllText("C:/Users/lerich/OneDrive - Microsoft/source/advent-of-code-2022/Day5/sampleInput.txt");
            string[] input = file.Split("\n\n");

            StackRows = input[0].Split('\n');
            Instructions = input[1].Split("\n");

            Console.WriteLine("Part 1: " + Part1());
            Console.WriteLine("Part 2: " + Part2());
        }

        static string Part1()
        {
            LoadStacksInit();

            foreach (string instruction in Instructions)
            {
                string[] instructionPieces = instruction.Split(' ');
                int stacksToMove = int.Parse(instructionPieces[1]);
                int fromStack = int.Parse(instructionPieces[3]);
                int toStack = int.Parse(instructionPieces[5]);

                // locate the stack # to move Stacks from
                for (int i = 0; i < stacksToMove; i++) 
                {
                    char crate = Stacks[fromStack - 1].Pop();
                    Stacks[toStack - 1].Push(crate);
                }
            }

            string topCrates = "";
            foreach (Stack<char> stack in Stacks) topCrates += stack.Peek();
            return topCrates;
            
        }
        
        static string Part2()
        {
            LoadStacksInit();

            foreach (string instruction in Instructions)
            {
                string[] instructionPieces = instruction.Split(' ');
                int stacksToMove = int.Parse(instructionPieces[1]);
                int fromStack = int.Parse(instructionPieces[3]);
                int toStack = int.Parse(instructionPieces[5]);

                // locate the stack # to move Stacks from
                Stack<char> crates = new();
                for (int i = 0; i < stacksToMove; i++)
                {
                    crates.Push(Stacks[fromStack - 1].Pop());
                }
                foreach (char crate in crates) Stacks[toStack - 1].Push(crate);

            }

            string topCrates = "";
            foreach (Stack<char> stack in Stacks) topCrates += stack.Peek();
            return topCrates;
        }

        static void LoadStacksInit() 
        {
            Stacks = new();
            
            // initialize stacks based on the # of columns
            for (int i = 0; i < int.Parse(StackRows[StackRows.Length - 1][33].ToString()); i++) Stacks.Add(new Stack<char>());
            for (int i = StackRows.Length - 2; i >= 0; i--) // for each row, starting from the bottom
            {
                string row = StackRows[i];
                for (int j = 1; j < row.Length; j += 4)
                {
                    if (row[j] != ' ') Stacks[((j+3)/4) - 1].Push(row[j]);
                }
            }
        }
    }
}