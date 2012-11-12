using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static string[] Keywords = {
        "abstract", "add*", "alias", "as",
    };

    public static void Main(string[] args)
    {
        IEnumerable<string> selection = from word in Keywords
            where !word.Contains('*')
            select word;

        foreach (string keyword in selection)
        {
            Console.WriteLine(" " + keyword);
        }
    }
}
