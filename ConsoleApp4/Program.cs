using System;
using System.Runtime.InteropServices;

namespace ConsoleApp4
{
    public class Hisob
    {
        static int Hisob_Soni = 0;
        public string FIO; //maydon - field;
        public string manzil { get; set; } // xususiyat - auto property
        private double _hisob; //yopiq maydon - field;
        public double hisob
        {
            get { return _hisob; }
            set
            {
                if(value >0)
                    _hisob = value;
                else
                    Console.WriteLine("Musbat qiymat kiriting!");
            }
        } // property - xususiyat

        public Hisob() { Hisob_Soni++; }
        public Hisob(string FIO, string manzil, double hisob)
        {
            this.FIO = FIO;
            this.manzil = manzil;
            this.hisob = hisob;
            Hisob_Soni++;
        }

        public void Info()
        {
            // Console.WriteLine($"\n{Hisob_Soni} - akkaunt ma'lumotlari");
            Console.WriteLine($"Hisob egasi:\t{FIO},\n Manzili:\t{manzil},\n Balans:\t{hisob}\n\n");
        }

        public void Qoshish(double summa)
        {
            _hisob = summa>0 ? _hisob + summa : _hisob;
            Console.WriteLine($"Balansga {summa} qo'shildi");
        }
        public void Chiqarish(double summa)
        {
            if(summa > 0 && summa <= _hisob)
            {
                _hisob -= summa;
                Console.WriteLine($"Balansdan {summa} yechildi");
            }
            else
            {
                Console.WriteLine("Balansda mablag' yetarli emas!");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var h1 = new Hisob("Aliyev Ali", "Toshkent shahar", -100);
            var h2 = new Hisob("Valiyev Vali", "Samarqand shahar", 1000);
            h1.Info();
            h2.Info();

            h1.Qoshish(500);
            h1.Qoshish(100);
            h1.Chiqarish(250);
            h1.Info();

            h2.Chiqarish(100);
            h2.Chiqarish(350);
            h2.Info();
        }
    }
}
