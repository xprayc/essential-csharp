using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            AppDomain.CurrentDomain.UnhandledException +=
                OnUnhandledException;
            ThreadPool.QueueUserWorkItem(
                state => {
                    throw new Exception("Arbitrary Exception");
                });

            Thread.Sleep(3000);
            Console.WriteLine("Still running...");
        }
        finally
        {
            Console.WriteLine("Exiting...");
        }
    }

    static void OnUnhandledException(
        object sender, UnhandledExceptionEventArgs eventArgs)
    {
        Exception exception = (Exception)eventArgs.ExceptionObject;

        Console.WriteLine(
            "ERROR ({0}){1} ---> {2}", exception.GetType().Name,
            exception.Message, exception.InnerException);
    }
}
