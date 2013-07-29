class Program
{
    static void Main(string[] args)
    {
        unsafe
        {
            byte* p = stackalloc byte[1024];

            byte[] b = new byte[100];
            fixed (byte* np = b)
            {
            }
        }
    }
}
