using System;

namespace Maxmud20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Salom();
            Salom("C#");
            Salom();
            Salom("Aziz");
            Salom("Ali", 2501);
        }
        static void Salom() // parametrsiz
        {
            Console.WriteLine("Salom, metod!");
        }
        static void Salom(string ism) // 1 ta parametrli
        {
            Console.WriteLine($"Salom, {ism}!");
        }
        static void Salom(string ism, int gr) // 2 ta parametrli
        {
            Console.WriteLine($"Salom, {ism}!\nTMI-{gr} guruhi talabasi");
        }
    }
}
