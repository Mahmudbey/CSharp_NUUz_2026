using System;

namespace Test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Talaba t1 =new Talaba();
            t1.GetInfo();

            Talaba t2 = new Talaba("Abduallayev Aziz");
            t2.GetInfo();

            Talaba t3 = new Talaba("Ergashov Abror", 22);
            t3.SetOTM("O'zMU");
            t3.GetInfo();

            Talaba t4 = new Talaba("Shodmonov Shodmon", 21, 4.5);

            Talaba t5 = new Talaba("Shodmonov Shodmon", 21, 5.0);

            t4.GetInfo();
            t5.GetInfo();


            //Console.WriteLine(t3.GetType());
        }
    }
    
    class Talaba
    {
        public string FIO; // field
        public int Yosh { get; set; } // property
        public string OTM { get; set; } 
        private double _GPA;

        public double GPA
        {
            get { return _GPA; }
            set
            {
                if (value > 0 && value <= 5.0)
                {
                    _GPA = value;
                }
                else
                {
                    throw new ArgumentException("GPA 0 dan katta va 5 kichik bo'lishi kerak!");
                }
            }
        }


        public void SetOTM(string otm)
        {
            OTM = otm;
        }

        public Talaba()
        { }

        public Talaba(string ism)
        {
            FIO = ism;
        }
        public Talaba(string ism, int y)
        {
            FIO = ism;
            Yosh = y;
        }
        public Talaba(string ism, int y, double baho)
        {
            FIO = ism;
            Yosh = y;
            GPA = baho;
        }
        public void GetInfo()
        {
                Console.WriteLine($"FIO: {FIO}, Yosh: {Yosh}, OTM: {OTM}, GPA: {GPA}");
        }
    }
}
