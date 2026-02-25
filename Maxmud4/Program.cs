using System;

namespace Maxmud4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 1-Topshiriq:
             Agar tomonlarining uzunliklari ixtiyoriy a, b va c sonlarga teng bo‘lgan uchburchakni qurish mumkin 
bo‘lmasa 0, aks holda – uchburchak teng tomonli bo‘lsa 3, teng yonli bo‘lsa 2 va boshqa hollar uchun 1 
qiymatini chop qiluvchi programma tuzilsin. 
             */
            /*
             while (true)
            {
                double a, b, c;
                // a = 2; b = 5; c = 8;

                Console.Write("1-sonni kiriting: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("2-sonni kiriting: ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("3-sonni kiriting: ");
                c = Convert.ToDouble(Console.ReadLine());

                bool musbat = false;

                if (a > 0 && b > 0 && c > 0)
                    musbat = true;

                bool tengsizlik = false;
                if (a + b > c && a + c > b && b + c > a)
                    tengsizlik = true;

                if (!(musbat && tengsizlik))
                {
                    Console.WriteLine($"{a},{b},{c} - " +
            $"sonlaridan uchburchak qurish mumkin emas!");

                }
                else
                {
                    Console.WriteLine($"{a},{b},{c} - " +
                        $"sonlaridan uchburchak qurish mumkin");

                    if (a==b && b ==c && c==a)
                    {
                        Console.WriteLine("Teng tomonli uchburchak (3)");
                    }
                    else if (a == b || b == c || c == a)
                    {
                        Console.WriteLine("Teng yonli uchburchak (2)");
                    }
                    else
                    {
                        Console.WriteLine("Ixtiyoriy uchburchak (1)");
                    }
                }

                Console.WriteLine("\n\n");

            }
            */

            /* 2-Topshiriq:
             Berilgan yilga mos keluvchi asr nomeri chop etilsin. Bunda quidagi holat inobatga olinsin: masalan, 21 
            asr boshi 2001 yildan hisoblanadi. 
             */

            /*
            1-100 = 1-99 va 100 -> I asr
            101-200 = 101-199 va 200  -> II asr
            ...
            2001-2100 = 2001-2099 va 2100 -> XXI asr
             */
            /*
            while (true)
            {
                Console.Write("Yilni kiriting: ");
                int yil = int.Parse(Console.ReadLine());

                int bolinma = (yil - 1) / 100;
                Console.WriteLine($"{yil}-yil -> {bolinma + 1}-asr\n\n");
            }
            */

            /* 3-Topshiriq:
             Butun n (n>0) va n ta haqiqiy sonlar berilgan. 
            Ular orasidan manfiylari nechtaligi aniqlansin
            */

            while (true)
            {
                double a1, a2, a3; // a4;

                Console.Write("a1=");
                a1 = double.Parse(Console.ReadLine());
                Console.Write("a2=");
                a2 = double.Parse(Console.ReadLine());
                Console.Write("a3=");
                a3 = double.Parse(Console.ReadLine());

                int sanash = 0;

                if (a1 < 0)
                    sanash++; // sanash = sanash + 1; //
                if (a2 < 0)
                    sanash++; // sanash = sanash + 1; //
                if (a3 < 0)
                    sanash++; // sanash = sanash + 1; //

                Console.WriteLine($"{sanash} ta manfiy son bor\n");
            }
        }
}
}
