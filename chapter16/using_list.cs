using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> list = new List<string>();
        list.Add("Sneezy");
        list.Add("Happy");
        list.Add("Dopey");
        list.Add("Doc");

        list.Sort();

        Console.WriteLine(
            "In alphabetical order {0} is the first word while "
            + "{1} is the last.", list[0], list[3]);
    }
}
