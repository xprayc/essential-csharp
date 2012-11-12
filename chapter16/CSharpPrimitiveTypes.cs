using System;
using System.Collections.Generic;

public class CSharpPrimitiveTypes : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        yield return "object";
        yield return "byte";
        yield return "uint";
        yield return "ulong";
        yield return "float";
    }

    System.Collections.IEnumerator
    System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        CSharpPrimitiveTypes primitives = new CSharpPrimitiveTypes();
        foreach (string s in primitives)
        {
            Console.WriteLine(s);
        }
    }
}
