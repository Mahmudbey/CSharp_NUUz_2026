using System;
using System.Runtime.InteropServices;

namespace InH1
{
    internal class A
    {
        static void Main(string[] args)
        {
           // var f1 = new Foydalanuvchi();
            var f2 = new Foydalanuvchi("Aliyev Vali", "bmahmudbey@gmail.com", new DateTime(2000, 10, 25));

            //var m1 = new Moderator();
            var m2 = new Moderator("Aliyev Akrom", "bmahmudbey@gmail.com", new DateTime(2000, 05, 25), "5");

            //f1.info();
            f2.info();
            // m1.info();
            m2.info();
        }
    }
class Foydalanuvchi
    {
        public string FIO;
        public string login; //e-mail;
        public DateTime TugilganSana;
        // ....
        //public Foydalanuvchi()
        //{
        //}
        public Foydalanuvchi(string fio, string log, DateTime tugilganSana)
        {
            FIO = fio;
            login = log;
            TugilganSana = tugilganSana;
        }

        public void info()
        {
            Console.WriteLine("Foydalanuvchi:\t{0}\nLogin:\t{1},\nTugilgan sanasi:\t{2}\n\n",FIO,login,TugilganSana);
        }
    }

    class Moderator:Foydalanuvchi
    {
        public string level;
        // ...
        public Moderator(string fio, string log, DateTime ts, string daraja):base(fio, log, ts)
        {
            level = daraja;
        }
        public void  info()
        {
            Console.WriteLine("Moderator:\t{0}\nLogin:\t{1},\nTugilgan sanasi:\t{2}\nDarajasi:\t{3}\n\n", FIO, login, TugilganSana, level);
        }
        public void info2()
        {
            Console.WriteLine("Moderator:\t{0}\nLogin:\t{1},\nTugilgan sanasi:\t{2}\nDarajasi:\t{3}\n\n", FIO, login, TugilganSana, level);
        }
    }
}
