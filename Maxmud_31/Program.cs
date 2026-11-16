
PulYech(500, 150, 1);

PulYech(500, 500,0);

PulYech(500, 5000,1);

void PulYech(double balans, double summa, double foiz)
{
    summa *= (1 + foiz/100); // summa * (1 + foiz);
    try
    {
        if (balans >= summa)
        {
            Console.WriteLine($"Balansdan {summa} so'm yechildi");
            Console.WriteLine($"Hisobda {balans - summa} so'm qoldi!\n");
        }
        else
            throw new Istisno_Balans("\nHisobda pul yetarli emas!", balans, summa, 404);
    }
    catch (Istisno_Balans ex)
    {
        Console.WriteLine($"Xatolik kodi: {ex.Kod}");
        Console.WriteLine($"Xatolik sababi: {ex.nom}");
        Console.WriteLine($"Joriy balans: {ex.JoriyBalans}");
        Console.WriteLine($"Pul yechish summasi: {ex.PulYechish}\n");
        Console.WriteLine("____________________");
    }
    finally
    {
        Console.WriteLine("Operatsiya yakunlandi.");
    }
}


public class  Istisno_Balans:Exception
{
    public string nom;
    public double JoriyBalans;
    public double PulYechish;

    public int Kod;

    public Istisno_Balans(string n, double jb, double py, int k):base(n)
    {
        nom = n;
        JoriyBalans = jb;
        PulYechish = py;
        Kod = k;
    }
}


