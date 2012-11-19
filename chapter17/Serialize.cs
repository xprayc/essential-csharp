using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    public static void Main(string[] args)
    {
        Stream stream;
        Document documentBefore = new Document();
        documentBefore.Title =
            "A cacophony of ramblings from my potpourri of notes";
        Document documentAfter;

        using (stream = File.Open("document.bin", FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, documentBefore);
        }

        using (stream = File.Open("document.bin", FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            documentAfter = (Document) formatter.Deserialize(
                stream);
        }

        Console.WriteLine(documentAfter.Title);
    }
}

[Serializable]
class Document
{
    public string Title = null;
    public string Data = null;

    [NonSerialized]
    private long _WindowHandle;

    public class Image
    {
    }

    [NonSerialized]
    private Image _Picture;

    public long WindowHandle
    {
        get
        {
            return _WindowHandle;
        }
    }

    public Image Picture
    {
        get
        {
            return _Picture;
        }
    }
}
