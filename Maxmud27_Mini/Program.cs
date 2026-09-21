using System;

var h1 = new Hisob();
var h2 = new Hisob();
var h3 = new Hisob();
h3.Info();

class Hisob
{
    //maydonlar
    public static int YaratilganSoni;
    public static int OchirilganSoni;
    public static int TirikSoni => YaratilganSoni - OchirilganSoni;

    public Hisob()
    {
        YaratilganSoni++;
    }
    ~Hisob()
    {
        OchirilganSoni++;
    }
    public void Info()
    {
        Console.WriteLine($"Akkauntlar:\n\t yaratildi: {YaratilganSoni} ta\n\t faol: {TirikSoni} ta\n\t o'chirilgan: {OchirilganSoni} ta\n");
    }
}
/*
var m1 = new Mashina();
var m2 = new Mashina();
var m3 = new Mashina();
var m4 = new Mashina();
var m5 = new Mashina();

class Mashina
{
    // maydonlar
    public static int _keyingiRaqam;

    public Mashina()
    { // maydonlarga qiymat uzatish
        _keyingiRaqam++;
        string Nomer = _keyingiRaqam / 10 == 0?"00":(_keyingiRaqam/100==0 ? "0" : "");
        Nomer += _keyingiRaqam.ToString();

        Console.WriteLine($"{_keyingiRaqam}-mashinaga:\t \"01 A {Nomer} AA\" nomeri berildi.\n");
    }
}
*/

/*
Talaba t1 = new Talaba("Aliyev Ali");
Talaba t2 = new Talaba("Valiyev Vali");
Talaba t3 = new Talaba("Sultonov Sulton");

Console.WriteLine(Talaba.soni);

class Talaba
{
    public string FIO;
    public static int soni;

    public Talaba(string fio)
    {
        FIO = fio;
        soni++;
    }
}
*/