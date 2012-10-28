class TryParse
{
    static void Main()
    {
        double number;
        string input;
        System.Console.Write("Enter a number: ");
        input = System.Console.ReadLine();
        if (double.TryParse(input, out number))
        {
            System.Console.WriteLine("You entered {0}.", number);
        }
        else
        {
            System.Console.WriteLine("The text entered was not a valid number.");
        }
    }
}
