using System;

namespace Maxmud22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[][] arr1 = { 
                new []{"C#","C++","Java"},
                new []{"HTML","CSS","JavaScript","TypeScript"},
                new []{"Python","Ruby","Go","Rust", "PhP"},
                new []{"LaTeX", "Julia" }
            };
          //  Chop(arr1);

            int[][] arr2 = {
                new []{1,2,3},
                new []{4,5,6,7},
                new []{8,9,10,11,12},
                new []{13,14}
            };
           // Console.WriteLine(arr2.Length);
           // Chop(arr2);

           
            int[,] arr3 = new int[5, 6];
            Toldir(arr3);

            string[,] arr4 = new string[3, 4];
            Random random = new Random();
            for(int i = 0; i < arr4.GetLength(0); i++)
            {
                for (int j = 0; j < arr4.GetLength(1); j++)
                {
                    arr4[i, j] = (random.Next(0, 10)).ToString() ;
                    Console.Write($"{arr4[i, j]}\t");
                }
                Console.WriteLine();
            }

            // Chop(arr3);
            Chop(arr1);
            Chop(arr2);
            Chop(arr4);

        }
    static void Chop(dynamic arr)
        {
            foreach (var i in arr)
            {
                foreach(var j in i)
                {
                    Console.Write($"{j}\t");
                }
                Console.WriteLine();
            }
        }
        static void Chop2<T>(T[][] arr)
        {
            foreach (var i in arr)
            {
                foreach (var j in i)
                {
                    Console.Write($"{j}\t");
                }
                Console.WriteLine();
            }
        }
        static void Toldir(int[,] arr)
        {           
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(-10, 101);
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
