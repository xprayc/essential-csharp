class Program
{
    static void Main()
    {
        string text = "S5280FT";
        System.Console.WriteLine("{0}", text);

        unsafe
        {
            fixed (char* pText = text)
            {
                char* p = pText;
                *++p = 'm';
                *++p = 'i';
                *++p = 'l';
                *++p = 'e';
                *++p = '.';
                *++p = '!';
            }
        }

        System.Console.WriteLine("{0}", text);
    }
}
