using System;

namespace Maxmud2
{
     class Maxmud
    {
        static void Main(string[] args)
        {
            // 28/01/2026
            // Console.WriteLine("Salom, dunyo!");
            /*
              Console.Write("\"WRITE\"\n");
            Console.WriteLine("Xayr, dastur yopiladi.");
            
            Console.WriteLine("Matn kiriting: ");
            string m1 = Console.ReadLine();
            Console.WriteLine("Siz kiritgan matn: ");
            Console.WriteLine(m1);
            */
            // konvert tipidagi misol
            /*
            Console.WriteLine("Og'irlikni kilogrammda kiriting: ");

            double kg = Convert.ToDouble(Console.ReadLine()); // 5785; // kilogramm // 1 va "1"
            double tonna = kg / 1000; // tonnaga o'tkazish
            Console.WriteLine("Og'irlik kilogrammda: " + kg+"kg\nOg'irlik tonnalarda: " + tonna+"t");
            */

            // Qoplash masalasi
            /*
            int eni = 130; // mm
            int boyi = 543; // mm
            int kv = 130; // mm

            int yuza1 = eni * boyi;
            int yuza2 = kv * kv;

            double n = yuza1*1.0 / yuza2; // 6.75
            // eski versiyalarda: 27/4 = 6    .75
            int m = (int)n;
            double qoldiq = n - m*1.0;

            Console.WriteLine("m=" + m+"\nqoldiq="+qoldiq);
            */

            // xonali sonlar
            // 100 -- 999
            // 4/3 = 1.33333...
            // 5%3 = 2
            // 37%4 = 1
            // % - bo'lgandagi qoldiq
            /*
            Console.WriteLine("3 xonali son kiriting:");
            int son = Convert.ToInt32(Console.ReadLine()); // 386 va "386";
            // 258
            int bir = son%10;  
            int un = (son/10)%10; // 258/10 = 25      .8; son/10
            int yuz = son/100; // 258/100 = 2        .58; (son/100)%10

            // yuz*100 + un*10 + bir*1 = son
            int son2 = yuz * 100 + un * 1 + bir * 10 ;

            Console.WriteLine($"son={son}\tson2={son2}");

            int yigindi = bir + un + yuz;
            int kopaytma = bir * un * yuz;

            // Console.WriteLine($"son={son}\nbir={bir}\no'n={un}\nyuz={yuz}");
            // Console.WriteLine($"yig'indi={yigindi}\nko'paytma={kopaytma}");
            */

            // 04/02/2026
            /*
            int n, m;
            m = 42; n = 8;
            if (m % n == 0) // True, False
            {
                Console.WriteLine($"{m}/{n} = {m / n}");
            }
            else 
            { 
                Console.WriteLine($"{m} soni {n} soniga bo'linmaydi.");
            }
            */
            /*
            Console.Write("Ikki xonali son kiriting: ");
            int son = Convert.ToInt32(Console.ReadLine()); // 78;

            Console.Write("a sonini kiriting: ");
            int a = Convert.ToInt32(Console.ReadLine()); // 9;

            int bir = son % 10;
            int un = son / 10; // 7.8

            int yigindi = bir+un;
            int kopaytma = bir*un;
            if(yigindi%3 == 0)
                Console.WriteLine($"yig'indisi 3 ga bo'linadi.");
            else
                Console.WriteLine($"3 ga bo'linmaydi.");

            if(kopaytma%a == 0)
                Console.WriteLine($"ko'paytmasi {a} ga bo'linadi.");
            else
                Console.WriteLine($"{a} ga bo'linmaydi.");
            */

            /*
            Console.Write("Uch xonali son kiriting: ");
            int son = Convert.ToInt32(Console.ReadLine());

            int bir = son % 10;
            int yuz = son / 100;
            if(bir == yuz)
            {
                Console.WriteLine($"{son} - palindrom son");
            }
            else
                Console.WriteLine($"{son} - oddiy son");
            // 121 232 585 707 989 555 ....
            */

            /*
            int a, b, c;
            a = 48; b = -88; c = 2;

            int yigindi = a + b + c;

            int max = a;       
            if (max < b) // False
                max = b;
            if (max < c) // False
                max = c;

            int min = a;
            if (min > b) // False
                min = b;
            if (min > c) // False
                min = c;
            Console.WriteLine($"min({a}, {b}, {c}) = {min}");
            Console.WriteLine($"max({a}, {b}, {c}) = {max}");

            Console.WriteLine($"Eng katta qiymat: {yigindi-min}");
            Console.WriteLine($"Eng kichik qiymat: {yigindi - max}");
            */

            double a, b, c;
            Console.Write("1-son: ");
            a = Convert.ToDouble(Console.ReadLine()); // 51; 
            Console.Write("2-son: ");
            b = Convert.ToDouble(Console.ReadLine()); // 1.7; 
            Console.Write("3-son: ");
            c = Convert.ToDouble(Console.ReadLine()); // 2.9;

            if (a > 1.6 && a < 3.8) // ||
                Console.WriteLine($"a={a} soni berilgan oraliqda yotadi");
            if (b > 1.6 && b < 3.8) // ||
                Console.WriteLine($"b={b} soni berilgan oraliqda yotadi");
            if (c > 1.6 && c < 3.8) // ||
                Console.WriteLine($"c={c} soni berilgan oraliqda yotadi");




        }
    }
}
