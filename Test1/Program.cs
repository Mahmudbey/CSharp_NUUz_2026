using System;
using System.Collections.Generic;
using System.Linq;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                talaba t1 = new talaba();

                // Dastlabki holatni chiqarish
                t1.GetInfo();

                t1.Name = "Ali";
                t1.Age = 20;

                t1.Grades = new Dictionary<string, int>
                {
                    {"Math", 90},
                    {"Physics", 85},
                    {"Chemistry", 95}
                };

                t1.GetInfo();

                // Xatolikni tekshirish (151 yosh xato berishi kerak)
                // t1.Age = 151; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }

        class talaba
        {
            private string _name = "Noma'lum";
            private int _age = 18;
            private Dictionary<string, int> _grades = new Dictionary<string, int>();

            public string Name
            {
                get { return _name; }
                set { _name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException("Ism bo'sh bo'lmasin"); }
            }

            public int Age
            {
                get { return _age; }
                set { _age = (value > 0 && value <= 150) ? value : throw new ArgumentOutOfRangeException("Yosh 1 va 150 oralig'ida bo'lishi kerak"); }
            }

            public Dictionary<string, int> Grades
            {
                get { return _grades; }
                set
                {
                    if (value == null) throw new ArgumentNullException(nameof(value));

                    // Yangi kelayotgan lug'at (value) ichidagi ma'lumotlarni tekshiramiz
                    foreach (var item in value)
                    {
                        if (string.IsNullOrWhiteSpace(item.Key) || item.Value < 0 || item.Value > 100)
                        {
                            throw new ArgumentException("Fan nomi bo'sh bo'lmasligi va baho 0-100 oralig'ida bo'lishi shart");
                        }
                    }
                    _grades = value;
                }
            }

            public void GetInfo()
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine($"Talaba: {Name}, Yoshi: {Age}");

                if (_grades != null && _grades.Count > 0)
                {
                    Console.WriteLine("Baholari:");
                    foreach (var grade in _grades)
                    {
                        Console.WriteLine($"  - {grade.Key}: {grade.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("Baholar hali kiritilmagan.");
                }
                Console.WriteLine("-------------------------");
            }
        }
    }
}