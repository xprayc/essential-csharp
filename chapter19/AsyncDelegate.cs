using System;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Application started...");

        Console.WriteLine("Starting thrad...");
        Func<int, string> workerMethod = Caculate;
        IAsyncResult asyncResult = workerMethod.BeginInvoke(100, null, null);

        while (!asyncResult.AsyncWaitHandle.WaitOne(100, false))
        {
            Console.Write('.');
        }
        Console.WriteLine();

        Console.WriteLine("Thread ending...");
        Console.WriteLine(workerMethod.EndInvoke(asyncResult));
        Console.WriteLine("Application shutting down...");
    }

    public static string Caculate(int digits)
    {
        Thread.Sleep(1000);
        return "*************";
    }
}
