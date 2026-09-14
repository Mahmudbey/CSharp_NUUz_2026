using System;

namespace Maxmud26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s1 = new SavingsAccount();
            s1.Balans();

            s1.Deposit(100.0m);
            s1.Balans();

            s1.Deposit(150m);
            s1.Balans();

            s1.PulYechish(120m);
            s1.Balans();

            s1.PulYechish(150m);
            s1.Balans();

        }
    }

    class SavingsAccount
    {
        private decimal _balans;

        public decimal balans => _balans;

        public void Deposit(decimal mablag)
        {
            if (mablag > 0)
            {
                _balans += mablag;
                Console.WriteLine($"Hisobingiz {mablag} so'mga to'ldirildi.");
            }
        }
        public void PulYechish(decimal Mablag)
        {
            if (Mablag <= _balans && Mablag > 0)
            {
                _balans -= Mablag;
                Console.WriteLine($"Hisobingizdan {Mablag} so'm yechildi.");
            }
            else
            {
                Console.WriteLine($"Hisobingizda mablag' yetarli emas");
            }
        }
        public void Balans()
        {
            Console.WriteLine($"Hisobingizda {_balans} so'm bor.\n");
        }
    }
}
