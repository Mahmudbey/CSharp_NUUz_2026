using System;

namespace Maxmud10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            while (true)
            {
                Random r = new Random();
                double a = r.Next(10, 101);
                double b = r.Next(2, 11);
                Console.WriteLine($"a={a}\tb={b}");

                int k = 0;

                while (a >= b)
                {
                    k++; // k += 1;
                    a -= b; // a = a - b;
                }
                string javob = $"a kesmada {k} ta {b} uzunlikdagi kesma bor";
                javob += a > 0 ? $" {a} qoldiq kesma qoldi" : "";
                Console.WriteLine(javob);

                Console.WriteLine("Dastur tugatilsinmi?\nHa[H]\tYo'q[Y]");
                string input =  (Console.ReadLine()).ToLower();
                if (input == "h" || input == "ha")
                {
                    break;
                }

            }
            */
            
            // if-else ning qisqaroq yozilishi
            // shart? true holatda: false holatda

            // shart1? true holatda: (shart2? true holatda: false holatda)

            /*
            int k = 0;
            int Max = 3;
            while (true)
            {
                string parol = "Parol123";

                Console.WriteLine("Parolni kiriting: ");
                string input = Console.ReadLine();

                if (input == parol)
                {
                    Console.WriteLine("Xush kelibsiz!");
                    break;
                }
                else
                {
                    k += 1;
                    string s = "Parol noto'g'ri\n";
                    s += Max - k != 0 ? $"Qaytadan kiriting, {Max - k} ta urinish qoldi!\n" : "";
                    Console.WriteLine(s);
                }
                if(k==Max) // k>=Max
                {
                    Console.WriteLine("Tizim bloklandi!");
                    break;
                }
            }
             */
            /*
            int n = 250;
            int s = 0;
            int k = 0;

            while (s<=n)
            {
                k++; 
                s += k;                
            }
            Console.WriteLine($"k={k-1}\ts={s-k}<{n}");
            */
            
        }
    }
}
