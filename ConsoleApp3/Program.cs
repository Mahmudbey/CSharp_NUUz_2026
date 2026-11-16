using System;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var k1 = new Kompleks(3,4);
            var k2 = new Kompleks(-5, 7);
            var k3 = new Kompleks(0, -8);

            var k4 = new Kompleks(0,0);

            k1.Chop(); k2.Chop(); k3.Chop();

            k4 = k1 + k2;
            k4.Chop();

            k4 = k1 - k2;
            k4.Chop();

            k4 = k1 * k2;
            k4.Chop();

            k4 = k1 / k2;
            k4.Chop();
        }
    }
}
