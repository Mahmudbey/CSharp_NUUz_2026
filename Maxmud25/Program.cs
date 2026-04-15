using System;

namespace Maxmud25
{
    internal class Program
    {
        static void Chop<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine("\n\n");
        }
        static void Toldir(int[] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-10, 101);
               // Console.Write(arr[i] + "\t");
            }
           // Console.WriteLine();

        }
        static void Main(string[] args)
        {
            int son = 25;
           // Console.WriteLine(son);

           var son2 = Uzgartir(ref son);
          //  Console.WriteLine(son2);
         //   Console.WriteLine(son);

            int[] sonlar = new int[10];
            Toldir(sonlar); // void

            Chop(sonlar);

            var mass = ToldirSon(sonlar); // int[]
                                          // Chop(mass);
            
           // while (true)
           // {
                Console.WriteLine("n=");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("m=");
                int m = Convert.ToInt32(Console.ReadLine());
                int qoldiq = 0;

                Console.WriteLine(qoldiq);

                Mod(n, m, out qoldiq);
                Console.WriteLine(qoldiq);
            // }

        }
        static void Mod(int a, int b, out int qol)
        {          
            
            if(a*b<0)
            {
                for(int k=1; k<=1000; k++)
                {
                    if (b * k +a >0)
                    {
                        a = b * k +a;
                        break;
                    }
                }
            }
            qol = a - b * (a / b);

        }

        static int Uzgartir(ref int a)
        {
            a += 10;
            return a;
        }
        static int[] ToldirSon(int[] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-10, 101);
             //   Console.Write(arr[i] + "\t");
            }
           // Console.WriteLine();
            return arr;

        }
    }
}
