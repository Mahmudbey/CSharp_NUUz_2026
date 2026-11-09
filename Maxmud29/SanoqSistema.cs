using System;

namespace Maxmud29
{
    class SanoqSistema
    {
        public static void Sanoq(string qiymat, int joriy, int yangi)
        {
            string Son = Convert.ToString(Convert.ToInt64(qiymat, joriy), yangi);
            Console.WriteLine($"{qiymat}_{joriy} -> {Son}_{yangi}");
        }
        public static double Daraja(double asos, double n)
        {
            return Math.Pow(asos, n);
        }
    }
}
