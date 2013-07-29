using System;
using System.Threading;
using System.Reflection;

public class Program
{
    static void Main()
    {
        bool firstApplicationInstance;

        //string mutexName = Assembly.GetEntryAssembly().FullName;
        string mutexName = "Global\\Mutex";

        Console.WriteLine(mutexName);

        using (Mutex mutex = new Mutex(
                true, mutexName, out firstApplicationInstance))
        {
            if (!firstApplicationInstance)
            {
                Console.WriteLine("This application is already running...");
            }
            else
            {
                Console.WriteLine("ENTER to shutdown.");
                Console.ReadLine();
            }
        }
    }
}
