using System;

namespace Maxmud23
{
    internal class Program
    {
        delegate int KvadratDelegate(int x);

        delegate string MatnDel(string s);
        static int Kvadrat(int x) => x * x;

        static string Teskari(string matn)
        {
            string teskariMatn = "";
            for(int i=0; i<matn.Length;i++)
            {
                teskariMatn += matn[matn.Length-1-i];
            }
            return teskariMatn;
        }
        static string Teskari2(string matn) => Teskari(matn);

        static string KattaHarf(string matn) => matn.ToUpper();
        static string KichikHarf(string matn) => matn.ToLower();

        delegate double QoshDel(int n, int m);
        static double funk(int a, int b) => Math.Pow(a,b);

        static void Main(string[] args)
        {
            /*KvadratDelegate kv1 = Kvadrat;
             Console.WriteLine(kv1(10));

            string ism = "AzizBek"; 
            MatnDel d1 = Teskari2;
            MatnDel d2 = KattaHarf;
            MatnDel d3 = KichikHarf;

            Console.WriteLine(d1(ism));
            Console.WriteLine(d2(ism));
            Console.WriteLine(d3(ism));

            QoshDel qoshish = funk;
            Console.WriteLine(qoshish(4, 7));*/

            Func<int, int> funk1 = x => x+=1;
            Func<double, double, double> funk2 = (a,b) => Math.Pow(a, b);

            Console.WriteLine(funk1(0));

            Console.WriteLine(funk2(2,5));

        }
    }
}
