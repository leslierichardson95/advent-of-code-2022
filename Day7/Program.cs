using System.ComponentModel.Design.Serialization;

namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = File.ReadAllLines("C:/Users/lerich/OneDrive - Microsoft/source/advent-of-code-2022/Day7/input.txt");
            Directory root = new("/", null);
            List<long> directorySizes = new();

            Console.WriteLine("Part 1: " + Part1(root, directorySizes, commands));
            Console.WriteLine("Part 2: " + Part2(root, directorySizes));
        }

        static long Part1(Directory root, List<long> directorySizes, string[] commands)
        {
                        
            Directory currentDirectory = null;

            for (int i = 0; i < commands.Length; i++)
            {
                string directoryName = "";

                if (commands[i].StartsWith("$ cd"))
                {
                    directoryName = commands[i].Split(' ').ElementAt(2).Trim();
                    if (directoryName.Equals("/"))
                        currentDirectory = root;
                    else if (directoryName.Equals(".."))
                        currentDirectory = currentDirectory.ParentDirectory;
                    else
                        currentDirectory = currentDirectory.ChildDirectories.Find(dir => dir.Name == directoryName);
                }
                else if (commands[i].Equals("$ ls"))
                {
                    for (i = i + 1; i < commands.Count() && !commands[i].StartsWith("$"); i++)
                    {
                        if (commands[i].StartsWith("dir"))
                        {
                            directoryName = commands[i].Split(' ').ElementAt(1).Trim();
                            bool hasDirectory = currentDirectory.ChildDirectories
                                .Contains(currentDirectory.ChildDirectories
                                .Find(dir => dir.Name == directoryName));

                            if (!hasDirectory)
                                currentDirectory.ChildDirectories.Add(new Directory(directoryName, currentDirectory));
                        }
                        else
                        {
                            string fileName = commands[i].Split(' ').ElementAt(1).Trim();
                            int fileSize = int.Parse(commands[i].Split(' ').ElementAt(0));
                            currentDirectory.Files.Add(new FileItem(fileName, fileSize));
                        }
                    }

                    i--;
                }

            }

            GetSizes(root, ref directorySizes);
            long sizesUnder100000 = directorySizes.Where(size => size <= 100000).Sum();

            return sizesUnder100000;
        }

        static long Part2(Directory root, List<long> directorySizes)
        {
            long freeSpace = 70000000 - root.Size;
            long spaceNeeded = 30000000 - freeSpace;
            long smallestDirectory = directorySizes.Where(size => size >= spaceNeeded).Min();

            return smallestDirectory;
        }

        static long GetSizes(Directory directory, ref List<long> directorySizes)
        {
            if (directory.Files.Count > 0) // check file sizes
            {
                foreach (FileItem file in directory.Files)
                    directory.Size += file.Size;
            }
            if (directory.ChildDirectories.Count > 0) // check directory sizes
            {
                foreach (Directory childDirectory in directory.ChildDirectories)
                    directory.Size += GetSizes(childDirectory, ref directorySizes);
            }

            directorySizes.Add(directory.Size);
            return directory.Size;
        }
    }

    
    internal class Directory
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public List<Directory> ChildDirectories { get; set; }
        public List<FileItem> Files { get; set; }
        public Directory ParentDirectory { get; set; }
        
        public Directory (string name, Directory parent)
        {
            Name = name;
            ParentDirectory = parent;
            Size = 0;
            ChildDirectories = new();
            Files = new();
        }
    }

    internal class FileItem
    {
        public string Name { get; set; }
        public long Size { get; set; }

        public FileItem (string name, long size)
        {
            Name = name;
            Size = size;
        }
    }
}