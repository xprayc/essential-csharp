class Money
{
    private decimal _amount;

    public Money(decimal amount)
    {
        _amount = amount;
    }

    public decimal Amount
    {
        get
        {
            return _amount;
        }
    }

    public static Money operator +(Money lhs, Money rhs)
    {
        System.Console.WriteLine("oeprator + is invoked. ");
        return new Money(lhs._amount + rhs._amount);
    }

    public static void Main(string[] args)
    {
        Money m = new Money(34);
        Money m2 = new Money(1);
        System.Console.WriteLine((m + m2).Amount);

        Money m3 = new Money(-100);
        m3 += m;
        System.Console.WriteLine("m3: {0}", m3.Amount);
    }
}
