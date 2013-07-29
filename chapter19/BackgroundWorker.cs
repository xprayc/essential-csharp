using System;
using System.Threading;
using System.ComponentModel;

public class Installer
{
    public static BackgroundWorker calculationWorker =
        new BackgroundWorker();
    public static AutoResetEvent resetEvent =
        new AutoResetEvent(false);

    public static void Main()
    {
        int bytes = 0;
        Console.WriteLine("Enter the bytes to install");
        if (!int.TryParse(Console.ReadLine(), out bytes))
        {
            Console.WriteLine("The value entered is an invalid integer.");
            return;
        }

        if (bytes <= 0)
        {
            Console.WriteLine("The value entered should be positive.");
            return;
        }

        Console.WriteLine("ENTER to cancel");

        calculationWorker.DoWork += Install;
        calculationWorker.ProgressChanged +=
            UpdateProgress;
        calculationWorker.WorkerReportsProgress = true;
        calculationWorker.RunWorkerCompleted +=
            InstallCompleted;
        calculationWorker.WorkerSupportsCancellation = true;
        calculationWorker.RunWorkerAsync(
            bytes);

        Console.ReadLine();
        calculationWorker.CancelAsync();
        resetEvent.WaitOne();
    }

    private static void Install(
        object sender, DoWorkEventArgs eventArgs)
    {
        int bytes = (int)eventArgs.Argument;
        for (int i = 0; i <= bytes; i += 100)
        {
            resetEvent.WaitOne(10);

            if (calculationWorker.CancellationPending)
            {
                eventArgs.Cancel = true;
                break;
            }
            
            calculationWorker.ReportProgress(i * 100 / bytes);
        }
    }

    private static void UpdateProgress(
        object sender, ProgressChangedEventArgs eventArgs)
    {
        Console.Write("\rInstalling...{0:###}%", eventArgs.ProgressPercentage);
    }

    private static void InstallCompleted(
        object sender,
        RunWorkerCompletedEventArgs eventArgs)
    {
        Console.WriteLine();

        if (eventArgs.Cancelled)
        {
            Console.WriteLine("Install cancelled!");
        }
        else if (eventArgs.Error != null)
        {
            Console.WriteLine("Fatal error! {0}", eventArgs.Error.Message);
        }
        else
        {
            Console.WriteLine("Install completed!");
        }

        resetEvent.Set();
    }
}
