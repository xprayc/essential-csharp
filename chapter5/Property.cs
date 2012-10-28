public class Property
{
    private int _name;

    public int Name
    {
        get {
            return _name;
        }

        set {
            _name = value;
        }
    }

    public string Title
    {
        get; set;
    }

    public static void Main(string[] args)
    {
        Property p = new Property();
        p.Name = 9527;
    }
}
