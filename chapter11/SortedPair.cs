public class SortedPair<T>
    where T : System.IComparable<T>
{

    private readonly T _first;
    private readonly T _second;

    public SortedPair(T first, T second)
    {
		if (first.CompareTo(second) < 0)
		{
			_first = first;
			_second = second;
		}
		else
		{
			_first = second;
			_second = first;
		}
    }

    public T First
    {
        get { return _first; }
    }

    public T Second
    {
        get { return _second; }
    }

    public override string ToString()
    {
        return string.Format("({0}, {1})", _first.ToString(), _second.ToString());
    }
}

class Program
{
    public static void Main(string[] args)
    {
        SortedPair<int> p = new SortedPair<int>(100, 10);
        System.Console.WriteLine(p);
        System.Console.WriteLine(new SortedPair<int>(-100, 10));
    }
}
