using System;
using System.Security.Cryptography;

namespace Maxmud5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*if(shart)
            {
                Shart Bajarilganda
            }
            else
            {
                Shart Bajarilmaganda
            }*/

            double a, b, c;

            Random tasodifiy = new Random();

            a = tasodifiy.Next(-100, 101);
            b = tasodifiy.Next(-100, 101);
            c = tasodifiy.Next(-100, 101);
            Console.WriteLine($"a ={a}\t b={b}\t c={c}");
            // 3 5 7
            // max = 3
            double max = a;

            if (b>max) // 5>3 -> true
            {  max = b;  } // max=5

            if(c>max) // 7>5 -> true
            {  max = c;  } // max = 7

            Console.WriteLine($"katta son: {max}");

            double min = a;

            if (b < min) // 5>3 -> true
            { min = b; } // max=5

            if (c < min) // 7>5 -> true
            { min = c; } // max = 7

            Console.WriteLine($"kichik son: {min}");

            double yigindi = a + b + c;
            Console.WriteLine($"yigindi: {yigindi}");
            Console.WriteLine($"Eng katta sonlar yigindisi: {yigindi-min}");
            Console.WriteLine($"Eng kichik sonlar yigindisi: {yigindi - max}");

            /*while (true)
        {
            Console.Write("\nSon kiriting: ");
            int son = int.Parse(Console.ReadLine());

            if (son % 2 == 0 && son>0)
            {
                Console.WriteLine($"{son} juft son");
            }
            else if(son>0)
            {
                Console.WriteLine($"{son} toq son");
            }
            else
            {
                Console.WriteLine($"{son}");
            }
        }*/
        }
    }
}
