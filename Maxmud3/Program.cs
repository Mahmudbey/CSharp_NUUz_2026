using System;

namespace Maxmud3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Ismingiz?");
            string ism = Console.ReadLine();

            Console.WriteLine("Salom, " + ism);
            */

            
            Console.Write("Metr qiymatini kiriting: ");
            double metr = Convert.ToDouble(Console.ReadLine());

            double km = metr*1.0/1000;
            // km = metr / 1000;
            Console.WriteLine($"{metr} metr = {km} km");
            // Console.WriteLine(metr+" metr = "+km+" km");
        }
    }
}
