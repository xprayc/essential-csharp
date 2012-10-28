using System;

class ThrowingExceptions
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Begin executing");
            Console.WriteLine("Throw exception...");
            throw new Exception("Arbitrary exception...");
            Console.WriteLine("End executing...");
        }
        catch (FormatException e)
        {
            Console.WriteLine("A formatException was thrown ->" + e);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected error: {0}", e.Message);
            throw;
        }
        catch
        {
            Console.WriteLine("Unexpected error!");
        }

        Console.WriteLine("Shutting down...");
    }
}
