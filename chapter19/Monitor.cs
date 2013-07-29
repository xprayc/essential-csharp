using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static readonly object _sync = new object();
    const int _total = 20000000;
    static long _count = 0;


    public static void Main()
    {
        Task task = Task.Factory.StartNew(Decrement);

        for (int i = 0; i < _total; i++)
        {
            bool lockTaken = false;

            try
            {
                Monitor.Enter(_sync, ref lockTaken);
                _count++;
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(_sync);
                }
            }
        }

        task.Wait();
        Console.WriteLine("Count = {0}", _count);
    }

    static void Decrement()
    {
        for (int i = 0; i < _total; i++)
        {
            bool lockTaken = false;
            try
            {
                Monitor.Enter(_sync, ref lockTaken);
                _count--;
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(_sync);
                }
            }
        }
    }
}
