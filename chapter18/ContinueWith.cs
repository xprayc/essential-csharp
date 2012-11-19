using System;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        Task task = new Task(
            () =>
            {
                Console.WriteLine("In First Task");
            });

        Task second = task.ContinueWith(
            (first) =>
            {
                Console.WriteLine("Second: first task is completed? {0}", first.IsCompleted);
            });

        task.Start();
        second.Wait();
    }
}
