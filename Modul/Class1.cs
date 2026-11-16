namespace Modul
{
    public class Funksiyalar
    {
        public static int mod(int a, int b)
        {
            return a % b;
        }
        public static int EKUB(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static int EKUK(int a, int b)
        {
            return (int)(a*b*1.0/EKUB(a,b));
        }
        public static double daraja(int a, int n)
        {
            int s = 1;
            for (int i = 1; i <= n; i++)
                s *= a;
            return s;
        }
        public static int mod_daraja(int a, int n, int b)
        {
            return (int)(daraja(a, n) % b);
        }
        public static int Eyler(int a)
        {
            int s = 0;
            for (int i = 1; i < a; i++)
            {
                if (EKUB(a, i) == 1)
                    s++;
            }
            return s;
        }
        public static int mod_teskari(int a, int b)
        {
            return (int)(daraja(a, Eyler(b)-1) % b);
        }

    }
}
