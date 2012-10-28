using System;

[Flags]
public enum FileAttributes
{
    ReadOnly = 0x1,
    Hidden = 0x2,
}

public class Program
{
    static void Main(string[] args)
    {
        FileAttributes attr = FileAttributes.ReadOnly | FileAttributes.Hidden;
        System.Console.WriteLine(attr);

        FileAttributes b = (FileAttributes)Enum.Parse(typeof(FileAttributes), attr.ToString());
        System.Console.WriteLine(b);
    }
}
