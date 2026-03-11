using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Maxmud11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int[] sonlar = new int[5] { 100, 200, 300, 400, 500 };
            int n = sonlar.Length;
            
            for (int i = 0; i < n; i++)
            {
                Console.Write(sonlar[n-1-i]+"\t");
            }
            for (int i = n-1; i >=0; i--)
            {
                Console.Write(sonlar[i] + "\t");
            }
            
            double[,] arr = new double[2, 3];
             arr[0, 0] = 1.5;
             arr[0, 1] = 2.5;
             arr[0, 2] = 3.5;
             arr[1, 0] = 4.5;
             arr[1, 1] = 5.5;
             arr[1, 2] = 6.5;*/

            /*
            string[] list1 = new string[2] { "Hello", "take" };
            string[] list2 = new string[2] { "Dear", "Sir" };
            
            int n = list1.Length;
            string[] list3 = new string[n*n];
            for(int i=0; i<n;i++) // 0,1
            {
                for (int j = 0; j < n; j++) // 0,1
                { // i+j = 0+0=0, 0+1=1, 1+0=1, 1+1=2
                  // i*n+j = 0*2+0=0, 0*2+1=1, 1*2+0=2, 1*2+1=3
                    list3[i*n+j] = list1[i] + " " + list2[j];

                }
            }
            
            for (int k = 0; k < list3.Length; k++)
            {
                Console.Write(list3[k]+"\t");
            }
            */
            /*
            string[] list1 = new string[2] { "Hello", "take" };
            string[] list2 = new string[2] { "Dear", "Sir" };
                      
            foreach (string s1 in list1)
            {
                foreach (string s2 in list2)
                {
                    Console.Write(s1 + " " + s2+"\t");
                    // "Hello"
                    // list3[Array.IndexOf(list1, s1) * n + Array.IndexOf(list2, s2)] = s1 + " " + s2;
                }
            }
            */
            // list1 = [10, 20, [300, 400, [5000, 6000], 500], 30, 40]
            // list2 = [10, 20, 300, 400, 5000, 6000, 500, 30, 40]
            List<int> sonlar = new List<int>();
            sonlar.Add(10);
            sonlar.Add(20);
            sonlar.Add(300);
            sonlar.Add(400);
            sonlar.Add(5000);
            sonlar.Add(6000);
            sonlar.Add(500);
            sonlar.Add(30);
            sonlar.Add(40);

            for (int i = 0; i < sonlar.Count; i++)
            {
                Console.Write(sonlar[i] + "\t");
            }
            Console.WriteLine();

            int index = sonlar.IndexOf(6000);
            sonlar.Insert(index+1, 7000);

            for (int i = 0; i < sonlar.Count; i++)
            {
                Console.Write(sonlar[i] + "\t");
            }

        }
    }
}
