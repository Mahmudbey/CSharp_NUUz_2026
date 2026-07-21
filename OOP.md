# OOPning 4 Tamoyili

> **Feynman Usuli · Grafik · C# OOP · v3**
> Real dunyo → Kod. Grafik tushuntirishlar. 20 ta izohli test.

⏱ ~120 min &nbsp;|&nbsp; 💻 40+ misol &nbsp;|&nbsp; 🧠 Feynman &nbsp;|&nbsp; 🧪 20 ta test

---

## Mundarija

| # | Bo'lim |
|---|--------|
| 1 | [Inkapsulyatsiya — "Himoya qil"](#1-inkapsulyatsiya) |
| 2 | [Vorislik — "Takrorlama"](#2-vorislik) |
| 3 | [Polimorfizm — 5 real misol](#3-polimorfizm) |
| 4 | [Abstraktsiya — "Yashir"](#4-abstraktsiya) |
| 5 | [Sintez — 4 tamoyil birgalikda](#5-sintez) |
| ★ | [20 ta izohli test](#20-ta-izohli-test) |

---

## 1. Inkapsulyatsiya

> *"Ob'yektning ichini himoya qil — faqat nazorat qilingan eshiklar orqali kir."*

### 💡 Feynman Usuli

> **"ATM da tugmalarni bosasiz — pul chiqadi. Ichki mexanizm yashirilgan. Agar ATM qopqog'i ochiq bo'lsa — falokat."**
>
> **Dasturda:** Maydonlar (`private`) = ATM ichidagi mexanizm. Metodlar/Xususiyatlar (`public`) = Tugmalar.

---

### 📖 Batafsil tushuntirish (Uzbekcha)

**Inkapsulyatsiya** — bu ob'yektning ichki holatini (ma'lumotlarini) tashqi muhitdan himoya qilish tamoyili. Quyidagi fikrlarni eslab qoling:

**Nima uchun inkapsulyatsiya kerak?**

Tasavvur qiling: bank hisobidagi balans raqami hech qanday nazoratisiz ochiq bo'lsa (`public`), istalgan kod `hisob.Balans = -999999` deb yozishi mumkin. Bu — falokat. Inkapsulyatsiya aynan shu muammoni hal qiladi.

**Uchta muhim qoida:**

1. **Maydonlarni (`fields`) `private` qiling** — ularni bevosita o'zgartirib bo'lmaydi.
2. **Kirishni metodlar yoki `property` orqali ta'minlang** — har o'zgarishda tekshiruv bo'ladi.
3. **Invariantlarni (buzilmaydigan qoidalarni) kafolatlang** — masalan, HP hech qachon 0 dan past bo'lmaydi.

**Kirish modifikatorlari:**

| Modifikator | Ko'rinish doirasi |
|-------------|-------------------|
| `private` | Faqat sinf ichida |
| `protected` | Sinf va vorislar ichida |
| `internal` | Faqat loyiha ichida |
| `public` | Hamma joydan |

**Real hayot misollari:**
- 🏦 **Banklarda** — balans `private`. Faqat rasmiy tranzaksiya orqali. Har o'zgarish logda.
- 🔐 **Autentifikatsiya** — parol hesh ko'rinishida. Faqat `ParolHaqiqiyMi()` orqali tekshiriladi.
- 🎮 **O'yinlarda** — HP `private`. Faqat `ZararOl()` va `Davolash()` orqali. `Math.Max(0,...)` kafolat.
- 🌡️ **Smart qurilmalar** — harorat diapazoni nazorat qilinadi. Manfiy yoki juda yuqori bo'lmaydi.

**Inkapsulyatsiyasiz va bilan farq:**

```
❌ Inkapsulyatsiyasiz (xavfli):
    public int _tezlik;          → m._tezlik = 999;  // limit yo'q!
    public double _yonilgi;      → m._yonilgi = -50; // manfiy!
    public string _model;        → m._model = null;  // crash!

✅ Inkapsulyatsiya bilan (xavfsiz):
    private int _tezlik = 0;
    void Tezlash(int n) { if(n > 0 && _tezlik + n <= 200) _tezlik += n; }
    // Har o'zgarish tekshiriladi — xavfsiz!
```

---

### Misol 1 — 🏦 BankHisobi

Balans hech qachon to'g'ridan-to'g'ri o'zgartirilmaydi. Faqat nazoratli metodlar orqali.

```csharp
public class BankHisobi
{
    private decimal _balans;
    private readonly string _raqam;

    public BankHisobi(string raqam, decimal boshlang)
    {
        if (boshlang < 0) throw new ArgumentException("Manfiy bo'lmasin!");
        _raqam = raqam; _balans = boshlang;
    }
    public decimal Balans => _balans;   // faqat o'qish

    public void PulSolish(decimal m) {
        if (m <= 0) throw new ArgumentException("Musbat bo'lsin!");
        _balans += m;
    }
    public bool PulYechish(decimal m) {
        if (m <= 0 || m > _balans) return false;
        _balans -= m; return true;
    }
    // h._balans = -999; ← ❌ XATO! private
}
```

### Misol 2 — 🎮 Qahramon HP

```csharp
public class Qahramon {
    private int _hp, _maks;
    public string Ismi { get; }
    public int    HP    => _hp;
    public bool   TiriMi => _hp > 0;
    public Qahramon(string n, int m)
    { Ismi=n; _maks=m; _hp=m; }
    public void Zarar(int z)
        => _hp = Math.Max(0, _hp - z);
    public void Davolash(int d)
        => _hp = Math.Min(_maks, _hp + d);
    // qahramon.HP=-999; ← private!
}
```

### Misol 3 — 🔐 ParolMenejeri

```csharp
public class ParolMenejeri {
    private readonly string _hesh;
    public ParolMenejeri(string parol) {
        if (parol.Length < 8)
            throw new ArgumentException("Min 8 belgi!");
        _hesh = parol.GetHashCode().ToString();
    }
    // Parol HECH QACHON chiqmaydi!
    public bool ParolHaqiqiyMi(string p)
        => p.GetHashCode().ToString() == _hesh;
}
```

### Misol 4 — 🔒 Parol xavfsizligi (`_hash` va `_salt` private)

Tashqi kod parolni **ko'ra olmaydi** — faqat `ParolHaqiqiyMi()` orqali tekshira oladi.

```csharp
public class ParolXavfsizligi {
    private string _hash;   // 🔒 hech qachon tashqariga chiqmaydi
    private string _salt;   // 🔒 har foydalanuvchi uchun noyob

    public ParolXavfsizligi(string parol) {
        _salt = Guid.NewGuid().ToString();
        _hash = Heshla(parol + _salt);      // tekshiruv bilan
    }

    public void ParolOzgartir(string yangi) {
        if (yangi.Length < 8) throw new ArgumentException("Min 8 belgi!");
        _salt = Guid.NewGuid().ToString();
        _hash = Heshla(yangi + _salt);      // yangi hash yaratiladi
    }

    public bool ParolHaqiqiyMi(string p) =>
        Heshla(p + _salt) == _hash;         // faqat true/false qaytadi

    private string Heshla(string m) {       // private — faqat ichkarida
        var bytes = System.Security.Cryptography.SHA256
            .Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(m));
        return Convert.ToBase64String(bytes);
    }
}
// pm._hash                    ← ❌ XATO! private
// pm.ParolHaqiqiyMi("to'g'ri parol") → true  ✅
// pm.ParolHaqiqiyMi("xato parol")    → false ✅
```

> **🔑 Inkapsulyatsiya qoidasi:**
> - Maydonlar → `private`
> - O'qish uchun → `{ get; }` yoki `=> _maydon`
> - Yozish uchun → tekshiruv bor metod/xususiyat
> - Invariantlar → konstruktorda va metodlarda kafolatlanadi

---

## 2. Vorislik

> *"Umumiy xususiyatlarni baza sinfda yig'ib, vorislar faqat o'ziga xos narsalarni qo'ssin."*

### 💡 Feynman Usuli

> **"Barcha uylar: kvartira, villa — eshik, devor, tomga ega. Bu umumiylikni qayta qurmaysiz — 'Uy' tipidan meros olasiz."**
>
> **Is-A testi:** "Shifokor — tibbiy xodimMI?" — Ha ✅ → vorislik. "Mashinada eshik borMI?" — Bu has-a (kompozitsiya).

---

### 📖 Batafsil tushuntirish (Uzbekcha)

**Vorislik** — bir sinf boshqa sinfning xususiyat va metodlarini meros olishi. Bu **"DRY" (Don't Repeat Yourself)** prinsipi amalda.

**Vorislikning 3 asosiy foydasi:**

1. **Kod takrorlanmaydi** — umumiy kod bir joyda, barcha vorislar foydalanadi.
2. **Kengaytirish oson** — yangi tur qo'shish uchun faqat yangi sinf yoziladi.
3. **Polimorfizm uchun asos** — baza sinf tipida istalgan voris ishlatiladi.

**Is-A vs Has-A:**

```
Is-A (vorislik kerak):
  Shifokor IS A TibbiyXodim   ✅ → class Shifokor : TibbiyXodim
  Talaba   IS A Shaxs          ✅ → class Talaba : Shaxs

Has-A (kompozitsiya kerak):
  Mashina HAS A Eshik          ✅ → class Mashina { private Eshik _eshik; }
  Talaba  HAS A Kitob          ✅ → class Talaba  { private List<Kitob> _kitoblar; }
```

**Muhim kalit so'zlar:**

| Kalit so'z | Maqsad | Qaerda ishlatiladi |
|-----------|---------|-------------------|
| `: BazaSinf` | Vorislik e'lon qilish | Sinf sarlavhasida |
| `base(...)` | Baza konstruktorini chaqirish | Voris konstruktorda |
| `virtual` | Voris qayta yozishi mumkin | Baza sinfda |
| `override` | Baza metodni qayta yozish | Voris sinfda |
| `abstract` | Voris ALBATTA yozishi shart | Baza abstract sinfda |
| `sealed` | Vorislikni taqiqlash | Sinfda yoki metodda |

**Universitetdagi rollar ierarxiyasi:**

```
                  ┌──────────────────────┐
                  │   Shaxs (baza sinf)  │
                  │  ismi, yoshi, ID     │
                  │  OziniTanishtir() →  │
                  │  virtual             │
                  └──────────┬───────────┘
          ┌───────────────────┼──────────────────┐
          ▼                   ▼                  ▼
  ┌──────────────┐   ┌──────────────┐   ┌──────────────┐
  │  👨‍🎓 Talaba  │   │ 👩‍🏫 O'qituvchi│   │  🏢 Xodim   │
  │+ kurs, GPA   │   │+ fani, staj  │   │+ lavozim     │
  │+ BahoOlish() │   │+ DarsOlib()  │   │+ IshBoshlash │
  └──────┬───────┘   └──────────────┘   └──────────────┘
         │
         ▼
  ┌──────────────────┐
  │ MagistrantTalaba │
  └──────────────────┘
```

**Liskov Substitution Principle (LSP)** — vorislikning oltin qoidasi:

> **"Voris sinf baza sinf o'rnida har doim ishlashi kerak. BankAccount o'rniga SavingsAccount qo'yilsa — dastur buzilmasin."**

```csharp
// LSP to'g'ri:
BankAccount acc = new SavingsAccount("UZ001", 5_000_000);
acc.Withdraw(100_000);  // ishlashi kerak ✅
acc.Deposit(200_000);   // ishlashi kerak ✅

// LSP buzilishi:
class ReadOnlyAccount : BankAccount {
    public override bool Withdraw(decimal m)
        => throw new NotSupportedException(); // ❌ LSP buziladi!
}
```

---

### Misol 1 — 🏥 TibbiyXodim → Shifokor, Hamshira

```csharp
public abstract class TibbiyXodim {
    public string Ismi    { get; }
    public int    IshStaji { get; }
    protected TibbiyXodim(string n, int s) { Ismi=n; IshStaji=s; }
    public void Tanishtir()
        => Console.WriteLine($"{Ismi} | Staj: {IshStaji} yil");
    public abstract decimal OylikMaosh();
}
public class Shifokor : TibbiyXodim {
    public string Mutaxassislik { get; }
    public Shifokor(string n, int s, string m) : base(n, s) { Mutaxassislik=m; }
    public override decimal OylikMaosh() => 8_000_000 + IshStaji * 200_000;
}
public class Hamshira : TibbiyXodim {
    public Hamshira(string n, int s) : base(n, s) {}
    public override decimal OylikMaosh() => 4_500_000 + IshStaji * 100_000;
}
// Foydalanish:
var dr = new Shifokor("Salimov", 12, "Kardiolog");
dr.Tanishtir();   // baza sinfdan — qayta yozilmadi!
Console.WriteLine(dr.OylikMaosh()); // 10_400_000
```

### Misol 2 — 🏦 Bank hisoblari — LSP bilan vorislik

Har bir hisob `Withdraw()` va `Deposit()` ni o'zi amalga oshiradi, lekin `BankAccount acc` tipida ishlatilganda LSP bajariladi.

```csharp
public abstract class BankAccount {
    protected decimal _balans;
    public string  HisobRaqami { get; }
    public decimal Balans       => _balans;
    protected BankAccount(string r, decimal b) { HisobRaqami=r; _balans=b; }
    public virtual void   Deposit(decimal m)  { if(m>0) _balans+=m; }
    public abstract bool  Withdraw(decimal m);
}

public class SavingsAccount : BankAccount {
    public double FoizStavkasi { get; }    // yillik %
    public int    MuddatKun    { get; }    // pul yechish mumkin bo'lgan kun
    public SavingsAccount(string r, decimal b, double foiz, int kun)
        : base(r,b) { FoizStavkasi=foiz; MuddatKun=kun; }
    public override bool Withdraw(decimal m) {
        if(DateTime.Now.Day < MuddatKun) { Console.WriteLine("Muddat kelganda!"); return false; }
        if(m>_balans) return false;
        _balans -= m; return true;
    }
    public void FoizHisoblash() => _balans *= (decimal)(1 + FoizStavkasi/100);
}

public class CheckingAccount : BankAccount {
    public decimal OverdraftLimit    { get; }   // minusga kirish chegarasi
    public decimal TransaksiyaTolovi { get; }   // har tranzaksiyadan fee
    public CheckingAccount(string r, decimal b, decimal od)
        : base(r,b) { OverdraftLimit=od; TransaksiyaTolovi=500; }
    public override bool Withdraw(decimal m) {
        if(m-_balans > OverdraftLimit) { Console.WriteLine("Overdraft limit oshdi!"); return false; }
        _balans -= m + TransaksiyaTolovi; return true;  // fee ham yechiladi
    }
}

public class CorporateAccount : BankAccount {
    private int _tasdiqDarajasi;
    public CorporateAccount(string r, decimal b, int daraja)
        : base(r,b) { _tasdiqDarajasi=daraja; }
    public override bool Withdraw(decimal m) {
        if(m > 10_000_000 && _tasdiqDarajasi < 3)
        { Console.WriteLine("Direktor tasdiq kerak!"); return false; }
        if(m>_balans) return false;
        _balans -= m; return true;
    }
}

// LSP: BankAccount o'rniga istalgan voris ishlatsa bo'ladi
BankAccount[] hisoblar = {
    new SavingsAccount("SAV-001", 5_000_000, 12.5, 15),
    new CheckingAccount("CHK-001", 2_000_000, 500_000),
    new CorporateAccount("COR-001", 50_000_000, 2),
};
foreach(var h in hisoblar)
    h.Deposit(100_000);  // LSP: barchasi ishlaydi! ✅
```

> **🔑 Vorislik qoidalari:**
> - `is-a` testi: "Bu — ning turiMI?" — ha bo'lsa vorislik to'g'ri
> - `base()` bilan baza konstruktorini chaqiring
> - `abstract` — voris shart yozishi kerak
> - `virtual/override` — ixtiyoriy qayta yozish
> - LSP: voris baza o'rnida bemalol ishlashi shart

---

## 3. Polimorfizm

> *"Bitta buyruq — har bir ob'yekt o'ziga xos natija beradi."*

### 💡 Feynman Usuli

> **"Kassir: 'To'lovni amalga oshir!' deydi. Click, Payme yoki Visa — kassir QAYSI ekanini bilmaydi. U shunchaki chaqiradi."**
>
> **Kuch:** Yangi to'lov (UzCard) qo'shilsa — kassir kodi O'ZGARMAYDI. Faqat yangi sinf yoziladi.

---

### 📖 Batafsil tushuntirish (Uzbekcha)

**Polimorfizm** — yunon tilida "ko'p shakllilik" demak. Dasturlashda: **bitta interfeys — ko'p xil ishlash**.

**Polimorfizmning ikki turi:**

| Tur | Nom | Qanday ishlaydi | Misol |
|-----|-----|-----------------|-------|
| **Compile-time** | Method Overloading | Kompilyator parametr tipiga qarab hal qiladi | `Print(string)` va `Print(int)` |
| **Runtime** | Method Overriding | Dastur ishlayotganda, ob'yekt tipiga qarab | `virtual/override`, `interface` |

**Nima uchun `if-else` dan yaxshiroq?**

```csharp
// ❌ if-else (yomon): Yangi tur → bu kodni o'zgartir!
void Tolash(decimal s, string tur) {
    if (tur == "Click")      { /* Click kodi */ }
    else if (tur == "Payme") { /* Payme kodi */ }
    else if (tur == "Visa")  { /* Visa kodi */ }
    // Yangi UzCard → yana bir else if qo'shish kerak!
}

// ✅ Polimorfizm (yaxshi): Yangi tur → faqat yangi sinf!
void Tolash(TolovTizimi t, decimal s) {
    t.TolovniAmalgaOshir(s); // 1 qator!
    // Yangi UzCard → faqat UzCardTolov sinfi yoziladi
    // Bu kod HECH QACHON o'zgarmaydi!
}
```

**Open/Closed Principle (OCP):**
> "Sinf kengaytirish uchun ochiq, o'zgartirish uchun yopiq bo'lishi kerak."
>
> Polimorfizm — bu prinsiping amaliy ifodasi.

**Runtime polimorfizm qanday ishlaydi:**

```
TolovTizimi t = new ClickTolov();
t.TolovniAmalgaOshir(50_000);

↓ C# runtime da:
  1. t ning haqiqiy tipi: ClickTolov
  2. ClickTolov.TolovniAmalgaOshir() chaqiriladi
  3. Natija: "50000 so'm Click orqali yechildi"
```

**`abstract class` vs `interface` polimorfizmda:**

```
abstract class → bir ierarxiya, umumiy kod ulashish mumkin
interface      → ko'p ierarxiya, faqat shartnoma
```

---

### Misol 1 — 💳 To'lov tizimlari: Click, Payme, Visa

```
┌────────────────┐          ┌──────────────────────┐
│   DO'KON/KASSIR │ ─────▶  │  «abstract»          │
│ t.TolovniAm..() │         │  TolovTizimi         │
└────────────────┘          │  TolovniAmalgaOshir  │
                             │  (decimal) abstract  │
                             └──────────┬───────────┘
                          ┌─────────────┼───────────┐
                          ▼             ▼           ▼
                     ClickTolov   PaymeTolov   VisaTolov
                     (override)   (override)   (override)
```

```csharp
public abstract class TolovTizimi {
    public abstract void TolovniAmalgaOshir(decimal summa);
}
public class ClickTolov : TolovTizimi {
    public override void TolovniAmalgaOshir(decimal summa) =>
        Console.WriteLine($"{summa} so'm Click orqali yechildi.");
}
public class PaymeTolov : TolovTizimi {
    public override void TolovniAmalgaOshir(decimal summa) =>
        Console.WriteLine($"{summa} so'm Payme orqali yechildi.");
}
public class VisaTolov : TolovTizimi {
    public override void TolovniAmalgaOshir(decimal summa) =>
        Console.WriteLine($"{summa} dollar Visa kartasidan yechildi.");
}
// Foydalanish — POLIMORFIZM KUCHI:
TolovTizimi t = new ClickTolov();
t.TolovniAmalgaOshir(50_000);   // bitta qator, har doim ishlaydi!
// Yangi UzCardTolov → bu kod O'ZGARMAYDI!
```

> 💡 `TolovTizimi t` qaysi tizim ekanligini bilmaydi. Runtime da C# o'zi aniqlaydi.

---

### Misol 2 — 📬 Xabar yuboruvchilar: Telegram, Email, SMS

```csharp
public interface IXabarYuboruvchi { void Yubor(string xabar); }

public class TelegramXabar : IXabarYuboruvchi {
    public void Yubor(string x) => Console.WriteLine($"Telegram: {x}");
}
public class EmailXabar : IXabarYuboruvchi {
    public void Yubor(string x) => Console.WriteLine($"Email: {x} pochtaga yuborildi.");
}
public class SmsXabar : IXabarYuboruvchi {
    public void Yubor(string x) => Console.WriteLine($"SMS: {x} telefon raqamiga yuborildi.");
}

List<IXabarYuboruvchi> yuboruvchilar = new()
    { new TelegramXabar(), new EmailXabar(), new SmsXabar() };

foreach (var y in yuboruvchilar)
    y.Yubor("Hisobingiz to'ldirildi!"); // Polimorfik chaqiruv
```

> 💡 Yangi kanal (WhatsApp) qo'shilsa — faqat yangi sinf + listga qo'shish. `foreach` O'ZGARMAYDI!

---

### Misol 3 — 📄 Hisobot eksportchilari: PDF, Excel, JSON

```csharp
public abstract class ReportExporter {
    public abstract void Export(string data);
}
public class PdfExporter   : ReportExporter { public override void Export(string d) => Console.WriteLine("PDF fayl generatsiya qilindi."); }
public class ExcelExporter : ReportExporter { public override void Export(string d) => Console.WriteLine("Excel jadvali shakllantirildi."); }
public class JsonExporter  : ReportExporter { public override void Export(string d) => Console.WriteLine("JSON formatida ma'lumot uzatildi."); }

ReportExporter[] eks = { new PdfExporter(), new ExcelExporter(), new JsonExporter() };
foreach(var e in eks) e.Export("{ employees: [...] }"); // ← polimorfizm!
```

> 💡 **Real hayotda:** Crystal Reports, SSRS, Power BI — bir klik: PDF, Excel, CSV!

---

### Misol 4 — 📋 Logger tizimlari: Fayl, Database, Slack

```csharp
public abstract class Logger {
    public abstract void Log(string message);
}
public class FileLogger     : Logger { public override void Log(string m) => Console.WriteLine($"[Fayl]: {DateTime.Now} - {m}"); }
public class DatabaseLogger : Logger { public override void Log(string m) => Console.WriteLine($"[SQL DB]: Xatolik 'Logs' jadvaliga yozildi: {m}"); }
public class SlackLogger    : Logger { public override void Log(string m) => Console.WriteLine($"[Slack]: Admin kanaliga xabar yuborildi: {m}"); }

var loggerlar = new List<Logger> { new FileLogger(), new DatabaseLogger(), new SlackLogger() };
loggerlar.ForEach(l => l.Log("Kritik xato: DB ga ulanib bo'lmadi!"));
```

> 💡 **Real hayotda:** Serilog, NLog — File, Seq, Splunk, Elasticsearch ga bir vaqtda yozadi.

---

### Misol 5 — 📦 Yetkazib berish: FedEx, DHL, UzPost

```csharp
public interface IShippingProvider {
    decimal CalculateCost(double weight, double distance);
}
public class FedExProvider  : IShippingProvider { public decimal CalculateCost(double w, double d) => (decimal)(w*1.5 + d*0.1);  }
public class DHLProvider    : IShippingProvider { public decimal CalculateCost(double w, double d) => (decimal)(w*2.0 + d*0.05); }
public class UzPostProvider : IShippingProvider { public decimal CalculateCost(double w, double d) => (decimal)(w*0.8 + d*0.02); }

var providers = new List<IShippingProvider>
    { new FedExProvider(), new DHLProvider(), new UzPostProvider() };

// Eng arzonini polimorfizm orqali topamiz:
var eng_arzon = providers.MinBy(p => p.CalculateCost(2.0, 500));
Console.WriteLine(eng_arzon?.GetType().Name); // UzPostProvider!

// Natijalar: vazn=2kg, masofa=500km
// FedEx:   2*1.5 + 500*0.1  = 53.0 USD
// DHL:     2*2.0 + 500*0.05 = 29.0 USD
// UzPost:  2*0.8 + 500*0.02 = 11.6 USD ← ENG ARZON!
```

> 💡 **Real hayotda:** Amazon, Uzum Bazar — FedEx API, DHL API barchasi bitta interfeys orqali.

> **🔑 Polimorfizm qoidalari:**
> - `abstract class` + `override` → runtime polimorfizm
> - `interface` → ko'p polimorfizm (bir sinf ko'p interfeys)
> - `foreach` + baza tip → polimorfik aylanma
> - Yangi tur → yangi sinf, mavjud kod O'ZGARMAYDI (OCP)

---

## 4. Abstraktsiya

> *"Foydalanuvchiga faqat keraklisini ko'rsat — ichki murakkablikni yashir."*

### 💡 Feynman Usuli

> **"Avtomobil: gaz, tormoz, rul — 3 element ko'rasiz. Dvigatel, uzatma, 1000 detal — YASHIRIN."**
>
> **Farq:** Abstraktsiya — "NIMA qiladi?" (interfeys). Inkapsulyatsiya — "QANDAY qiladi?" (yashirish).

---

### 📖 Batafsil tushuntirish (Uzbekcha)

**Abstraktsiya** — murakkab tizimdan faqat muhim qismlarini ko'rsatib, ortiqcha tafsilotlarni yashirish.

**Abstraktsiyaning 2 asosiy vositasi:**

| Vosita | Xususiyat | Qachon ishlatiladi |
|--------|-----------|-------------------|
| `interface` | Faqat metod imzolari, no'l kod | Ko'p tur uchun shartnoma, DI |
| `abstract class` | Qisman implementatsiya + majburiy metodlar | Umumiy kodli ierarxiya |

**Interface vs Abstract Class farqi:**

```
Interface:
  ✅ Ko'p interfeys mumkin: class A : IB, IC, ID
  ✅ Faqat shartnoma — hech qanday kod yo'q
  ❌ Maydonlar bo'lmaydi (C# 8 dan oldin)
  ❌ Konstruktor yo'q

Abstract Class:
  ✅ Umumiy kod ulashish mumkin
  ✅ Maydonlar, konstruktorlar bor
  ❌ Faqat bitta vorislik
  ❌ Abstract sinfdan ob'yekt yaratib bo'lmaydi
```

**Abstraktsiya qatlamlari (real loyihada):**

```
Foydalanuvchi kodi:
    IPrinter printer = new LazerPrinter();
    printer.Print("Hujjat");          ← faqat shu ko'rinadi

LazerPrinter (yashirilgan):
    private void TonerIsitish() { ... }
    private void Uzatish(string h) { ... }
    private void Qotirish() { ... }   ← bular yashirilgan
```

**Dependency Injection va abstraktsiya:**

```csharp
// Abstraktsiya + DI = sinovdan o'tkazish oson dastur
public class TalabaXizmati {
    private IOmbor<string> _ombor;
    public TalabaXizmati(IOmbor<string> ombor) { _ombor = ombor; }
    public void Qoshish(string id, string ismi) { _ombor.Saqlash(id, ismi); }
}
// Test uchun:        new TalabaXizmati(new XotiradagiOmbor())
// Produksiyada:      new TalabaXizmati(new SqlOmbor())
// Hujjat uchun:      new TalabaXizmati(new FaylOmbor())
// — BITTA QOL HAM O'ZGARMAYDI!
```

---

### Misol 1 — 🖨️ IPrinter — foydalanuvchi faqat `Print()` ko'radi

```csharp
public interface IPrinter {
    void   Print(string hujjat);
    bool   TayorMi { get; }
}
public class LazerPrinter : IPrinter {
    private int _qogoz = 500;
    public bool TayorMi => _qogoz > 0;
    public void Print(string h) {
        if (!TayorMi) { Console.WriteLine("Tayyor emas."); return; }
        TonerIsitish(); Uzatish(h); Qotirish(); // ← foydalanuvchi bilmaydi!
        _qogoz--;
        Console.WriteLine($"✅ '{h}' chop etildi.");
    }
    private void TonerIsitish() => Console.WriteLine("  [Toner...]");
    private void Uzatish(string h) => Console.WriteLine($"  ['{h}'...]");
    private void Qotirish() => Console.WriteLine("  [Qotirish...]");
}
IPrinter p = new LazerPrinter();
if (p.TayorMi) p.Print("Semestr jadvali");
```

> **🔑 Abstraktsiya qoidalari:**
> - `interface` — "NIMA qiladi?" shartnoma
> - `abstract class` — umumiy logika + majburiy metodlar
> - Foydalanuvchi faqat ommaviy API ni ko'radi
> - Ichki murakkablik — `private` metodlar ichida yashirilgan
> - DI orqali implementatsiyani almashtirish oson

---

## 5. Sintez

> *4 tamoyil birgalikda: [I]nkapsulyatsiya + [V]orislik + [P]olimorfizm + [A]bstraktsiya*

### 📖 Batafsil tushuntirish (Uzbekcha)

Haqiqiy loyihalarda 4 ta tamoyil bir-birini to'ldiradi:

```
[A] Abstraktsiya  → Interfeys/shartnoma yaratadi
[V] Vorislik      → Umumiy kodni ulashadi
[I] Inkapsulyatsiya → Ichki holatni himoya qiladi
[P] Polimorfizm   → Bitta interfeys, ko'p xil ishlash
```

**Qanday birlashadi:**

```
Interface (A) → Abstract class (V) → Concrete class (I) → List da ishlatish (P)

ITolov (A)           ← shartnoma
  ↓
Mahsulot (V+I)       ← umumiy maydonlar, nazoratli kirish
  ↓
Kitob, Elektronika   ← xususiy implementatsiya
  ↓
Buyurtma.Tasdiqlash  ← polimorfik chaqiruv
```

---

### 🛒 Onlayn do'kon: [I]+[V]+[P]+[A]

```csharp
// [A] Interface shartnomasi
public interface ITolov { bool Tolash(decimal s); string Nomi { get; } }

// [V] Mahsulot ierarxiyasi
public abstract class Mahsulot {
    public string  Nomi { get; }
    public decimal Narx { get; }
    protected Mahsulot(string n, decimal p) { Nomi=n; Narx=p; }
    public abstract decimal YetkazishNarxi { get; }
}
public class Kitob : Mahsulot {
    public Kitob(string n, decimal p) : base(n, p) {}
    public override decimal YetkazishNarxi => 8_000;
}

// [I] Buyurtma holati nazorat qilinadi
public class Buyurtma {
    private List<Mahsulot> _m = new();
    private string _holat = "Yangi";
    public string  Holat => _holat;          // [I] faqat o'qish
    public decimal Jami  => _m.Sum(x => x.Narx + x.YetkazishNarxi); // [P]
    public void QoshMahsulot(Mahsulot m) {
        if(_holat != "Yangi") throw new InvalidOperationException("Tasdiqlangan!");
        _m.Add(m);
    }
    public bool Tasdiqlash(ITolov t) {    // [A]+[P]
        bool ok = t.Tolash(Jami);
        _holat = ok ? "Tasdiqlandi" : "Rad"; return ok;
    }
}
// [P] To'lov turlari
public class PaymeTolov2 : ITolov {
    public string Nomi => "Payme";
    public bool Tolash(decimal s) { Console.WriteLine($"📱{s:N0}✅"); return true; }
}

var b = new Buyurtma();
b.QoshMahsulot(new Kitob("C# Kitobi", 45_000));
Console.WriteLine($"Jami: {b.Jami:N0}");    // 53_000
b.Tasdiqlash(new PaymeTolov2());            // [A][P]
```

**4 tamoyil tahlili:**

| Tamoyil | Kod qismi | Nima qiladi |
|---------|-----------|-------------|
| **Inkapsulyatsiya** | `private _m`, `private _holat` | `Holat` tashqaridan o'zgartirib bo'lmaydi |
| **Vorislik** | `Kitob : Mahsulot` | Umumiy `Nomi`, `Narx` meros olindi |
| **Polimorfizm** | `ITolov t`, `t.Tolash()` | Payme, Click, Visa — barchasi ishlaydi |
| **Abstraktsiya** | `interface ITolov`, `abstract Mahsulot` | Shartnomalar aniq, implementatsiya yashirin |

---

## 📖 Asosiy atamalar

| Termin | Ta'rif |
|--------|--------|
| `private` | Faqat sinf ichida ko'rinadigan maydon |
| `public` | Hamma joydan ko'rinadigan a'zo |
| `protected` | Sinf va vorislar ichida ko'rinadi |
| `virtual` | Vorislar qayta yozishi mumkin bo'lgan metod |
| `override` | Voris sinfda baza metodini almashtirish |
| `abstract` | Tanasi yo'q metod — vorislar yozishi shart |
| `interface` | Faqat metod imzolarini belgilovchi shartnoma |
| `base()` | Baza sinfning konstruktorini chaqirish |
| `sealed` | Vorislikni yoki qayta yozishni taqiqlash |
| `is-a` | Vorislik testi: "Bu — ning turidir?" |
| `has-a` | Kompozitsiya: "Bunda ... bor" |
| OCP | Open/Closed Principle: kengaytirish uchun ochiq, o'zgartirish uchun yopiq |
| LSP | Liskov Substitution Principle: voris baza o'rnida ishlashi kerak |
| DI | Dependency Injection: tashqaridan qaramlik yuborish |
| DRY | Don't Repeat Yourself: kodni takrorlamang |

---

## 4 Tamoyil Solishtirmasi

| Tamoyil | Kalit savol | Vosita | Real misol |
|---------|------------|--------|------------|
| **Inkapsulyatsiya** | Qanday himoya qilish kerak? | `private` + metodlar | Bank balans, parol |
| **Vorislik** | Qanday takrorlanmaydi? | `: BazaSinf`, `abstract` | Tibbiy xodimlar, bank hisoblari |
| **Polimorfizm** | Qanday almashtirish mumkin? | `virtual/override`, `interface` | To'lov tizimlari, loggerlar |
| **Abstraktsiya** | Nima ko'rsatilsin? | `interface`, `abstract class` | Printer API, xabar yuborish |

---

## 20 ta Izohli Test

Har bir javobning nima uchun to'g'ri yoki xato ekanligini ko'ring.

---

### 🔴 Inkapsulyatsiya savollari (1–5)

---

**Savol 1.** Quyidagi kodda qaysi qator inkapsulyatsiya tamoyilini **buzadi**?

```csharp
public class Talaba {
    public string Ismi;       // A
    private double _gpa;      // B
    public double GPA {       // C
        get => _gpa;
        set { if(v>=0&&v<=4) _gpa=v; }
    }
    public int Kurs { get; }  // D
}
```

- A — `public string Ismi;` — to'g'ridan-to'g'ri ochiq maydon ✅ **TO'G'RI JAVOB**
- B — `private double _gpa;` — yashirin maydon
- C — GPA xususiyatida tekshiruv bor
- D — `public int Kurs { get; }` — faqat o'qish

> **Izoh:** `public` maydon — hech qanday tekshiruvsiz o'zgartiriladi. `t.Ismi=null` mumkin. Inkapsulyatsiyaga zid.

---

**Savol 2.** BankHisobi da balansni tashqaridan o'qish, lekin faqat sinf ichidan o'zgartirish mumkin. Qaysi yozuv to'g'ri?

- A — `public decimal Balans { get; set; }`
- B — `public decimal Balans;`
- C — `public decimal Balans { get; private set; }` ✅ **TO'G'RI JAVOB**
- D — `private decimal Balans { get; set; }`

> **Izoh:** `get` — public (o'qish mumkin). `set` — private (faqat sinf ichidan). Aynan kerak.

---

**Savol 3.** Qahramon sinfida HP hech qachon 0 dan past bo'lmasligi kerak. Bu invariantni qanday kafolatlash kerak?

- A — `public int HP;` — foydalanuvchi o'zi nazorat qilsin
- B — `private int _hp;` va `ZararOl()` da `Math.Max(0, _hp-z)` ✅ **TO'G'RI JAVOB**
- C — `public int HP { get; set; }` — xususiyat yetarli
- D — HP ni konstruktorda belgilab, umuman o'zgartirmaslik

> **Izoh:** `private` + `Math.Max(0,...)` — HP ni 0 dan pastga tushishdan kafolatlaydi.

---

**Savol 4.** Faqat `{ get; }` bo'lgan xususiyat nima anglatadi?

- A — Na o'qish, na yozish mumkin
- B — Faqat yozish mumkin
- C — Faqat o'qish (read-only) — tashqaridan yozib bo'lmaydi ✅ **TO'G'RI JAVOB**
- D — Kompilyatsiya xatosi — get va set ikkalasi shart

> **Izoh:** `{ get; }` faqat o'qish. Yozishga urinilsa kompilyatsiya xatosi.

---

**Savol 5.** Qaysi holat inkapsulyatsiyani TO'G'RI qo'llaydi?

- A — Barcha maydonlar `public` — foydalanish oson
- B — Maydonlar `private`, metodlar/xususiyatlar orqali tekshiruv bilan kirish ✅ **TO'G'RI JAVOB**
- C — Hamma narsa `private` — tashqaridan umuman kirish bo'lmaydi
- D — Faqat metodlar, maydonlar bo'lmaydi

> **Izoh:** Klassik inkapsulyatsiya: `private` + nazoratli kirish. Invariantlar saqlanadi.

---

### 🔵 Vorislik savollari (6–10)

---

**Savol 6.** C# da vorislikni ifodalash uchun qaysi sintaksis ishlatiladi?

- A — `class Talaba extends Shaxs { }`
- B — `class Talaba implements Shaxs { }`
- C — `class Talaba : Shaxs { }` ✅ **TO'G'RI JAVOB**
- D — `class Talaba inherits Shaxs { }`

> **Izoh:** C# da vorislik ikki nuqta (`:`) orqali. `extends` — Java tilining sintaksisi.

---

**Savol 7.** `abstract` kalit so'zi bilan belgilangan metod haqida qaysi ifoda TO'G'RI?

- A — Baza sinfda tanasi bor, voris xohlasa qayta yozishi mumkin
- B — Baza sinfda tanasi yo'q, voris ALBATTA `override` qilishi shart ✅ **TO'G'RI JAVOB**
- C — Faqat `private` metodlarda ishlatiladi
- D — Bu metodni tashqaridan chaqirib bo'lmaydi

> **Izoh:** `abstract` = tanasiz imzo. Voris `override` qilmasa — kompilyatsiya xatosi.

---

**Savol 8.** Voris sinfda `: base(ismi, yoshi)` nima vazifani bajaradi?

- A — Voris sinfga yangi konstruktor qo'shadi
- B — Baza sinfning konstruktorini chaqiradi va parametrlarni uzatadi ✅ **TO'G'RI JAVOB**
- C — Baza sinfning barcha metodlarini o'chiradi
- D — Baza sinfdan yangi ob'yekt yaratadi

> **Izoh:** `: base(ismi, yoshi)` baza sinfning mos konstruktorini chaqiradi.

---

**Savol 9.** Qaysi holat vorislikni TO'G'RI qo'llaydi (is-a qoidasi)?

- A — `class Mashina : Eshik` — mashinada eshik bor
- B — `class Shifokor : TibbiyXodim` — shifokor tibbiy xodim turi ✅ **TO'G'RI JAVOB**
- C — `class Universitet : Talaba` — universitetda talabalar bor
- D — `class Kitob : Kutubxona` — kitob kutubxonada saqlanadi

> **Izoh:** "Shifokor tibbiy xodimMI?" — Ha! is-a qoidasi to'g'ri.

---

**Savol 10.** Voris sinf baza sinfning virtual metodini qayta yozish uchun qaysi kalit so'z?

- A — `new` — yangi metod qo'shadi
- B — `virtual` — virtual metod yaratadi
- C — `override` — baza virtual metodini qayta yozadi ✅ **TO'G'RI JAVOB**
- D — `abstract` — abstrakt metod yaratadi

> **Izoh:** `virtual` (baza) + `override` (voris) = runtime polimorfizm.

---

### 🟢 Polimorfizm savollari (11–15)

---

**Savol 11.** Polimorfizmning asosiy afzalligi nima?

- A — Dastur tezroq ishlaydi
- B — Turli ob'yektlarni bitta interfeys orqali boshqarish; yangi tur mavjud kodni o'zgartirmasdan qo'shiladi ✅ **TO'G'RI JAVOB**
- C — Faqat bir xil turli ob'yektlarni listda saqlash
- D — Dasturchi kamroq sinf yozadi

> **Izoh:** OCP. UzCard qo'shilsa — kassir kodi O'ZGARMAYDI.

---

**Savol 12.** `List<TolovTizimi>` da Click, Payme, Visa ob'yektlari saqlanishi mumkin. Nima uchun?

- A — `List<>` har qanday narsani saqlaydi
- B — Click, Payme, Visa — barchasi `TolovTizimi` dan vorislik olgan ✅ **TO'G'RI JAVOB**
- C — C# da barcha sinflar bitta ro'yxatda saqlanadi
- D — Bu faqat interfeys bilan ishlaydi, abstract class bilan emas

> **Izoh:** Vorislik (is-a): `ClickTolov` — `TolovTizimi` dir. Listda saqlanadi.

---

**Savol 13.** `TolovTizimi` tizimiga yangi UzCard provayderi qo'shish uchun nima qilish kerak?

- A — Barcha mavjud Click, Payme, Visa sinflarini o'zgartirish
- B — `TolovTizimi` abstrakt sinfiga yangi metod qo'shish
- C — Faqat `UzCardTolov : TolovTizimi` sinfi yoziladi, boshqa hech narsa o'zgarmaydi ✅ **TO'G'RI JAVOB**
- D — `foreach` tsiklini o'zgartirish kerak

> **Izoh:** Polimorfizmning asosiy kuchi. Kassir kodi, foreach — hech narsa o'zgarmaydi!

---

**Savol 14.** Method overloading (bir xil nom, turli parametrlar) — bu qanday polimorfizm?

- A — Runtime polimorfizm — dastur ishlayotganda aniqlanadi
- B — Compile-time polimorfizm — kompilyatsiya vaqtida aniqlanadi ✅ **TO'G'RI JAVOB**
- C — Bu polimorfizmga kirmaydi
- D — Interface polimorfizmi

> **Izoh:** Kompilyator parametr tipiga qarab qaysi metodini chaqirishni hal qiladi.

---

**Savol 15.** Nima uchun polimorfizm `switch/if-else` zanjiridan yaxshiroq?

- A — Polimorfizm tezroq ishlaydi
- B — Yangi tur qo'shilganda `switch/if-else` ni o'zgartirish kerak; polimorfizmda — yo'q ✅ **TO'G'RI JAVOB**
- C — `if-else` da xatolik muqarrar
- D — Polimorfizmda kod kamroq bo'ladi

> **Izoh:** `if-else` da har yangi turda kodni o'zgartirish kerak. Polimorfizmda: yangi sinf — hamma joyda ishlaydi.

---

### 🟣 Abstraktsiya savollari (16–20)

---

**Savol 16.** Abstraktsiya va inkapsulyatsiya — bitta jumlada farqini belgilang.

- A — Hech qanday farq yo'q — ikkalasi bir xil
- B — Abstraktsiya — "nima qiladi?" (interfeys), Inkapsulyatsiya — "qanday qiladi?" (ichni yashirish) ✅ **TO'G'RI JAVOB**
- C — Abstraktsiya — `private` maydonlar, Inkapsulyatsiya — interfeys
- D — Inkapsulyatsiya faqat vorislikda ishlatiladi

> **Izoh:** `IPrinter.Print()` — nima (abstraktsiya). `LazerPrinter` ichidagi private metodlar — qanday (inkapsulyatsiya).

---

**Savol 17.** `interface` va `abstract class` — qachon interfeys ishlatish to'g'riroq?

- A — Umumiy maydonlar ulashish kerak bo'lsa
- B — Standart metod tanasi kerak bo'lsa
- C — Faqat xulq shartnomasi kerak, bir sinfga ko'p interfeys kerak bo'lsa ✅ **TO'G'RI JAVOB**
- D — Interfeys faqat bitta metod bo'lganda

> **Izoh:** C# da ko'p vorislik yo'q, lekin ko'p interfeys mumkin: `class A : IB, IC, ID`.

---

**Savol 18.** `abstract class Shakl { public abstract double Yuza(); }` dan `new Shakl()` qilishga urinilsa nima bo'ladi?

- A — Ishlaydi — abstract sinf oddiy sinf bilan bir xil
- B — Kompilyatsiya xatosi — abstract sinfdan ob'yekt yaratib bo'lmaydi ✅ **TO'G'RI JAVOB**
- C — Dastur ishlaydi, `Yuza()` chaqirilganda xato beradi
- D — `Yuza()` 0 qaytaradi

> **Izoh:** "Cannot create instance of abstract type Shakl" — kompilyator xatosi.

---

**Savol 19.** `LazerPrinter` va `InkjetPrinter` — ikkalasi `IPrinter` amalga oshiradi. Bu qaysi tamoyillarni ko'rsatadi?

- A — Faqat inkapsulyatsiya
- B — Faqat vorislik
- C — Abstraktsiya (`IPrinter` shartnoma) + Polimorfizm (bir xil `Print()` — har xil natija) ✅ **TO'G'RI JAVOB**
- D — Bu OOP tamoyillariga kirmaydi

> **Izoh:** `IPrinter` — abstraktsiya. Kod `IPrinter` tipida ishlaydi, qaysi printer ekanligini bilmaydi — polimorfizm.

---

**Savol 20.** `IOmbor<T>` interfeysi ishlatilgan `TalabaXizmati` — bu nima imkoniyat beradi?

```csharp
public class TalabaXizmati {
    private IOmbor<string> _ombor;
    public TalabaXizmati(IOmbor<string> ombor)
    { _ombor = ombor; }
    public void Qoshish(string id, string ismi)
    { _ombor.Saqlash(id, ismi); }
}
```

- A — Faqat `XotiradagiOmbor` bilan ishlaydi
- B — `TalabaXizmati` qaerda saqlanayotganini bilmaydi — xotirada, faylda, SQL — barchasi almashtiriladi, kod o'zgarmaydi ✅ **TO'G'RI JAVOB**
- C — Saqlash tezroq bo'ladi
- D — Bu generic dasturlash, OOP bilan bog'liq emas

> **Izoh:** Dependency Injection kuchi. Test uchun `XotiradagiOmbor`, produksiyada `SQLOmbor` — bir qator ham o'zgarmaydi!

---

## Tashqi manbalar

| Mavzu | Havola |
|-------|--------|
| Access Modifiers | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) |
| Properties in C# | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties) |
| Inheritance in C# | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance) |
| Abstract Classes | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members) |
| Polymorphism | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/polymorphism) |
| Interfaces | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/) |
| base keyword | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/base) |
| override keyword | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override) |
| Dependency Injection | [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) |
| Replace Conditional with Polymorphism | [Refactoring Guru](https://refactoring.guru/replace-conditional-with-polymorphism) |

---

*OOPning 4 Tamoyili · C# · Milliy Universitet, Toshkent · 2025*
