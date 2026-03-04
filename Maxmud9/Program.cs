using System;
using static System.Math;

namespace Maxmud9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
 while (shart)
{
     shart bajarilganda sikl
}
 */
            /*
            double a = 1089;
            double b = 20;

            int k = 0;

            while(a>=b)
            {
                a -= b; k++;
            }
            Console.WriteLine($"{k} ta {b} metr kesma\nva {a} metr qoldiq bor");
            */
            /*
             while (true)
            {
                Console.Write("\nn= ");
                int n = Convert.ToInt32(Console.ReadLine());//99;
                int i = 0;
                int son = 2;

                bool uch = false;

                while (Pow(son, i) != n && Pow(son, i) <= n)
                {
                    i++;
                    if (Pow(son, i) == n)
                    {
                        uch = true;
                        Console.WriteLine($"{n}={son}ning {i} darajasiga teng");
                    }
                }

                if (!uch)
                {
                    Console.WriteLine($"{n} - {son}ning darajasi emas");
                }
            }
            */
            /*
            int n = 1000;
            int s = 0;
            int s1 = 0;

            int i = 1;
             while (s<=n)
            {
                s1 = s; // 21
                s += i; // s=0+1+2+3+4+5+6=21+7=28
                i++;
                // if(s>=n) // 28>25
                // {}
            }

            Console.WriteLine($"k={i-2}, s={s1}<{n}\t s2={s}>{n}");
            */

            double bosh = 250;
            double foiz = 7;
            double k = 1.5;

            double s = bosh; // 0 ;
            int i = 1;
            while(s/bosh <k)
            {
                s = bosh * Pow((1 + foiz / 100),i);
                i++;
               // s += s * (foiz / 100);
            }
            Console.WriteLine($"{i} oyda {s:F3} so'm ({k})");

        }
    }
}
