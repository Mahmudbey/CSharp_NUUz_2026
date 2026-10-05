using System;

namespace Sinf_26
{
    class Noutbuk
    {
        string nom; // NOM
        string cpu; // CPU
        int ram; // RAM
        int rom;// ROM
        string gpu;// GPU

        public Noutbuk() { }
        public Noutbuk(string Nom, string Cpu, int Ram, int Rom, string Gpu) 
        { 
            nom = Nom;
            cpu = Cpu;
            ram = Ram;
            rom = Rom;
            gpu = Gpu;
        }
        public Noutbuk(string Nom)
        {
            nom = Nom;
        }

        public void Info()
        {
            Console.WriteLine($"Noutbuk nomi: {nom}");
            Console.WriteLine($"Protsessori: {cpu}");
            Console.WriteLine($"Tezkor xotirasi: {ram} GB");
            Console.WriteLine($"Doimiy xotirasi: {rom} GB");
            Console.WriteLine($"Video kartasi: {gpu}\n");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var n1 = new Noutbuk();
            var n2 = new Noutbuk("Dell XPS", "Intel i7", 16, 512, "NVIDIA RTX 3080");
            var n3 = new Noutbuk("HP");

            n1.Info();
            n2.Info();
            n3.Info();

            var b1 = new BankHisobi("Ali", 1000);
            b1.Balans();

            b1.Kirim(500);
            b1.Kirim(150);
            b1.Chiqim(270);
            b1.Chiqim(1000);
            b1.Kirim(80);
            b1.Balans();

            b1.egasi = "Vali";
            b1.Balans();
        }
    }
class BankHisobi
    {
       public string egasi;
        double balans;

        public BankHisobi() { }
        public BankHisobi(string Egasi, double Balans)
        {
            egasi = Egasi;
            balans = Balans;
        }
        public void Kirim(double pul)
        {
            if (pul > 0)
            {
                balans += pul;
                Console.WriteLine($"Hisobingizga {pul} so'm qo'shildi.");
            }
            else
                Console.WriteLine("Kiritilgan pul miqdori manfiy bo'lishi mumkin emas.");
        }
        public void Chiqim(double pul)
        {
            if (pul > 0 && pul <= balans)
            {
                balans -= pul;
                Console.WriteLine($"Hisobingizdan {pul} so'm yechildi.");
            }
            else
                Console.WriteLine("Kiritilgan pul miqdori manfiy bo'lishi mumkin emas.");
        }
        public void Balans()
        {
            Console.WriteLine($"\n{egasi} hisobi:");
            Console.WriteLine($"Sizning balansingizda:\t{balans} so'm\n");
        }
    }
}
