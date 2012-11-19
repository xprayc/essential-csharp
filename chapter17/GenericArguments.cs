using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Type t = typeof(Dictionary<int, string>);
        Console.WriteLine("GenericArguments of Dictionary<int, string>:");
        foreach (Type g in t.GetGenericArguments())
        {
            Console.WriteLine("  {0}", g.FullName);
        }

        t = typeof(Dictionary<,>);
        Console.WriteLine("GenericArguments of Dictionary<,>:");
        foreach (Type g in t.GetGenericArguments())
        {
            Console.WriteLine("  {0}", g);
        }
    }
}
