using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    static ManualResetEventSlim _mainEvent;
    static ManualResetEventSlim _doWorkEvent;


    public static void DoWork()
    {
        Console.WriteLine("DoWork started...");
        _doWorkEvent.Set();
        _mainEvent.Wait();
        Console.WriteLine("DoWork finished...");
    }

    public static void Main()
    {
        using (_mainEvent = new ManualResetEventSlim())
        using (_doWorkEvent = new ManualResetEventSlim())
        {
            Console.WriteLine("Application started...");
            Console.WriteLine("Starting task...");

            Task task = Task.Factory.StartNew(DoWork);
            _doWorkEvent.Wait();
            Console.WriteLine("Thread executing...");
            _mainEvent.Set();
            task.Wait();
            Console.WriteLine("Thread completed");
            Console.WriteLine("Application shutting down...");
        }
    }
}
