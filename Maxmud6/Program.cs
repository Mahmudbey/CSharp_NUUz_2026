using System;

namespace Maxmud6
{
    internal class Program
    {
        enum Mavsum4 { qish, bahor, yoz=5, kuz };
        enum Mavsum3 { qish = 10, bahor=20, yoz, kuz };
        enum Mavsum2 { qish=10, bahor, yoz, kuz };
        enum Mavsum { qish, bahor, yoz, kuz };
        enum Oy { yan, fev, mar, apr, may, iyn, iyl, avg, sen, okt, noy, dek };
        static void Main(string[] args)
        {
            Console.WriteLine("Oyni tanlang (0-11 son): ");
            int k = int.Parse(Console.ReadLine());

            Oy o1 = (Oy)k;
            Console.WriteLine(o1);

            Console.Write("Ushbu oyga mos keluvchi fasl:\t");

            switch((int)o1)
            {
                case 0:
                case 1:
                case 11:
                    {
                        Console.WriteLine(Mavsum.qish);
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        Console.WriteLine(Mavsum.bahor);
                        break;
                    }
                case 5:
                case 6:
                case 7:
                    {
                        Console.WriteLine(Mavsum.yoz);
                        break;
                    }
                case 8:
                case 9:
                case 10:
                    {
                        Console.WriteLine(Mavsum.kuz);
                        break;
                    }
            }

            /*Mavsum m1 = Mavsum.yoz;
             Console.WriteLine((int)m1);

            Console.WriteLine((int)Mavsum4.kuz);
            Console.WriteLine((Mavsum4)3);*/

            /*
            Random tasodifiy = new Random();
            int yil = 2000;// tasodifiy.Next(1, 2101); // 506;

            bool kabisa = false; // oddiy yil

            if (yil % 4 == 0)
            { kabisa = true; } // kabisa yil

            if (yil % 100 == 0)
            { kabisa = false; } // oddiy yil 

            if (yil % 400 == 0)
            { kabisa = true; } // kabisa yil

            if ((kabisa))
            {
                Console.WriteLine($"{yil}-yil kabisa yili!");
            }
            else
            {
                Console.WriteLine($"{yil}-yil oddiy yil");
            }
            */

            /* int son = 66;
             switch (son % 2) // 0 yoki 1
             {
                 case 0:
                     {
                         Console.WriteLine($"{son} juft son");
                         break;
                     }
                 case 1:
                     {
                         Console.WriteLine($"{son} toq son");
                         break;
                     }
             }*/
            /*
            double son = 0; // 0.56;
            switch (son > 0)
            {
                case true:
                    {
                        Console.WriteLine($"{son} musbat son");
                        break;
                    }
                case false:
                    {
                        switch(son < 0)
                        {
                            case true:
                                {
                                    Console.WriteLine($"{son} manfiy son");
                                    break;
                                }
                            case false:
                                {
                                    Console.WriteLine($"{son} nolga teng");
                                    break;
                                }
                        }
                        break;
                    }
            }
            */
        }
    }
}