using System;

class GetType
{
    static void Main(string[] args)
    {
        DateTime time = new DateTime();

        Type type = time.GetType();
        
        Console.WriteLine("Propery of class {0}:", type.Name);
        foreach (System.Reflection.PropertyInfo property in type.GetProperties())
        {
            Console.Write(" ");
            Console.WriteLine(property.Name);
        }
    }
}
