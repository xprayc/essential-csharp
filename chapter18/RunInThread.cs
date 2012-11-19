using System;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        const int repetitions = 10000;

        Task task = new Task(() =>
             {
             for (int count = 0; count < repetitions; count++)
             {
             Console.Write("-");
             }
             });

        task.Start();

        for (int count = 0; count < repetitions; count++)
        {
            Console.Write(".");
        }

        task.Wait();
        Console.WriteLine();
    }
}
