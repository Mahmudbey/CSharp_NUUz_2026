using System;

namespace Maxmud17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            int[] son1 = new int[4];
            for(int i=0; i<son1.Length;i++)
            {
                son1[i] = r.Next(-10, 11);
            }
            int[] son2 = new int[6];
            for (int i = 0; i < son2.Length; i++)
            {
                son2[i] = r.Next(-10, 11);
            }
            int[] son3 = new int[2];
            for (int i = 0; i < son3.Length; i++)
            {
                son3[i] = r.Next(-10, 11);
            }
            int[] son4 = new int[10];
            for (int i = 0; i < son4.Length; i++)
            {
                son4[i] = r.Next(-10, 11);
            }

            int[][] sonlar2 = new int[][] { son1, son2, son3, son4 };

           

           foreach(var i in sonlar2)
            {
                foreach(int j in i)
                {
                    Console.Write($"{j}\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < sonlar2.GetLength(0); i++)
            {
                for (int j = 0; j < sonlar2[i].Length; j++)
                {
                    Console.Write($"{sonlar2[i][j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
