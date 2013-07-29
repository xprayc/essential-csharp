using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Program
{
    static private object ConsoleSyncObject = new object();

    public static void Main(string[] args)
    {
        string[] urls = args;
        if (args.Length == 0)
        {
            urls = new string[] {
                "http://www.qq.com",
                "http://buy.qq.com",
                "http://www.paipai.com",
                "http://go.qq.com"
            };
        }

        int line = Console.CursorTop;
        Task<WebResponse>[] tasksWithState = 
            urls.Select(
                url => DisplayPageSizeAsync(
                    url, line++)).ToArray();

        while (!Task.WaitAll(tasksWithState, 50))
        {
            DisplayProgress(tasksWithState);
        }

        Console.SetCursorPosition(0, line);
    }

    private static Task<WebResponse>
        DisplayPageSizeAsync(string url, int line)
    {
        lock (ConsoleSyncObject)
        {
            Console.WriteLine(url);
        }

        WebRequest webRequest = WebRequest.Create(url);
        WebRequestState state = new WebRequestState(webRequest, line);
        Task<WebResponse> task = Task<WebResponse>.Factory.FromAsync(
            webRequest.BeginGetResponse, GetResponseAsyncCompleted, state);

        return task;
    }

    private static WebResponse GetResponseAsyncCompleted(
        IAsyncResult asyncResult)
    {
        WebRequestState completedState = (WebRequestState)asyncResult.AsyncState;
        HttpWebResponse response = (HttpWebResponse)completedState.WebRequest
            .EndGetResponse(asyncResult);
        using (StreamReader reader = new StreamReader(
                response.GetResponseStream()))
        {
            int length = reader.ReadToEnd().Length;
            DisplayPageSize(completedState, length);
        }

        return response;
    }

    private static void DisplayProgress(
        IEnumerable<Task<WebResponse>> tasksWithState)
    {
        foreach(WebRequestState state in tasksWithState
                .Where(task => !task.IsCompleted)
                .Select(task => (WebRequestState)task.AsyncState))
        {
            DisplayProgress(state);
        }
    }

    private static void DisplayPageSize(
        WebRequestState completedState, int length)
    {
        lock (ConsoleSyncObject)
        {
            Console.SetCursorPosition(
                completedState.ConsoleColumn,
                completedState.ConsoleLine);
            Console.Write(FormatBytes(length));
            completedState.ConsoleColumn +=
                length.ToString().Length;
        }
    }

    private static void DisplayProgress(
        WebRequestState state)
    {
        int left = state.ConsoleColumn;
        int top = state.ConsoleLine;
        lock (ConsoleSyncObject)
        {
            if (left >= Console.BufferWidth - int.MaxValue.ToString().Length)
            {
                left = state.Url.Length;
                Console.SetCursorPosition(left, top);
                Console.Write("".PadRight(Console.BufferWidth - state.Url.Length));
                state.ConsoleColumn = left;
            }
            else
            {
                state.ConsoleColumn++;
            }

            Console.SetCursorPosition(left, top);
            Console.Write('.');
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

class WebRequestState
{
    public WebRequestState(
        WebRequest webRequest, int line)
    {
        WebRequest = webRequest;
        ConsoleLine = line;
        ConsoleColumn = Url.Length + 1;
    }

    public WebRequestState(WebRequest webRequest)
    {
        WebRequest = webRequest;
    }

    public WebRequest WebRequest { get; private set; }

    public string Url
    {
        get
        {
            return WebRequest.RequestUri.ToString();
        }
    }

    public int ConsoleLine { get; set; }
    public int ConsoleColumn { get; set; }
}
