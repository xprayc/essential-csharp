using System;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        Task task = new Task(() =>
        {
            throw new ApplicationException();
        });
        
        task.Start();

        try
        {
            task.Wait();
        }
        catch (AggregateException exception)
        {
            foreach (Exception item in exception.InnerExceptions)
            {
                Console.WriteLine("ERROR: {0}", item.Message);
            }
        }

    }
}
