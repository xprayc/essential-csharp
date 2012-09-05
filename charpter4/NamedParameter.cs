class NamedParameter
{
    public static void Main(string[] args)
    {
        DisplayGreeting(firstName: "Martin", lastName: "Fowler");
    }

    public static void DisplayGreeting(
        string firstName,
        string middleName = default(string),
        string lastName = default(string)
        )
    {
        System.Console.WriteLine("{0} {1} {2}", firstName, middleName, lastName);
    }
}
