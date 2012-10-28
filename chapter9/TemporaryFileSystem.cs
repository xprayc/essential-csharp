using System;
using System.IO;

class TemporaryFileStream : IDisposable
{
    public TemporaryFileStream()
    {
        _file = new FileInfo(Path.GetTempFileName());
        _stream = new FileStream(
            _file.FullName, FileMode.OpenOrCreate,
            FileAccess.ReadWrite);
    }

    // Finalizer
    ~TemporaryFileStream()
    {
        System.Console.WriteLine("~TemporaryFileStream called");
        Close();
    }

    public FileStream Stream
    {
        get { return _stream; }
    }

    private readonly FileStream _stream;

    public FileInfo File
    {
        get { return _file; }
    }

    private readonly FileInfo _file;

    public void Close()
    {
        if (_stream != null)
        {
            _stream.Close();
        }

        if (_file != null)
        {
            _file.Delete();
        }
        
        // Turn off calling the finalizer
        System.GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        System.Console.WriteLine("IDisposable.Dispose called");
        Close();
    }
}

class program
{
    public static void Main(string[] args)
    {
        using (TemporaryFileStream f = new TemporaryFileStream())
        {
            System.Console.WriteLine("FileName: " + f.File.FullName);
        }
    }

}
