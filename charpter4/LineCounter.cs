using System.IO;

public static class LineCounter
{
    private static int DirectoryCountLines()
    {
        return DirectoryCountLines(Directory.GetCurrentDirectory());
    }

    private static int DirectoryCountLines(string directory)
    {
        return DirectoryCountLines(directory, "*.cs");
    }

    private static int DirectoryCountLines(string directory, string extension)
    {
        int lineCount = 0;
        foreach (string file in Directory.GetFiles(directory, extension))
        {
            lineCount += CountLines(file);
        }

        foreach (string subdirectory in Directory.GetDirectories(directory))
        {
            lineCount += DirectoryCountLines(subdirectory);
        }

        return lineCount;
    }

    private static int CountLines(string file)
    {
        int lineCount = 0;
        FileStream stream = new FileStream(file, FileMode.Open);
        StreamReader reader = new StreamReader(stream);
        
        for (string line = reader.ReadLine(); line != null;
                line = reader.ReadLine())
        {
            if (line.Trim() != "")
            {
                lineCount++;
            }
        }

        reader.Close();
        return lineCount;
    }

    public static void Main(string[] args)
    {
        int totalLineCount;

        if (args.Length == 0)
        {
            totalLineCount = DirectoryCountLines();
        }
        else if (args.Length == 1)
        {
            totalLineCount = DirectoryCountLines(args[0]);
        }
        else
        {
            totalLineCount = DirectoryCountLines(args[0], args[1]);
        }

        System.Console.WriteLine(totalLineCount);
    }
}
