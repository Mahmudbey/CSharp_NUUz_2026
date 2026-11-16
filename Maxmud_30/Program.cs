Bolish(4, 5);
Bolish(2, 0);
Bolish(3, 5f);

static void Bolish(double a, double b)
{
    double s = 0;
    try
    {
        s = a / b;
        if (b == 0)
            throw new DivideByZeroException("Maxraj 0! Boshqa son kiriting!");
    }
    catch (DivideByZeroException istisno0)
    {
        Console.WriteLine(istisno0.Message);
    }
    /*catch (Exception istisno1)
    {
        Console.WriteLine($"{istisno1.GetType()}\t{istisno1.Message}");
    }*/

    finally
    {
        Console.WriteLine($"s={s}\nDastur yakunlandi\n");
    }
}