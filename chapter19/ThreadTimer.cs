using System;
using System.Threading;

class UsingSystemTimersTimer
{
    private static int _count = 0;
    private static readonly ManualResetEvent _resetEvent =
        new ManualResetEvent(false);
    private static int _alarmThreadId;

    public static void Main()
    {
        using (Timer timer = new Timer(Alarm, null, 0, 1000))
        {
            _resetEvent.WaitOne();
        }

        if (_alarmThreadId == Thread.CurrentThread.ManagedThreadId)
        {
            throw new ApplicationException(
                "Thread Ids are the same.");
        }

        if (_count < 9)
        {
            throw new ApplicationException(
                "_count < 9");
        }

        Console.WriteLine(
            "(Alarm Thread Id) {0} != {1} (Main Thread Id)",
            _alarmThreadId,
            Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine(
            "Final Count = {0}", _count);
    }

    public static void Alarm(
        object state)
    {
        _count++;

        Console.WriteLine(
            "{0}:- {1}", DateTime.Now.ToString(),
            _count);

        if (_count >= 9)
        {
            _alarmThreadId = Thread.CurrentThread.ManagedThreadId;
            _resetEvent.Set();
        }
    }
}
