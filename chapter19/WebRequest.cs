using System;
using System.IO;
using System.Net;
using System.Linq;

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

        IAsyncResult asyncResult =
            webRequest.BeginGetResponse(null, null);

        while (!asyncResult.AsyncWaitHandle.WaitOne(100))
        {
            Console.Write(".");
        }

        WebResponse response = 
            webRequest.EndGetResponse(asyncResult);
        using (StreamReader reader = new StreamReader(
                response.GetResponseStream()))
        {
            int length = reader.ReadToEnd().Length;
            Console.WriteLine(FormatBytes(length));
        }
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
