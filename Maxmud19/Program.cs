using System;

namespace Maxmud19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[][] MatnMassiv = { 
                new []{"C#","Python","Java"},
                new []{"C++","Go"},
                new []{"SQL","HTML","CSS","Markdown"}
            };
            //Chop(MatnMassiv);

            int[][] SonMassiv =
            {
                new []{1,2 },
                new []{3,4,5 },
                new []{ 0,-1,-8, 4},
                new []{3,5,8 }
            };
            Chop2(SonMassiv);

            
        }

        static void Chop2(int[][] arr)
        {
            foreach (var i in arr)
            {
                foreach (var j in i)
                {
                    Console.Write(j + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Chop(object[][] arr)
        {
            foreach (var i in arr)
            {
                foreach (var j in i)
                {
                    Console.Write(j + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
