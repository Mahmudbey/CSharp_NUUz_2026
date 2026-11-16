using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { " Ali ", " Vali ", " Hasan " };
            string result = string.Join(", ", names);
            Console.WriteLine(result);
        }
    }
}
