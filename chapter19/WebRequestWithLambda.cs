using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        string url = "http://www.intellitechture.com";
        if (args.Length > 0)
        {
            url = args[0];
        }

        Console.Write(url);
        WebRequest webRequest = WebRequest.Create(url);
        using (ManualResetEventSlim resetEvent =
            new ManualResetEventSlim())
        {
            IAsyncResult asyncResult =
                webRequest.BeginGetResponse(
                    completedAsyncResult =>
                    {
                        WebResponse response = 
                        webRequest.EndGetResponse(completedAsyncResult);
                        using (StreamReader reader = new StreamReader(
                                response.GetResponseStream()))
                        {
                            int length = reader.ReadToEnd().Length;
                            Console.WriteLine(FormatBytes(length));
                        }

                        resetEvent.Set();
                    },
                    null);

            while (!asyncResult.AsyncWaitHandle.WaitOne(100))
            {
                Console.Write(".");
            }

            resetEvent.Wait();
        }
    }

    private static void GetResponseAsycCompleted(
        IAsyncResult asyncResult)
    {
            }

    public static string FormatBytes(long bytes)
    {
        string[] magnitudes = new string[] {
            "GB", "MB", "KB", "Bytes"
        };

        long max = (long)Math.Pow(1024, magnitudes.Length);

        return string.Format(
            "{1:##.##} {0}",
            magnitudes.FirstOrDefault(
                magnitude =>
                    bytes > (max /= 1024))?? "0 Bytes",
            (decimal)bytes / (decimal)max).Trim();

    }
}
