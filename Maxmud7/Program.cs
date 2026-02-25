using System;

namespace Maxmud7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for(int i=0; i<n; i++)
            // {
            //    Sikl tanasi
            // }
            /*
            for(int i = 0;i<9; i+=2)
            {
                Console.WriteLine($"{i} - sikl");
            }
            */
            /*
            int bosh = 45;
            for(int i = bosh; i>=25; i-=1) // i--
            {
                Console.WriteLine($"{i}\t{i-0.5}\t{i-0.8}");
            }
            */
            /*
            double valyuta = 12137.10;

            //for(int i=1; i<=20; i++)
            for (int i = 50; i <= 1000; i+=50)
            {
                Console.WriteLine($"${i} = {i*valyuta}");
            }
            */
            /*
            int son = 8;

            for(int i=2; i<=9;i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i}x{j} = {i * j}");
                }
                Console.WriteLine();
            }
            */

            /*
            // 0 1 1 2 3 5 8 13 21 34 55 ... Fibonachchi sonlari
            int bir = 0;
            int ikki = 1;
            int n = 30;

            int t;

            for(int i=1; i<=n;i++)
            {
                // (bir, ikki) = (ikki, bir + ikki);
                t = bir; // 0
                bir = ikki; // 0->1
                ikki = t + ikki; // 0+1=1
                Console.Write($"{t}  ");
            }
            */


            // EKUB(n,m) = ?
            /*
             48-18 = 30
             30-18 = 12
             18-12 = 6
             12-6 = 6
             6-6 = 0
             */

            /*
             int n, m;
            n = 512; m = 144;
            while (n != m)
            {
                if (n > m)
                    n -= m;
                else
                    m -= n;
               // Console.WriteLine($"n={n}\tm={m}");
            }
            Console.WriteLine($"EKUB={n}");
        */
            Random r = new Random();
            int son = r.Next(1, 100001);

            Console.WriteLine($"son ={ son}");

            int yigindi = 0;
            int kopaytma = 1;
            int oxirgi;

            while(son>0)
            {
                oxirgi = son % 10;
                yigindi += oxirgi;
                kopaytma *= oxirgi;
                son /= 10;
            }
            Console.WriteLine($"Yigindi={yigindi}");
            Console.WriteLine($"Kopaytma={kopaytma}");
        }
    }
}
