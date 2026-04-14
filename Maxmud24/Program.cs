using System;
using static System.Math;

namespace Maxmud24
{
    internal class Program
    {
        static int Yigindi(int n)
        {
            if (n == 0)
                return 0;
            else
                return Yigindi(n - 1) + n;
        }
        static int Faktorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return Faktorial(n - 1) * n;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Matn kiriting: ");
                string m = Console.ReadLine();
                Console.WriteLine(Palindrom(m));
            }
        }

        static bool Palindrom(string matn)
        {
            if (matn.Length <= 1)
                return true;
            else if (matn[0] != matn[matn.Length - 1])
                return false;
            else
                return Palindrom(matn.Substring(1, matn.Length - 2));
        }

        static int Guruhlash(int n, int m)
        {
            if (m==0 || m==n) 
                return 1;
            else
                return Guruhlash(n-1,m)+Guruhlash(n-1,m-1);

        }

        static double Daraja(double asos, double n)
        {
            if (n == 0)
                return 1;
            else if (n < 0)
                return 1.0 / Daraja(asos, Abs(n));
            else
                return asos * Daraja(asos, n - 1);
        }
    }
}
