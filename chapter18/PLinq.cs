using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static List<int> ParallelAdd(
        List<int> data,
        CancellationToken cancellationToken)
    {
        return data.AsParallel().WithCancellation(
            cancellationToken).Select(
                (item) => item + 1).ToList();
    }

    public static void Main()
    {
        List<int> data = Enumerable.Range(0, 10000000).ToList();

        CancellationTokenSource cts = new CancellationTokenSource();

        Console.WriteLine("Push ENTER to exit.");

        Task task = Task.Factory.StartNew(() =>
            {
                data = ParallelAdd(data, cts.Token);
            }, cts.Token);

        Console.Read();

        cts.Cancel();

        Console.Write("---------------");
        task.Wait();
    }
}
