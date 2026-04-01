using System;

namespace Maxmud18
{
    public class BoshSinf
    {
        static void Main(string[] args)
        {
            Noutbuk n1 = new Noutbuk("Dell XPS 13", "Intel i7-11800H", "NVIDIA GeForce RTX 3050 Ti", 16, 512);
            n1.Info();

            n1.CPU = "Intel i9-11900H";
            n1.RAM = 32;

            n1.Info();

            Noutbuk n2 = new Noutbuk();
           
            n2.model = "HP Spectre x360";
            n2.CPU = "Intel i5-1135G7";
            n2.GPU = "Intel Iris Xe Graphics";
            n2.RAM = 8;
            n2.ROM = 256;

            n2.Info();

            Noutbuk n3 = new Noutbuk("MSI GF 76 Katana");

            n3.Info();

        }
    }

    public class Noutbuk
    {
        /*
         Model nomi - Dell XPS 13, HP Spectre x360, Lenovo ThinkPad X1 Carbon
         Protsessor - intel i3,i5, i7, i9; AMD Ryzen 3, 5, ...
         Operativ xotira (RAM) - 4GB, 8GB, 16GB, 32GB
         Doimiy xotira (HDD, SSD) - 128GB, 256GB, 512GB, 1TB
         Video kartasi (NVIDIA, AMD, Intel)
        Processor i7-11800H
        Video karta	NVIDIA GeForce RTX 3050 Ti

        */
       public string model;
       public string CPU;
       public string GPU;
       public int RAM;
       public int ROM;

        public Noutbuk() { } // konstruktor
        public Noutbuk(string nomi, string prot, string vkarta, int oper, int doim)
        {
            this.model = nomi;
            this.CPU = prot;
            this.GPU = vkarta;
            this.RAM = oper;
            this.ROM = doim;
        }
        public Noutbuk(string nomi)
        {
            this.model = nomi;
        }

        public void Info()
        {
            string info = $"\nModel: {model}";
            info += $"\nCPU: {CPU}\nGPU: {GPU}\nRAM: {RAM} GB\nROM: {ROM} GB\n";

            Console.WriteLine(info);
        }

    }

}
