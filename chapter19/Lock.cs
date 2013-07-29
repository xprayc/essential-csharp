using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static readonly object _sync = new object();
    const int _total = 10000000;
    static long _count = 0;


    public static void Main()
    {
        Task task = Task.Factory.StartNew(Decrement);

        for (int i = 0; i < _total; i++)
        {
            lock (_sync)
            {
                _count++;
            }
        }

        task.Wait();
        Console.WriteLine("Count = {0}", _count);
    }

    static void Decrement()
    {
        for (int i = 0; i < _total; i++)
        {
            lock (_sync)
            {
                _count--;
            }
        }
    }
}
