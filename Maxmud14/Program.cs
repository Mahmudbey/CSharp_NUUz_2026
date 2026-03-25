using System;

namespace Maxmud14
{
    internal class Program
    {
        static object Qiymatli()
        {
            Console.WriteLine("Returnga qadar");
            return "Qiymatli metod";
            Console.WriteLine("Returndan keyin");
        }
        static double pi()
        {
            return Math.PI; //3.14;
        }
        static object f(int n)
        {
            int p = 1;
            for(int i=1; i<=n; i++)
            {
                p *= i;
            }
            return p;
        }
        static int F(int n)
        {           
            return n==0 || n==1 ? 1:n*F(n-1);
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine(F(5));
            int[,] arr = new int[4, 5]; // Length=4*5=20
            double[,] arr2 = new double[10, 6];
            Random r =new Random();

            for(int i=0;i<arr.GetLength(0); i++)
            {
                for(int j=0; j<arr.GetLength(1);j++)
                {
                    arr[i, j] = r.Next(-10,51);
                    // Console.Write(arr[i,j]+"\t");
                }
               // Console.WriteLine();
            }

            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j] = r.Next(-10, 51);
                    // Console.Write(arr[i,j]+"\t");
                }
                // Console.WriteLine();
            }


            double[] m1 = new double[20];
            double[] m2 = new double[25];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                    m1[i] = r.Next(-100, 101);
            }
            for (int i = 0; i < m2.GetLength(0); i++)
            {
                m2[i] = r.Next(-100, 101);
            }

            // Console.WriteLine(m1);
            // Chop2(m1);
            // Console.WriteLine("\n\n");
            // Chop3(m2);
            // Chop1(arr);
            // Chop1(arr2);

            // Console.WriteLine(Qiymatli()); // string

            // Console.WriteLine(pi());

            Console.WriteLine(f(5));
            object k = f(10);
            Console.WriteLine(k);

            int a = 2;
        }
        
        static void Chop1<T>(T[,] massiv)
        {
            for (int i = 0; i < massiv.GetLength(0); i++)
            {
                for (int j = 0; j < massiv.GetLength(1); j++)
                {
                    Console.Write(massiv[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Chop2(Array massiv)
        {
            foreach(var i in massiv)
            {
                    Console.Write(i + "\t");
            }
        }
        static void Chop3(dynamic massiv)
        {
            foreach (var i in massiv)
            {
                Console.Write(i + "\t");
            }
        }
    }
}
