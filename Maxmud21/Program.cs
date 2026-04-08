using System;

namespace Maxmud21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10; int b = 20;
           // Chop(a, b);

           // Almashtir(a, b);
            // Chop(a, b);

            Almash(ref a, ref b);
           Chop(a, b);
           // Salom();
        }
        static void Almashtir(int n, int m)
        { // n=1, m =3
            int t = n; // t=1
            n = m; // n=3
            m = t; // m=t=1
        }
        static void Almash(ref int n, ref int m)
        { // n=1, m =3
            int t = n; // t=1
            n = m; // n=3
            m = t; // m=t=1
        }
        
        static void Chop(int a1, int a2)
        {
            Console.WriteLine($"a1={a1}\ta2={a2}\n");
            // Salom();

            void Hi()
            {
                Console.WriteLine("Ichki metod test!");
                Salom();
            }

            Hi();
        }

        static void Salom()
        {
            Console.WriteLine("Metod test!");
        }
    }
}
