using System;
using System.Threading;

class Program
{
    static ThreadLocal<double> _count = new ThreadLocal<double>(() => 0.01134);
    public static double Count
    {
        get { return _count.Value; }
        set { _count.Value = value; }
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
        Count = -Count;
        for (double i = 0; i < short.MaxValue; i++)
        {
            Count--;
        }

        Console.WriteLine("Decrement Count = {0}", Count);
    }
}
