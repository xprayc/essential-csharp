public class TryDelegate
{
    public delegate bool CompareHandler(int a, int b);

    public static bool SayOk(int a, int b, CompareHandler compareHandler)
    {
        return compareHandler(a, b);
    }

    public static bool Smaller(int a, int b)
    {
        return a < b;
    }

    public bool Bigger(int a, int b)
    {
        return a > b;
    }

    public static void Main(string[] args)
    {
        System.Console.WriteLine("SayOk: {0}", SayOk(1, 40, Smaller));
        System.Console.WriteLine("SayOk: {0}", SayOk(1, 40, new TryDelegate().Bigger));
        System.Console.WriteLine(
            "SayOk: {0}", SayOk(1, 40, delegate(int i, int j) { return false; }));
    }
}
