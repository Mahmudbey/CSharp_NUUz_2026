# Null

### Ma'lumot turlari

Dasturlashni o'rganishda birinchi savol: _"Kompyuter ma'lumotlarni qanday saqlaydi?"_

🗄️ **Xotira = Katakchalar to'plami**

Kompyuter xotirasini (RAM) ulkan jadval deb tasavvur qiling. Har bir katakchaning o'z manzili bor. O'zgaruvchi e'lon qilganingizda, dastur shu jadvaldan bo'sh katakcha ajratib oladi va u yerga qiymat yozadi.

Zamonaviy protsessor arxitekturalarida (x86, ARM) `null` ko'pincha fizik xotiraning 0x00000000 (32-bit) yoki 0x0000000000000000 (64-bit) manzillariga tenglashtiriladi.

> Nol manzilining ahamiyati Operatsion tizimlar xotiraning nolinchi sahifasini (Zero Page) himoyalangan hudud sifatida saqlaydi. Ushbu manzilga dasturiy murojaat qilish _Segmentation Fault_ yoki _Access Violation_ xatosini keltirib chiqaradi. Bu apparat darajasidagi himoya mexanizmi bo'lib, dasturchiga xatolikni (masalan, `NullPointerException`) darhol aniqlash imkonini beradi.

#### Value Types va Reference Types

C# da barcha ma'lumot turlari ikki guruhga bo'linadi. Bu farqni tushunish — null ni tushunishning kaliti.

| Tur                              | Misol                           | Xotirada nima saqlanadi?                    | Null bo'lishi mumkinmi? |
| -------------------------------- | ------------------------------- | ------------------------------------------- | ----------------------- |
| **Value Type** (Qiymat turi)     | `int`, `double`, `bool`, `char` | Qiymatning o'zi (masalan: `42`)             | Yo'q                    |
| **Reference Type** (Havola turi) | `string`, `class`, `array`      | Ob'yekt joylashgan xotira manzili (pointer) | Ha                      |

📬 **Farqni tushunish uchun taqqoslash**

**Value Type** — xatga pul solib yuborish. Qiymat to'g'ridan-to'g'ri o'zgaruvchida turadi.

<figure><img src="../.gitbook/assets/image (5).png" alt=""><figcaption></figcaption></figure>

**Reference Type** — xatga bank kartasi raqamini yozib yuborish. O'zgaruvchida pul emas, balki pulning _manzili_ turadi. Agar manzil bo'lmasa — bu **null**.

<figure><img src="../.gitbook/assets/image (1).png" alt=""><figcaption></figcaption></figure>

C# — Value Type vs Reference Type

```csharp
// ── VALUE TYPES ──────────────────────────────────────────
// Qiymat to'g'ridan-to'g'ri o'zgaruvchida saqlanadi
int    yosh  = 20;     // Xotirada: [20]
double baho  = 4.5;   // Xotirada: [4.5]
bool   faol  = true;  // Xotirada: [true]
// Value type hech qachon null bo'lmaydi!
// int yosh = null;  ← Kompilyator xato beradi
// ── REFERENCE TYPES ──────────────────────────────────────
// O'zgaruvchida ob'yektning xotira manzili saqlanadi
string ism    = "Alisher";     // O'zgaruvchida: [manzil → "Alisher"]
int[]  sonlar = { 1, 2, 3 };  // O'zgaruvchida: [manzil → massiv]
// Reference type null bo'lishi MUMKIN:
string familiya = null;  // O'zgaruvchida: [hech qanday manzil yo'q]
```

### Xotirada null qanday saqlanadi?

null — bu ko'rsatkich (pointer) yoki havola (reference) hech qanday obyektga yo'naltirilmaganligini ifodalovchi maxsus mantiqiy qiymatdir. Garchi u "bo'shlik" tushunchasini anglatsada, uning xotira sathidagi fizik ko'rinishi turli arxitektura va muhitlarda turlicha amalga oshiriladi.

<figure><img src="../.gitbook/assets/image (4).png" alt=""><figcaption></figcaption></figure>

Quyidagi kod bajarilganda xotirada nima bo'lishini ko'rib chiqaylik:

C# — Xotira holati

```csharp
string ism = "Vali";  // 1-qadam
ism = null;          // 2-qadam
```

#### 1-qadam: `ism = "Vali"`

**Xotira holati —&#x20;**_**"Vali"**_**&#x20;satri tayinlangandan keyin** A0A1 B000→_**ism**_**&#x20;o'zgaruvchisi — `B000` manzilini ko'rsatadi** B000'V''a''l''i'\0 ← _"Vali"_ satri shu yerda saqlanadi.

`ism` o'zgaruvchisi xotiraning **A0A1** (Stack) manzilida joylashgan. Bu manzilda esa `B000` (Heap) qiymati saqlanadi, u esa _"Vali"_ satrining boshlanish manzilini bildiradi. Ya'ni, `ism` o'zgaruvchisi o'zi satrning qiymatini emas, balki uning xotiradagi manzilini saqlaydi. Shuning uchun biz: _**"ism o'zgaruvchisi 'Vali' satrining boshlanish manziliga ishora qiladi"**_ deymiz.

Bu yerda satrning har bir belgisi alohida xotira katakchasida saqlanadi: 'V', 'a', 'l', 'i' va oxirida `\0` (null-terminator) belgisi, bu satrning tugaganini bildiradi. Bu C# tilida satrlar qanday saqlanishini tushunishga yordam beradi.

Bu holatda `ism` o'zgaruvchisi (pointer) Stack-da joylashadi va Heap-dagi matn turgan manzilni ko'rsatadi.

| Xotira qismi | Manzil | Qiymat (Hex) | Tavsifi                                                        |
| ------------ | ------ | ------------ | -------------------------------------------------------------- |
| **Stack**    | `A0A1` | **`B000`**   | `ism` o'zgaruvchisi — Heap-dagi `B000` manziliga ishora qiladi |
|              |        |              |                                                                |
| **Heap**     | `B000` | `0056`       | `'V'` (Matnning boshlanishi)                                   |
| **Heap**     | `B001` | `0061`       | `'a'`                                                          |
| **Heap**     | `B002` | `006C`       | `'l'`                                                          |
| **Heap**     | `B003` | `0069`       | `'i'`                                                          |
| **Heap**     | `B004` | `0000`       | `\0` (Satr yakuni / null-terminator)                           |

> 💡 **Izoh:** **Reference type** da `ism` o'zgaruvchisi satrning o'zini emas, balki uning xotiradagi **manzilini** saqlaydi.

#### 2-qadam: `ism = null`

**Xotira holati —&#x20;**_**null**_**&#x20;qiymat tayinlangandan keyin A0A1**_0000_✗_**ism**_**&#x20;endi hech qanday manzilga ishora qilmaydi** B000'V''a''l''i'\0← _"Vali"_ satri hali xotirada saqlanmoqda (Garbage Collector uni tozalagunicha)

Bu holatda Stack-dagi ko'rsatkich (pointer) nolga tenglashtiriladi. Heap-dagi ma'lumot esa vaqtincha o'z joyida qoladi.

| Xotira qismi | Manzil | Qiymat (Hex) | Tavsif / Mazmuni                                        |
| ------------ | ------ | ------------ | ------------------------------------------------------- |
| **Stack**    | `A0A1` | **`0000`**   | `ism` endi **null** — hech qanday manzilni ko'rsatmaydi |
|              |        |              |                                                         |
| **Heap**     | `B000` | `0056`       | `'V'` (Yetim qolgan ma'lumot — endi unga yo'l yo'q)     |
| **Heap**     | `B001` | `0061`       | `'a'`                                                   |
| **Heap**     | `B002` | `006C`       | `'l'`                                                   |
| **Heap**     | `B003` | `0069`       | `'i'`                                                   |
| **Heap**     | `B004` | `0000`       | `\0`                                                    |

`ism` o'zgaruvchisiga _**null**_ qiymat tayinlanganda, uning xotiradagi qiymati `0000` (barcha bitlar nol) ga o'zgaradi. Bu _null_ qiymatning xotiradagi ko'rinishidir va u _hech qanday haqiqiy manzilga ishora qilmasligini_ bildiradi.

Shunday qilib, `ism` endi _"Vali"_ satrining joylashgan manzilini ko'rsatmaydi, lekin o'sha satr hali xotirada mavjud. Bu satr Garbage Collector (GC) tomonidan keyinchalik tozalanadi, ya'ni xotira bo'shatiladi. GC bu jarayonni avtomatik ravishda boshqaradi, shuning uchun dasturchi qo'lda xotirani tozalash bilan shug'ullanishi shart emas.

Bu holat dasturlashda _null_ qiymatning qanday ishlashini va uning xotira boshqaruvidagi o'rnini tushunish uchun muhimdir. _**null**_ qiymat o'zgaruvchining hech qanday haqiqiy obyektga yoki qiymatga ishora qilmasligini bildiradi, bu esa dasturda xatoliklarni oldini olish va to'g'ri xotira boshqaruvini ta'minlash uchun zarur.

**💡 Izoh** Null ning xotiradagi aniq qiymati (0000 yoki boshqa) dasturlash muhitiga bog'liq. Java Virtual Machine spetsifikatsiyasi ham: _"JVM null uchun aniq qiymatni belgilamaydi"_ deydi. C# da ham xuddi shunday.

**Dasturlash tillarida `null` (yoki muqobillari) ning solishtirish**

| Mezon                   | C / C++                                                      | Java (JVM)                                                        | C# (.NET)                                              | **Python**                                               |
| ----------------------- | ------------------------------------------------------------ | ----------------------------------------------------------------- | ------------------------------------------------------ | -------------------------------------------------------- |
| **Atamasi**             | `NULL` yoki `nullptr`                                        | `null`                                                            | `null`                                                 | **`None`**                                               |
| **Fizik qiymat**        | Odatda `0`, biroq apparat arxitekturasiga bog'liq.           | Spetsifikatsiya aniq bitlar ketma-ketligini belgilamaydi.         | Abstrakt havola, ko'pincha "all-zeros" bit pattern.    | **Maxsus `NoneType` ob'ekti (Singleton).**               |
| **Xotira boshqaruvi**   | Manual (Pointer arifmetikasi va bevosita manzilga murojaat). | Avtomatik (Garbage Collection), xotira manzili abstraksiyalangan. | Avtomatik (Managed Code), xavfsiz havolalar tizimi.    | **Avtomatik (Reference Counting va GC).**                |
| **Xavfsizlik darajasi** | Past (Dangling pointer va xotira sizib chiqishi xavfi).      | Yuqori (Runtime darajasida `NullPointerException` nazorati).      | Yuqori (`?.` operatori va _Nullable reference types_). | **Yuqori (Dinamik tiplash va `is None` tekshiruvi).**    |
| **Implementatsiya**     | Makros yoki literal sifatida ifodalanadi.                    | Ob'ekt havolasining (Reference) maxsus, bo'sh holati.             | `null` literali va `System.Nullable` strukturalari.    | **Xotirada bitta nusxada mavjud bo'lgan doimiy ob'ekt.** |

***

> 💡 E**slatma:**\
> Python-dagi `None` boshqa tillardagi `null` dan farqli o'laroq, shunchaki "bo'sh ko'rsatkich" emas, balki **haqiqiy ob'ektdir**. Shuning uchun Python-da `if x is None:` deb tekshirish eng to'g'ri va tezkor usul hisoblanadi (chunki u xotiradagi bitta ob'ekt manzilini solishtiradi).

#### Null operatsiyalari tezligi

Null bilan ishlash **juda tez va arzon**. Faqat ikkita operatsiya mavjud:

⚡ Null tayinlash (`ism = null`) 1 ta xotira yozish⚡ Null tekshiruv (`if ism == null`) 1 ta xotira o'qishC# — Null operatsiyalari

```csharp
string ism = "Alisher";
// Operatsiya 1: Null tayinlash — faqat bitta xotira katakchasini 0 ga o'zgartiradi
ism = null;
// Operatsiya 2: Null tekshiruv — faqat bitta xotira katakchasini o'qiydi
if (ism == null)
{
Console.WriteLine("Ism yo'q");
}
// Ikkala operatsiya ham O(1) — doimiy vaqt, juda tez!
```

### 'Null'ning ma'nosi va kontekst

Ko'pchilik dasturchilar null ni noto'g'ri tushunadi.

📧 **Savol: Alining emailAddress null. Bu nima degani?**

Alining `emailAddress` maydoni null bo'lsa, bu **bir nechta narsani anglatishi mumkin**: Alining email manzili yo'q. Yoki bor, lekin hali kiritilmagan. Yoki maxfiy. Yoki dasturda xato bor. Kontekstsiz bilish mumkin emas.

Texnik jihatdan null faqat bitta narsani anglatadi: **"bu o'zgaruvchi bilan hech qanday qiymat bog'liq emas"**. Lekin _nima uchun_ bog'liq emas — bu kontekstga bog'liq.

❌ **Email yo'q**

Ali haqiqatan ham email manziliga ega emas

⏳ **Hali kiritilmagan**

Email bor, lekin bazaga hali qo'shilmagan

🔒 **Maxfiy**

Email bor, lekin xavfsizlik sababli ko'rsatilmaydi

C# — Null ning kontekstga bog'liq ma'nosi

```csharp
class Shaxs
{
    public string Ism              { get; set; }  // Har doim bo'lishi kerak
    public string? EmailManzili    { get; set; }  // Null = email yo'q
    public DateTime? BirinchiNikoh { get; set; }  // Null = hali turmush qurmagan
}
// Ishlatish — null ning ma'nosi kontekstdan aniq:
var shaxs = new Shaxs
{
Ism           = "Alisher",
EmailManzili  = null,    // Alisher emailga ega emas
BirinchiNikoh = null     // Alisher hali uylanmagan
};
// Email yuborish tsikli — null tekshiruvi bilan:
foreach (var s in shaxslar)
{
if (s.EmailManzili != null)
{
// Email yuborish kodi
}
else
{
logger.Warning($"{s.Ism} uchun email manzili yo'q");
}
}
```

**⚠️ Muhim eslatma** Ko'p hollarda null ning _nima uchun_ null ekanligi muhim emas — biz shunchaki null ekanligini tekshirib, tegishli harakat qilamiz. Lekin ba'zan sabab juda muhim bo'ladi (keyingi bo'limda ko'ramiz).

#### Null sababi muhim bo'lgan holat: tibbiy misol

**⚕️ Xavfli vaziyat: Allergiya testi**

Tibbiy dasturda `GetAllergiesOfPatient(patientId)` funksiyasi null qaytarsa, bu ikki xil narsani anglatishi mumkin:

1\. Bemor allergiyaga ega emas (test o'tkazildi, natija — yo'q)

2\. Allergiya testi hali o'tkazilmagan (natija noma'lum)

**Bu ikki holat hayot uchun xavfli farq!** Agar dastur "allergiya yo'q" deb ko'rsatsa, lekin aslida test o'tkazilmagan bo'lsa — shifokor noto'g'ri dori buyurishi mumkin.

**❌ Yomon yondashuv (Java/C# da bir xil muammo)**

```csharp
// null = test o'tkazilmagan?
// bo'sh ro'yxat = allergiya yo'q?
// Bu noaniq va xavfli!
List<Allergiya> GetAllergiyalar(int id)
{
    if (testOtkazilmagan) return null;
    if (allergiyaYoq)    return new List<>();
    return allergiyalar;
}
```

**✅ To'g'ri yondashuv — alohida turlar**

```csharp
// Har bir holat uchun alohida tur
abstract class AllergiyaTestNatijasi { }
class TestOtkazilmagan
: AllergiyaTestNatijasi { }
class TestKutilmoqda
: AllergiyaTestNatijasi
{
public DateTime BoshlanganSana;
}
class TestYakunlandi
: AllergiyaTestNatijasi
{
public List<Allergiya>? Allergiyalar;
}
```

C# — To'g'ri yondashuv: Pattern Matching bilan

```csharp
AllergiyaTestNatijasi natija = GetAllergiyaTestNatijasi(bemorId);
// C# da switch expression bilan — aniq va xavfsiz
switch (natija)
{
case TestOtkazilmagan:
Console.WriteLine("Test hali o'tkazilmagan.");
break;
<span class="kw">case</span> <span class="ty">TestKutilmoqda</span> t:    Console.<span class="fn">WriteLine</span>(<span class="st">$"Test {t.BoshlanganSana} da boshlangan, natija kutilmoqda."</span>);    <span class="kw">break</span>;<span class="kw">case</span> <span class="ty">TestYakunlandi</span> y:    <span class="kw">if</span> (y.Allergiyalar == <span class="kw">null</span> || y.Allergiyalar.Count == <span class="nm">0</span>)        Console.<span class="fn">WriteLine</span>(<span class="st">"Allergiya topilmadi."</span>);    <span class="kw">else</span>        Console.<span class="fn">WriteLine</span>(<span class="st">$"{y.Allergiyalar.Count} ta allergiya aniqlandi."</span>);    <span class="kw">break</span>;
}
// Endi har bir holat aniq — hayot uchun xavf yo'q!
```

### Nima uchun null? — tarixiy xato

1965-yilda britaniyalik kompyuter olimi **Toni Xoar (Tony Hoare)** — Quicksort algoritmining ixtirochisi va 1980-yil Turing mukofoti sohibi — ALGOL W dasturlash tilini yaratayotganida birinchi marta _null reference_ tushunchasini kiritdi.

> "Null reference ni ixtiro qilganimni o'zimning **milliard dollarlik xatom** deb atayman. O'sha paytda buni amalga oshirish juda oson edi. Lekin bu noaniq havolalar natijasida tizimlarning ishdan chiqishi, xavfsizlik zaifliklari va tizim nosozliklari paydo bo'ldi. Bu oxirgi 40 yil davomida milliardlab dollar zarar keltirgan." _— Tony Hoare, QCon London, 2009_

Lekin Xoar o'z nutqida yechimni ham ko'rsatdi:

> "Yangi dasturlash tillari... non-null reference uchun e'lonlar kiritdi. Bu 1965-yilda men rad etgan yechim edi." _— Tony Hoare_

**⚠️ Asosiy xulosa** Muammo null ning o'zida emas — ko'pchilik dasturlash tillarida **nullable va non-nullable turlar o'rtasida farq yo'qligi**da. C# 8.0+ bu muammoni hal qildi.**💡 Statistika** Stack Overflow ma'lumotlariga ko'ra, "NullReferenceException" so'rovi yiliga **20 million marta** qidiriladi. Bu dasturchilar uchun eng keng tarqalgan muammodir.5

### O'zgaruvchi e'lon qilinsa, lekin qiymat berilmasa?

Bu savol ko'pchilik yangi dasturchilarni qiynaydi. Quyidagi uchta e'lonni ko'rib chiqaylik:

C# — Initsializatsiya holatlari

```csharp
string s1 = "foo";  // Aniq qiymat berildi
string s2 = null;  // Aniq null berildi
string s3;         // Hech narsa berilmadi — nima bo'ladi?
```

Turli dasturlash tillarida `s3` ning holati farq qiladi. Quyida eng keng tarqalgan variantlar:

| Variant                                                            | Tavsif                                       | Xavfsizlik  |
| ------------------------------------------------------------------ | -------------------------------------------- | ----------- |
| Qiymat berilmagan o'zgaruvchi e'lon qilish taqiqlangan             | Kompilyator xato beradi                      | Eng xavfsiz |
| Tasodifiy qiymat (xotira qoldig'i)                                 | Default qiymat yo'q — nima bo'lsa o'sha      | Xavfli      |
| Avtomatik default qiymat (null yoki 0)                             | Reference type → null, int → 0, bool → false | O'rtacha    |
| "Initsializatsiya qilinmagan" holat — ishlatishda kompilyator xato | Ishlatishdan oldin qiymat berish majburiy    | Eng xavfsiz |

#### C# da qanday ishlaydi?

C# **lokal o'zgaruvchilar** uchun eng xavfsiz variantni tanlaydi — ishlatishdan oldin qiymat berish majburiy:

C# — Initsializatsiya qoidalari

```csharp
// ── LOKAL O'ZGARUVCHILAR ──────────────────────────────────
string s3;
Console.WriteLine(s3);
// ❌ Kompilyator xato: "Use of unassigned local variable 's3'"
// C# lokal o'zgaruvchini ishlatishdan oldin qiymat berish majburiy!
// ── SINF MAYDONLARI (Class Fields) ───────────────────────
class Talaba
{
public string   Ism;    // Avtomatik null
public int      Yosh;   // Avtomatik 0
public bool     Faol;   // Avtomatik false
public double   Baho;   // Avtomatik 0.0
}
var t = new Talaba();
Console.WriteLine(t.Ism);   // null — xato yo'q, lekin ehtiyot bo'ling!
Console.WriteLine(t.Yosh);  // 0
Console.WriteLine(t.Faol);  // false
// ── TO'G'RI YONDASHUV ─────────────────────────────────────
string s3 = string.Empty;  // Bo'sh satr — null emas
string s4 = "default";    // Default qiymat
string? s5 = null;         // Ataylab nullable — C# 8.0+
```

**✅ C# ning afzalligi** C# lokal o'zgaruvchilar uchun eng xavfsiz yondashuvni qo'llaydi: qiymat berilmagan o'zgaruvchini ishlatish kompilyator xatosiga olib keladi. Bu ko'plab xatolarni oldindan oldini oladi.6

### Null qachon ishlatish kerak?

**Sodda qoida: null faqat "qiymat yo'q" holatini ifodalash uchun ishlatilsin.**

#### To'g'ri ishlatish: Ixtiyoriy maydonlar

C# — Nullable va Non-nullable maydonlar

```csharp
class Shaxs
{
    // Har bir shaxsning ismi bor — null bo'lmasligi kerak
    public required string Ism { get; set; }
<span class="cm">// Hamma ham turmush qurmagan — null bo'lishi mumkin</span><span class="kw">public</span> <span class="ty">DateTime</span>? BirinchiNikohSanasi { <span class="kw">get</span>; <span class="kw">set</span>; }<span class="cm">// Hamma ham email manziliga ega emas — null bo'lishi mumkin</span><span class="kw">public</span> <span class="ty">string</span>? EmailManzili { <span class="kw">get</span>; <span class="kw">set</span>; }
}
// Ishlatish:
var shaxs = new Shaxs
{
Ism                  = "Alisher",
BirinchiNikohSanasi  = null,   // Hali uylanmagan — to'g'ri!
EmailManzili         = null    // Email yo'q — to'g'ri!
};
// Null tekshiruvi bilan ishlatish:
if (shaxs.BirinchiNikohSanasi.HasValue)
Console.WriteLine($"Nikoh sanasi: {shaxs.BirinchiNikohSanasi.Value}");
else
Console.WriteLine("Hali turmush qurmagan.");
```

#### Noto'g'ri ishlatish: Xato holatlarini null bilan ifodalash

**🔴 Qoida: Null xato holatlarini ifodalash uchun ISHLATILMAYDI** Xato yuz berganda null qaytarish o'rniga exception tashlang yoki Result pattern ishlating.

**❌ Yomon — null bilan xato ifodalash**

```csharp
// Fayl o'qishda xato bo'lsa null qaytarish
AppConfig? ReadConfig(string path)
{
    if (!File.Exists(path))
        return null;  // ❌ Xato sababi noma'lum!
    return JsonSerializer.Deserialize<AppConfig>(
        File.ReadAllText(path));
}
// Chaqiruvchi kod xato sababini bilmaydi:
var cfg = ReadConfig("app.json");
// null = fayl yo'qmi? Yoki buzilganmi? Noma'lum!
```

**✅ To'g'ri — exception bilan xato ifodalash**

```csharp
// Exception tashlash — xato sababi aniq
AppConfig ReadConfig(string path)
{
if (!File.Exists(path))
throw new FileNotFoundException(
$"Konfiguratsiya fayli topilmadi: {path}");
<span class="kw">var</span> json = File.<span class="fn">ReadAllText</span>(path);<span class="kw">return</span> JsonSerializer.<span class="fn">Deserialize</span>&lt;<span class="ty">AppConfig</span>&gt;(json)    ?? <span class="kw">throw new</span> <span class="ty">InvalidDataException</span>(        <span class="st">"Konfiguratsiya fayli buzilgan."</span>);
}
// Chaqiruvchi kod xatoni aniq ushlaydi:
try { var cfg = ReadConfig("app.json"); }
catch (FileNotFoundException ex) { /* fayl yo'q / }
catch (InvalidDataException ex)  { / fayl buzilgan */ }
```

### Xavf va oqibatlar: NullReferenceException

C# da eng keng tarqalgan xatolik — **NullReferenceException** (qisqacha NRE). Bu xato null ob'yektga murojaat qilinganda yuzaga keladi.

C# — NullReferenceException misoli

```csharp
string talabaNomi = null;
int uzunlik = talabaNomi.Length;
// ❌ System.NullReferenceException: Object reference not set to an instance of an object.
// Nima sodir bo'ldi?
// talabaNomi null — hech qanday satrga ishora qilmayapti.
// .Length ni null dan olmoqchimiz — bu mumkin emas.
// CLR (Common Language Runtime) dasturni to'xtatadi.
```

#### Real loyihalardagi oqibatlar

| Vaziyat       | Null sababi                            | Oqibat                    |
| ------------- | -------------------------------------- | ------------------------- |
| Web sayt      | Foydalanuvchi ma'lumoti tekshirilmagan | 500 Internal Server Error |
| Mikroservis   | API null qaytargan, tekshirilmagan     | Servis crash bo'ladi      |
| E-commerce    | Buyurtma ma'lumotlari to'liq emas      | Ma'lumot yo'qoladi        |
| Tibbiy dastur | Bemor ma'lumoti null, tekshirilmagan   | Hayot uchun xavf          |

**📊 Statistika** Stack Overflow ma'lumotlariga ko'ra, "NullReferenceException" so'rovi yiliga **20 million marta** qidiriladi. Bu dasturchilar uchun eng keng tarqalgan muammodir.8

### C# da null bilan ishlash: eski va zamonaviy uslublar

#### Eski uslub: `if (obj != null)`

C# — Klassik null tekshiruvi

```csharp
string talabaNomi = GetStudentName();
if (talabaNomi != null)
{
Console.WriteLine($"Talaba: {talabaNomi}");
Console.WriteLine($"Uzunligi: {talabaNomi.Length}");
}
else
{
Console.WriteLine("Talaba topilmadi.");
}
// Ishlaydi, lekin ko'p if-else bilan kod to'lib ketadi.
```

#### **Zamonaviy uslublar**

#### Null-Conditional Operator `?.`

C# 6.0 dan boshlab mavjud. Null bo'lsa — xato bermaydi, null qaytaradi.

C# — ?. operatori

```csharp
string? talabaNomi = GetStudentName();
// Agar talabaNomi null bo'lsa — uzunlik ham null qaytaradi (xato yo'q!)
int? uzunlik = talabaNomi?.Length;
// Zanjir ko'rinishida ham ishlatish mumkin:
string? shahar = talaba?.Manzil?.Shahar;
// talaba null bo'lsa → null
// talaba.Manzil null bo'lsa → null
// Aks holda → shahar qiymati
// Massivlar bilan:
int[]? sonlar = null;
int? birinchi = sonlar?[0];  // null — xato yo'q
```

#### Null-Coalescing Operator `??`

Null bo'lsa, o'rniga default qiymat beradi.

C# — ?? va ??= operatorlari

```csharp
string? talabaNomi = GetStudentName();
// ?? — null bo'lsa o'ng tomondagi qiymatni ishlatadi
string ism = talabaNomi ?? "Noma'lum";
Console.WriteLine($"Talaba: {ism}");  // Hech qachon null bo'lmaydi
// Kombinatsiya: ?. va ?? birga
int uzunlik = talabaNomi?.Length ?? 0;  // null bo'lsa 0
// ??= — faqat null bo'lsa tayinlaydi (C# 8.0+)
string? email = null;
email ??= "default@university.uz";
// email endi "default@university.uz"
// Amaliy misol — email yuborish:
string yuborishManzili = talaba?.EmailManzili ?? "admin@university.uz";
SendEmail(yuborishManzili);  // Doim ishlaydi
```

#### Nullable Reference Types (C# 8.0+)

Kompilyatorga "bu null bo'lishi mumkin" yoki "bu hech qachon null bo'lmasligi kerak" deb aytish imkoniyati.

C# 8.0+ — Nullable Reference Types

```csharp
#nullable enable  // Bu rejimni yoqamiz (yoki .csproj da global)
// string  — null bo'lmasligi KERAK (non-nullable)
// string? — null bo'lishi MUMKIN  (nullable)
class Talaba
{
public string  Ism;          // Non-nullable — doim qiymat bo'lishi kerak
public string? EmailManzili; // Nullable — null bo'lishi mumkin
}
// Kompilyator xavfli joylarni ko'rsatadi:
string ism = null;
// ⚠️ Warning CS8600: Converting null literal to non-nullable reference type.
string? optionalIm = null;  // ✅ To'g'ri
Console.WriteLine(optionalIm.ToUpper());
// ⚠️ Warning CS8602: Dereference of a possibly null reference.
// To'g'ri yondashuv:
if (optionalIm != null)
Console.WriteLine(optionalIm.ToUpper());  // ✅ Xavfsiz
// Yoki null-forgiving operator (ehtiyotkorlik bilan!):
Console.WriteLine(optionalIm!.ToUpper());
// ! — "men kafolat beraman, bu null emas" — lekin noto'g'ri bo'lsa NRE!
```

**✅ Null-safety: Kelajak shu yerda** Tony Hoare o'z nutqida aytganidek, yechim — nullable va non-nullable turlarni kompilyator darajasida farqlash. C# 8.0+ aynan shu yechimni taqdim etdi. Yangi loyihalarda `#nullable enable` ni doim yoqing.9

### Himoyalanish strategiyasi: Null-Safe kod yozish

#### Strategiya 1: 'null'ni oldini olish — default qiymat bering

**❌ Null qaytarish**

```csharp
string? GetEmail(int id)
{
    if (id <= 0)
        return null;  // ❌
    return "user@uni.uz";
}
```

**✅ Default qiymat qaytarish**

```csharp
string GetEmail(int id)
{
    if (id <= 0)
        return string.Empty;  // ✅
    return "user@uni.uz";
}
```

#### Strategiya 2: Null Object Pattern

Null o'rniga "bo'sh ob'yekt" yarating — kod hech qachon NRE bermaydi.

C# — Null Object Pattern

```csharp
class Talaba
{
    public string Ism   { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
<span class="cm">// "Bo'sh talaba" — null o'rniga ishlatiladi</span><span class="kw">public static readonly</span> <span class="ty">Talaba</span> NomaLum = <span class="kw">new</span>(){    Ism   = <span class="st">"Noma'lum"</span>,    Email = <span class="st">"no-email@university.uz"</span>};
}
// Ishlatish — hech qachon null bo'lmaydi:
Talaba talaba = GetStudent(id) ?? Talaba.NomaLum;
Console.WriteLine(talaba.Ism);   // ✅ Doim ishlaydi
Console.WriteLine(talaba.Email);  // ✅ Doim ishlaydi
```

#### Strategiya 3: Guard Clauses — erta chiqish

C# — Guard Clauses

```csharp
public void ProcessStudent(Talaba? talaba)
{
    // Guard clause — metod boshida null tekshiruvi
    if (talaba == null)
        throw new ArgumentNullException(nameof(talaba));
<span class="cm">// Yoki C# 11+:</span><span class="ty">ArgumentNullException</span>.<span class="fn">ThrowIfNull</span>(talaba);<span class="cm">// Bu yerdan pastda talaba hech qachon null emas — xavfsiz!</span>Console.<span class="fn">WriteLine</span>(<span class="st">$"Talaba: {talaba.Ism}"</span>);Console.<span class="fn">WriteLine</span>(<span class="st">$"Email: {talaba.Email}"</span>);
}
```

#### Strategiya 4: Operatorlarni birlashtirish

**❌ Uzun if-else zanjiri**

```csharp
string email;
Talaba? t = GetStudent(id);
if (t != null && t.Email != null)
    email = t.Email;
else
    email = "default@uni.uz";
```

**✅ Qisqa va xavfsiz**

```csharp
string email =
    GetStudent(id)?.Email
    ?? "default@uni.uz";
// Bir qatorda — xavfsiz!
```

### Xulosa: 'null'ni boshqarishni o'rganish

Null — bu dasturlashning haqiqati. Uni yo'q qilib bo'lmaydi, lekin uni boshqarish mumkin. Tony Hoare o'z xatosini tan olish orqali butun sanoatga xizmat qildi. Biz uning tajribasidan foydalanib, yanada yaxshi dasturlar yozishimiz mumkin.

**💡 Asosiy xulosalar**

* Null doim "qiymat yo'q" degan ma'noni anglatadi — lekin _nima uchun_ yo'qligi kontekstga bog'liq.
* Null faqat Reference Types uchun mavjud; Value Types uchun mavjud emas.
* Null operatsiyalari juda tez — faqat bitta xotira o'qish/yozish.
* Null xato holatlarini ifodalash uchun ishlatilmaydi — buning uchun exception ishlating.
* C# 8.0+ da `#nullable enable` — kompilyator darajasida null-safety.
* `?.` va `??` operatorlari kodni qisqa va xavfsiz qiladi.

***

#### Eslatma: uchta qoida

🔍 **1. Doimo null tekshiruvini bajaring**

Reference type o'zgaruvchilar bilan ishlashdan oldin `!= null` yoki `?.` operatorini ishlating. Bu sizning birinchi himoya chizig'ingiz.

🛡️ **2. Default qiymat bering**

Null qaytarish o'rniga ma'noli default qiymat yoki bo'sh ob'yekt qaytaring. `??` operatori va Null Object Pattern — eng yaxshi do'stlaringiz.

⚙️ **3. Kompilyatorga ishoning**

C# 8.0+ da `#nullable enable` yoqing. Kompilyator ogohlantirishlarini e'tiborsiz qoldirmang — ular NRE ni oldindan ko'rsatadi.

© Boboqandov Maxmud

Maqola [Christian Neumanns (freeCodeCamp)](https://www.freecodecamp.org/news/a-quick-and-thorough-guide-to-null-what-it-is-and-how-you-should-use-it-d170cea62840/) maqolasi asosida C# ga moslashtirildi va kengaytirildi.

Manba: [Microsoft Docs — Nullable Reference Types](https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references) · [Tony Hoare, QCon London 2009](https://qconlondon.com/london-2009/qconlondon.com/london-2009/speaker/Tony+Hoare.html)

<details>

<summary>illustrativ tasvirlar</summary>

<figure><img src="../.gitbook/assets/image (8).png" alt=""><figcaption></figcaption></figure>

<figure><img src="../.gitbook/assets/image (9).png" alt=""><figcaption></figcaption></figure>

</details>
