using System;

namespace Maxmud15
{
    internal class Program
    {
        static bool Uchburchak(double a, double b, double c)
        {
            bool mumkin = false;
            if (a + b > c && a + c > b && b + c > a && a>0 && b>0 && c>0)
            {
                mumkin = true;
            }
            return mumkin;
        }
        static double Yuzi(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        static void Uchburchak_Yuzi(double a, double b, double c, double d)
        {
            Console.WriteLine($"{a}\t{b}\t{c}\t{d}");
            bool mumkin = Uchburchak(a, b, c) || Uchburchak(a, b, d) || Uchburchak(b, c, d) || Uchburchak(a, c, d);
            if (Uchburchak(a,b,c))
                Console.WriteLine($"Yuza({a},{b},{c})={Yuzi(a,b,c)}");
            if (Uchburchak(a, b, d))
                Console.WriteLine($"Yuza({a},{b},{d})={Yuzi(a, b, d)}");
            if (Uchburchak(b, c, d))
                Console.WriteLine($"Yuza({d},{b},{c})={Yuzi(b, c, d)}");
            if (Uchburchak(a, c, d))
                Console.WriteLine($"Yuza({a},{c},{d})={Yuzi(a, c, d)}");
            if (!mumkin)
                Console.WriteLine("Uchburchak hosil bo'lmaydi");
        }
        static void Main(string[] args)
        {
            Random ob = new Random();
            Uchburchak_Yuzi(ob.Next(-1,1), ob.Next(-1, 11), ob.Next(1, 11), ob.Next(1, 11));
            /*
            double[,] arr = new double[3, 2];

            Random r=new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(-50, 51);
                }
            }
            Chop(arr);

            double[,] arr2 = new double[2,3];
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    // arr2[i, j] = arr[j,i];
                    arr2[i, j] = arr[j, arr.GetLength(1)-1-i];
                }
            }
            Chop(arr2);
            */

        }

        static void Chop<T>(T[,] arr)
        {
            for(int i=0; i<arr.GetLength(0);i++)
            {
                for(int j=0; j<arr.GetLength(1);j++)
                {
                    Console.Write(arr[i, j]+"\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
