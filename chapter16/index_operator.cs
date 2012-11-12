using System;

interface IPair<T>
{
    T First
    {
        get;
    }

    T Second
    {
        get;
    }

    T this[PairItem index]
    {
        get;
    }
}

public enum PairItem
{
    First,
    Second
}

public struct Pair<T> : IPair<T>
{
    public Pair(T first, T second)
    {
        _first = first;
        _second = second;
    }

    public T First
    {
        get { return _first; }
        private set { _first = value; }
    }

    private T _first;
    
    public T Second
    {
        get { return _second; }
        private set { _second = value; }
    }

    private T _second;

    public T this[PairItem index]
    {
        get
        {
            switch (index)
            {
                case PairItem.First:
                    return First;
                case PairItem.Second:
                    return Second;
                default:
                    throw new NotImplementedException(
                        string.Format("The enum {0} has not been implemented",
                                      index.ToString()));
            }
        }

        set
        {
            switch (index)
            {
                case PairItem.First:
                    First = value;
                    break;
                case PairItem.Second:
                    Second = value;
                    break;
                default:
                    throw new NotImplementedException(
                        string.Format("The enum {0} has not been implemented",
                                      index.ToString()));
            }
        }
    }

    public override string ToString()
    {
        return string.Format("({0}, {1})", First, Second);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pair<int> p = new Pair<int>();
        p[PairItem.First] = 4;
        p[PairItem.Second] = 5;

        Console.WriteLine(p);
    }
}
