using System;
using System.Threading;

class TryThread
{
    public const int repetition = 1000;

    public static void Main()
    {
        ThreadStart threadStart = Dowork;

        Thread thread = new Thread(threadStart);
        thread.IsBackground = true;
        thread.Start();

        for (int count = 0; count < repetition; count++)
        {
            Console.Write("-");
        }

        thread.Join();
        Console.WriteLine();
    }

    public static void Dowork()
    {
        for (int count = 0; count < repetition; count++)
        {
            Console.Write(".");
        }
    }
}
