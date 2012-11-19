using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<int> l = new List<int>() {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        CancellationTokenSource cts = 
            new CancellationTokenSource();

        ParallelOptions parallelOptions = 
            new ParallelOptions {
                CancellationToken = cts.Token
            };

        cts.Token.Register(
            () => Console.WriteLine("Canceling ..."));

        Console.WriteLine("Push ENTER to exit.");

        Task<int> task = Task.Factory.StartNew(() =>
        {
            Parallel.ForEach(
                l, parallelOptions, (i, loopState) => 
                {
                    Console.WriteLine("{0}", i);
       //             Thread.Sleep(1000);
       
                    for (int j = 0; j < 1000000000; ++j)
                    {
                        
                    }
                });
        });

        Console.Read();

        cts.Cancel();

        Console.WriteLine("-----------------华丽的分割线----------------");

        task.Wait();
    }
}
