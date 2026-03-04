using System;
using System.Runtime.InteropServices;

namespace Maxmud8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for(int i=start; i<stop; i+=h); i++
            // sikl uzunligi: (stop-start)/h
            // int j;
            // for(j=start; j<=stop; j+=h);
            // sikl uzunligi: (stop-start+1)/h

            /*
            int n = int.MaxValue/1000;

            Console.WriteLine(n);
            
            for(int i = 0; i<n; i+=n/10)
            {
                Console.Write($"{i}  ");
            }
            */
            /*
            for(int i = 25; i<=35; i++)
            {
                Console.WriteLine($"{i}\t{i+0.5}\t{i-0.2}");
            }
            */
            /*
            for (int i = 45; i >= 25; i--)
            {
                Console.WriteLine($"{i}\t{i - 0.5}\t{i - 0.8}");
            }
            */
            /*
            double narx = 12200;
            for(int i=50;i<=1000;i+=50)
            {
                Console.WriteLine($"{i} tasi: {i*narx} so'm");
                // sikl uzunligi: (stop-start+1)/h=(1000-50+1)/50=19+1/50 =>20
            }
            */
            /*
            for(int i=2; i<10;i++)
            {
                for(int j=1; j<10; j++)
                {
                    Console.WriteLine($"{i}x{j}={i*j}");
                }
                Console.WriteLine();
            }
            */
            /*
            for(int i=44; i<=64; i+=2)
            {
                Console.Write($"{i/10.0}  ");
            }
            */
            while (true)
            {
                Console.WriteLine("\nMatn kiriting:");
                string matn = Console.ReadLine();//"abcde";
                string yarim1 = "";
                string yarim2 = "";

                int n = matn.Length;

                for (int i = 0; i < n / 2; i++)
                {
                    yarim1 += matn[i]; //ab
                    yarim2 += matn[n - 1 - i]; // ed
                }
                if (yarim1 == yarim2)
                {
                    Console.WriteLine($"{matn} - palindrom");
                }
                else
                {
                    Console.WriteLine("Palindrom emas!");
                }
            }

        }
    }
}
