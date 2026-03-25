using System;
using System.Collections;

namespace Maxmud13
{
    internal class Program
    {
        /*static void Print1(Array arr)
        {
            foreach(var i in arr)
                Console.Write(i+"\t");
            Console.WriteLine();
        }
        static void Print2(dynamic arr)
        {
            foreach (var i in arr)
                Console.Write(i + "\t");
            Console.WriteLine();
        }
        static void Print3<T>(T[] arr)
        {
            foreach (var i in arr)
                Console.Write(i + "\t");
            Console.WriteLine();
        }
        */
        static void Main(string[] args)
        {
            // tip[] MassivNomi;
            // tip[] MassivNomi = new tip[n];
            /*int[] arr = new int[3];
            arr[0] = 25;
            arr[1] = 50;
            arr[2] = -100;

            Console.WriteLine(arr[1]);*/
            /*
            int[] arr2 = new int[20];
            Random r = new Random();

            for(int i=0; i<arr2.Length; i++)
            {
                arr2[i] = i * i; // r.Next(-100, 101);
                Console.Write($"arr2[{i}]={arr2[i]}\n");
            }
            Console.WriteLine();
            Array.Reverse(arr2);
            for (int i = 0; i < arr2.Length; i++)
            {               
                Console.Write($"arr2[{i}]={arr2[i]}\n");
            }
            */
            /*
            int n = 50;
            int[] Tub = new int[n + 1];
            Tub[0] = -1; Tub[1] = -1;
            //Console.Write("son= ");
            //int a = Convert.ToInt32(Console.ReadLine());
            bool tubmi = true;
            for (int k = 2; k <= n; k++)
            {
                for (int i = 2; i < k; i++)
                {
                    if (k % i == 0)
                    {
                        tubmi = false; break;
                    }
                }
                if (tubmi)
                    Tub[k] = k;
                else
                    Tub[k] = -1;
                tubmi = true;
            }
            for (int i = 0; i < Tub.Length; i++)
            {
                if (Tub[i] == -1) 
                    continue;
                else
                    Console.WriteLine($"Tub[{i}]={Tub[i]}");
            }
            //Console.Write($"a={a} - tub son");
            // Console.Write(tubmi ? "" : " emas!");
            */

            int n = 25;
            int[] massiv = new int[n];
            Random r = new Random();
            int s = 0;
            for(int i=0; i<massiv.Length;i++)
            {
                massiv[i] = r.Next(-10,11);
                Console.Write(massiv[i]+"\t");
                if (massiv[i] % 2 == 1)
                    s += massiv[i];
            }
            Console.WriteLine($"\ns={s}");
            
            
            /*Print1(massiv);
            Print2(massiv);
            Print3(massiv);*/

           /* ArrayList A = new ArrayList();
            A.Add(25);
            A.Add("Salom");
            A.Add(3.14);
            A.Add(true);
            A.Add('$');
            Print2(A);
            Console.WriteLine(A.Count);*/
        }
    }
}
