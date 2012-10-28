using System;

class ExceptionHandling
{
    static int Main()
    {
        Console.Write("Enter your age: ");
        string ageText = Console.ReadLine();

        int age = 0;

        try
        {
            age = int.Parse(ageText);
        }
//        catch (FormatException e)
 //       {
  //          System.Console.WriteLine("Oops!" + e);
   //     }
        finally
        {
            Console.WriteLine("Finally!");
        }

        return age;
    }
}
