using System;
using System.IO;

class DataCache
{
    public string FileStreamName { get; set; }

    public DataCache()
    {
        _fileStream = new Lazy<TemporaryFileStream>(
            () => new TemporaryFileStream(FileStreamName));
    }

    public TemporaryFileStream FileStream
    {
        get
        {
            return _fileStream.Value;
        }
    }

    private Lazy<TemporaryFileStream> _fileStream;
}
