class AnonymousType
{
    static void Main()
    {
        var patent1 = new {
            Title = "Bifocals",
            YearOfPublication = "1784" };
        
        var patent2 = new {
            Title = "Phonograph",
                  YearOfPublication = "1877" };

        System.Console.WriteLine("{0} ({1})",
                patent1.Title, patent1.YearOfPublication);

        System.Console.WriteLine("{0} ({1})",
                patent2.Title, patent1.YearOfPublication);
    }
}
