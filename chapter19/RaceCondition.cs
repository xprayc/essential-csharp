using System;
using System.Threading.Tasks;
using System.Diagnostics;

class Program
{
    static int _total = 0;
    static long _count = 0;

    public static void Main()
    {
        Console.Write("How may times to calculate? ");
        _total = int.Parse(Console.ReadLine());

        Task task = Task.Factory.StartNew(Decrement);

        for (int i = 0; i < _total; i++)
        {
            _count++;
        }

        task.Wait();

        Debug.Assert(_count != 0);
        Console.WriteLine("Count = {0}", _count);
    }

    public static void Decrement()
    {
        for (int i = 0; i < _total; i++)
        {
            _count--;
        }
    }
}
