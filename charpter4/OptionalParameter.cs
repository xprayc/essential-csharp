class Base
{
    public virtual void Hi(int i = 4)
    {
        System.Console.WriteLine("Base::" + i);
    }
}

class Derived : Base
{
    public override void Hi(int i = 10)
    {
        System.Console.WriteLine("Derived::" + i);
    }
}

class OptionalParameter
{
    public static void Main(string[] args) {
        Base b = new Derived();
        b.Hi();
    }
}
