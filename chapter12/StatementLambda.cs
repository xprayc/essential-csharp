public class StatementLambda
{
    public delegate bool CompareHandler(int a, int b);

    public static bool SayOk(int a, int b, CompareHandler compareHandler)
    {
        return compareHandler(a, b);
    }

    public static void Main(string[] args)
    {
        int count = 0;
        System.Console.WriteLine(
            "SayOk: {0}", SayOk(1, 40, (int i, int j) => { count++; return false; }));
        System.Console.WriteLine("count: {0}", count);

        System.Console.WriteLine(
            "SayOk: {0}", SayOk(
                1, 40,
                (i, j) =>  // no type needed
                {
                    return i < j;
                }));
    }
}
