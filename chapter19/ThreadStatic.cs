using System;
using System.Threading;

class Program
{
    [ThreadStatic]
    static double _count = 0.01134;

    public static double Count
    {
        get { return _count; }
        set { _count = value; }
    }

    public static void Main()
    {
        Thread thread = new Thread(Decrement);
        thread.Start();

        for (double i = 0; i < short.MaxValue; i++)
        {
            Count++;
        }

        thread.Join();
        Console.WriteLine("Main Count = {0}", Count);
    }

    public static void Decrement()
    {
        for (double i = 0; i < short.MaxValue; i++)
        {
            Count--;
        }

        Console.WriteLine("Decrement Count = {0}", Count);
    }
}
