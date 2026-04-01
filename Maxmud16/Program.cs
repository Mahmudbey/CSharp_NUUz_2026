using System;

namespace Maxmud16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            for(int i=1; i<=5; i++)
            {
                Raqam_(r.Next(100, 1001), r.Next(2, 100));
            }

        }
        static void Raqam_(int n, int m)
        {
            int butun = n / m; // 6
            double kasr = (n % m) * 1.0 / m; // 0.25

            Console.WriteLine($"\n{n}:{m}={butun}+{kasr}");

            int raqamSoni_butun = butun.ToString().Length;
            int raqamSoni_kasr = kasr.ToString().Length - 2;

            int raqamSoni = raqamSoni_butun + raqamSoni_kasr; // 2: 0 va .

            int p1 = 1; int s1 = 0;
            //for (int i = 1; i <= raqamSoni_butun; i++)
            while(butun>0)
            {
                p1 *= butun % 10;
                s1 += butun % 10;
                butun /= 10;
            }

            int p2 = 1; int s2 = 0;
            //for (int i = 1; i <= raqamSoni_kasr; i++)
            while(kasr>0)
            {
                kasr *= 10;
                p2 *= (int)kasr; // % 10;
                s2 += (int)kasr;
                kasr -= (int)kasr;
            }

            int p = p1 * p2;
            int s= s1 + s2;

            Console.WriteLine($"{raqamSoni} ta raqam bor");
            Console.WriteLine($"p1={p1}\tp2={p2}\tp={p} raqamlar ko'p");
            Console.WriteLine($"s1={s1}\ts2={s2}\ts={s} raqamlar yig");


        }
    }
}
