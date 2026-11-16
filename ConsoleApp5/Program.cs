using System;

PC k1 = new PC("Lenovo", 16, 512, "Intel i7");
Gaming g1 = new Gaming("ASUS", 32, 1024, "AMD Ryzen 9", "NVIDIA RTX 3080", 144);

k1.info();
g1.info();
class PC
{
    public string Nom;
    public int RAM;
    public int ROM;
    public string CPU;

    public PC(string nom, int ram, int rom, string cpu)
    {
        Nom = nom;
        RAM = ram;
        ROM = rom;
        CPU = cpu;
    }
    public void info()
    {
        Console.WriteLine($"Kompyuter nomi: {Nom}, RAM: {RAM}GB, ROM: {ROM}GB, CPU: {CPU}\n\n");
    }

}

class Gaming:PC
{
    public string GPU;
    public int RefRate;
    public Gaming(string nom, int ram, int rom, string cpu, string gpu, int refrate) : base(nom, ram, rom, cpu)
    {
        GPU = gpu;
        RefRate = refrate;
    }
    public void info()
    {
        Console.WriteLine($"Gaming kompyuter nomi: {Nom}, RAM: {RAM}GB, ROM: {ROM}GB, CPU: {CPU}, GPU: {GPU}, Refresh Rate: {RefRate}Hz\n\n");
    }
}

/* 
class ClassNomi:TayanchClass
{
    ...
}
*/