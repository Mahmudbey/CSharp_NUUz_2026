using System;
using static System.Math;

namespace ConsoleApp3
{
    public class Kompleks
    {
        public double Haqiqiy;
        public double Mavhum;
        public Kompleks(double a, double b)
        {
            Haqiqiy = a; Mavhum = b;
        }

        public void Chop()
        {
            string ishora = Mavhum == 0 ? "" : (Mavhum > 0 ? "+" : "-");
            string s = Mavhum == 0 ? $"{Haqiqiy}" : $"{Haqiqiy}{ishora}{Abs(Mavhum)} i";
            Console.WriteLine(s);
        }

        public static Kompleks operator +(Kompleks a, Kompleks b)
        {
            Console.WriteLine("+ amali:");
            Kompleks c = new Kompleks(0, 0);
            c.Haqiqiy = a.Haqiqiy + b.Haqiqiy;
            c.Mavhum = a.Mavhum + a.Mavhum;
            return c;
        }
        public static Kompleks operator -(Kompleks a, Kompleks b)
        {
            Console.WriteLine("- amali:");
            Kompleks c = new Kompleks(0, 0);
            c.Haqiqiy = a.Haqiqiy - b.Haqiqiy;
            c.Mavhum = a.Mavhum - a.Mavhum;
            return c;
        }
        public static Kompleks operator *(Kompleks a, Kompleks b)
        {
            Console.WriteLine("* amali:");
            Kompleks c = new Kompleks(0, 0);
            double h = a.Haqiqiy * b.Haqiqiy + a.Mavhum * b.Mavhum;
            double m = a.Haqiqiy * b.Mavhum - a.Mavhum * b.Haqiqiy;
            c.Haqiqiy = h;
            c.Mavhum = m;
            return c;
        }
        public static Kompleks operator /(Kompleks a, Kompleks b)
        {
            Console.WriteLine(": (/) amali:");
            Kompleks c = new Kompleks(0, 0);
            double maxraj = Pow(b.Haqiqiy, 2) + Pow(b.Mavhum, 2);
            double h = a.Haqiqiy * b.Haqiqiy + a.Mavhum * b.Mavhum;
            double m = a.Mavhum * b.Haqiqiy - a.Haqiqiy * b.Mavhum;
            c.Haqiqiy = h / maxraj;
            c.Mavhum = m / maxraj;
            return c;
        }
    }
}