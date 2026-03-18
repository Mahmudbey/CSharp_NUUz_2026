using System;
using System.Dynamic;

namespace Maxmud12
{
    internal class Program
    {
        static void Chop(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}\t");
            }
        }
        static void Main(string[] args)
        {
            /* // 1-masala
             * int n = 20;
             double s = 1;
             Random r = new Random();

             double[] sonlar = new double[n];

             for(int i=0; i<sonlar.Length;i++)
             {
                 sonlar[i] = r.Next(-15, 16);
                 Console.Write($"{sonlar[i]} ");

                 if (sonlar[i] % 2 == 0)
                 {
                     s *= sonlar[i];
                 }
             }
             Console.WriteLine($"\nn={n}\nJuft elem. ko'p.: {s}");
         */

            /*// 2-masala
            int n = 20;
            Random r = new Random();

            double[] sonlar2 = new double[n];

            for (int i = 0; i < sonlar2.Length; i++)
            {
                sonlar2[i] = r.Next(-100, 101);
                Console.Write($"{sonlar2[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i < sonlar2.Length; i++)
            {
                if (sonlar2[i] % 3 == 0 && sonlar2[i] % 5 == 0)
                {
                    Console.WriteLine($"sonlar2[{i}]={sonlar2[i]}");
                }
            }
            */
             // 3-masala
             int n = 10;
             bool bor = false;

             Random r = new Random();
             double[] sonlar3 = new double[n];
             for (int i = 0; i < sonlar3.Length; i++)
             {
                 sonlar3[i] = r.Next(-20, 41);
                // Console.Write($"{sonlar3[i]} ");
             }
             Console.WriteLine();
            for (int i = 0; i < sonlar3.Length-1; i++)
            {
                if (sonlar3[i] * sonlar3[i+1] >0)
                {
                    bor = true;
                    break;
                }
            }
            Console.WriteLine(bor?"Bir xil ishorali sonlar bor": "Bir xil ishorali sonlar yo'q");
            Console.WriteLine(sonlar3);
            Chop(sonlar3);
        }
    }
}
