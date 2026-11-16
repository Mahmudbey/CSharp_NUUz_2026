namespace Modulyar
{
    public class funksiyalar
    {
        public static int mod(int a, int b)
        {
            int c = a % b;
            // Console.WriteLine($"mod({a},{b})={c}");
            return c;
        }
        public static int EKUB(int a, int b)
        {
            int temp;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            // Console.WriteLine($"EKUB({a},{b})={a}");
            return a;
        }
        public static int EKUK(int a, int b)
        {
            int c = (int)(a * b * 1.0 / EKUB(a, b));
           // Console.WriteLine($"EKUK({a},{b})={c}");
            return c;
        }
        public static int mod_daraja(int a, int n, int b)
        {
            int r = (int)Math.Pow(a, n) % b;
            Console.WriteLine($"mod_daraja({a},{n},{b})={r}");
            return r;
        }
        public static int Eyler(int a)
        {
            int s = 0;
            for (int i = 2; i <= a; i++)
            {
                if (EKUB(i, a) == 1)
                {
                    s++;
                }
            }
            // Console.WriteLine($"Eyler({a})={s}");
            return s;
        }
        public static int mod_inv(int a, int b)
        {
            int r = (int)Math.Pow(a, Eyler(b) - 1) % b;
            // Console.WriteLine($"mod_inv({a},{b})={r}");

            return r;
        }

        public static int mod_CRT(int M, int[] m)
        {
            if (m == null || m.Length == 0)
                return M;

            int product = 1;

            foreach (int modulus in m)
            {
                if (modulus <= 0)
                    throw new ArgumentException("All moduli must be positive.", nameof(m));

                product *= modulus;
            }

            int result = 0;

            foreach (int modulus in m)
            {
                int Mi = product / modulus;
                int invMi = modInverse(Mi, modulus);

                result = (result + ((M % modulus) * Mi * invMi)) % product;
            }

            if (result < 0)
                result += product;

            return result;
        }

        private static int modInverse(int a, int mod)
        {
            a %= mod;
            if (a < 0)
                a += mod;

            for (int i = 1; i < mod; i++)
            {
                if ((a * i) % mod == 1)
                    return i;
            }

            throw new InvalidOperationException("No modular inverse exists for the given values.");
        }
    }
}
