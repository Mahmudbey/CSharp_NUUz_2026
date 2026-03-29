<!DOCTYPE html>
<html lang="uz">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Null: Dasturlashtagi "Milliard Dollarlik Xato"</title>
<style>
  :root {
    --bg: #0f1117;
    --surface: #1a1d27;
    --surface2: #22263a;
    --border: #2e3250;
    --accent: #6c8ef7;
    --accent2: #a78bfa;
    --green: #34d399;
    --red: #f87171;
    --yellow: #fbbf24;
    --orange: #fb923c;
    --text: #e2e8f0;
    --muted: #8892b0;
    --code-bg: #0d1117;
  }
  * { box-sizing: border-box; margin: 0; padding: 0; }
  body {
    background: var(--bg);
    color: var(--text);
    font-family: 'Segoe UI', system-ui, sans-serif;
    font-size: 15px;
    line-height: 1.75;
  }

  /* ── HEADER ── */
  header {
    background: linear-gradient(135deg, #1a1d27 0%, #12152a 100%);
    border-bottom: 1px solid var(--border);
    padding: 48px 24px 40px;
    text-align: center;
  }
  .badge {
    display: inline-block;
    background: rgba(108,142,247,.15);
    border: 1px solid rgba(108,142,247,.35);
    color: var(--accent);
    font-size: 11px;
    font-weight: 600;
    letter-spacing: .08em;
    text-transform: uppercase;
    padding: 4px 12px;
    border-radius: 20px;
    margin-bottom: 18px;
  }
  header h1 {
    font-size: clamp(1.6rem, 4vw, 2.6rem);
    font-weight: 800;
    line-height: 1.2;
    margin-bottom: 14px;
  }
  header h1 span { color: var(--accent); }
  header p.sub {
    color: var(--muted);
    font-size: 14px;
    max-width: 520px;
    margin: 0 auto;
  }
  .meta {
    display: flex;
    justify-content: center;
    gap: 24px;
    margin-top: 22px;
    flex-wrap: wrap;
  }
  .meta span {
    font-size: 12px;
    color: var(--muted);
    display: flex;
    align-items: center;
    gap: 6px;
  }
  .meta span::before { content: '•'; color: var(--accent); }

  /* ── TOC ── */
  .toc-wrap {
    max-width: 820px;
    margin: 36px auto 0;
    padding: 0 24px;
  }
  .toc {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: 12px;
    padding: 22px 26px;
  }
  .toc h3 {
    font-size: 12px;
    text-transform: uppercase;
    letter-spacing: .1em;
    color: var(--muted);
    margin-bottom: 14px;
  }
  .toc ol {
    padding-left: 18px;
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 6px 24px;
  }
  @media(max-width:560px){ .toc ol { grid-template-columns: 1fr; } }
  .toc li { font-size: 13px; color: var(--accent); }
  .toc li span { color: var(--text); }

  /* ── MAIN ── */
  main {
    max-width: 820px;
    margin: 0 auto;
    padding: 40px 24px 80px;
  }

  /* ── SECTION ── */
  section { margin-bottom: 60px; }
  .section-label {
    display: flex;
    align-items: center;
    gap: 12px;
    margin-bottom: 20px;
  }
  .section-num {
    width: 32px; height: 32px;
    background: linear-gradient(135deg, var(--accent), var(--accent2));
    border-radius: 8px;
    display: flex; align-items: center; justify-content: center;
    font-size: 13px; font-weight: 700; color: #fff;
    flex-shrink: 0;
  }
  h2 {
    font-size: 1.35rem;
    font-weight: 700;
    color: var(--text);
  }
  h3 {
    font-size: 1.05rem;
    font-weight: 600;
    color: var(--accent2);
    margin: 28px 0 10px;
  }
  p { margin-bottom: 14px; color: #c8d0e0; }

  /* ── CALLOUT ── */
  .callout {
    border-radius: 10px;
    padding: 16px 20px;
    margin: 20px 0;
    border-left: 3px solid;
    font-size: 14px;
  }
  .callout.info  { background: rgba(108,142,247,.08); border-color: var(--accent);  color: #b8c8f8; }
  .callout.warn  { background: rgba(251,191,36,.07);  border-color: var(--yellow);  color: #f5d98a; }
  .callout.danger{ background: rgba(248,113,113,.07); border-color: var(--red);     color: #fca5a5; }
  .callout.success{background: rgba(52,211,153,.07);  border-color: var(--green);   color: #6ee7b7; }
  .callout strong { display: block; margin-bottom: 4px; font-size: 12px; text-transform: uppercase; letter-spacing: .06em; opacity: .75; }

  /* ── QUOTE ── */
  blockquote {
    background: var(--surface2);
    border-left: 4px solid var(--accent2);
    border-radius: 0 10px 10px 0;
    padding: 18px 22px;
    margin: 22px 0;
    font-style: italic;
    color: #c4b5fd;
    font-size: 14.5px;
    line-height: 1.7;
  }
  blockquote cite {
    display: block;
    margin-top: 10px;
    font-style: normal;
    font-size: 12px;
    color: var(--muted);
  }

  /* ── CODE BLOCK ── */
  .code-wrap {
    background: var(--code-bg);
    border: 1px solid var(--border);
    border-radius: 10px;
    margin: 18px 0;
    overflow: hidden;
  }
  .code-header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 8px 16px;
    background: #161b22;
    border-bottom: 1px solid var(--border);
  }
  .code-lang {
    font-size: 11px;
    font-weight: 600;
    color: var(--accent);
    text-transform: uppercase;
    letter-spacing: .06em;
  }
  .code-dots { display: flex; gap: 6px; }
  .code-dots span {
    width: 10px; height: 10px; border-radius: 50%;
  }
  .code-dots span:nth-child(1){ background:#ff5f57; }
  .code-dots span:nth-child(2){ background:#febc2e; }
  .code-dots span:nth-child(3){ background:#28c840; }
  pre {
    padding: 18px 20px;
    overflow-x: auto;
    font-family: 'Cascadia Code', 'Fira Code', 'Consolas', monospace;
    font-size: 13px;
    line-height: 1.65;
    tab-size: 4;
  }
  code { color: #e2e8f0; }

  /* Syntax highlight helpers */
  .kw  { color: #c792ea; }   /* keyword */
  .ty  { color: #82aaff; }   /* type */
  .st  { color: #c3e88d; }   /* string */
  .cm  { color: #546e7a; font-style: italic; } /* comment */
  .nm  { color: #f78c6c; }   /* number/literal */
  .fn  { color: #82aaff; }   /* function */
  .op  { color: #89ddff; }   /* operator */
  .ok  { color: #34d399; }   /* good */
  .err { color: #f87171; }   /* bad */
  .warn-c { color: #fbbf24; } /* warning */

  /* ── ANALOGY BOX ── */
  .analogy {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: 12px;
    padding: 22px 24px;
    margin: 22px 0;
    display: flex;
    gap: 16px;
    align-items: flex-start;
  }
  .analogy-icon { font-size: 2rem; flex-shrink: 0; line-height: 1; }
  .analogy-body h4 { font-size: 14px; font-weight: 600; color: var(--accent); margin-bottom: 6px; }
  .analogy-body p  { font-size: 13.5px; color: #a8b4cc; margin: 0; }

  /* ── COMPARISON TABLE ── */
  .compare {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 14px;
    margin: 20px 0;
  }
  @media(max-width:540px){ .compare { grid-template-columns: 1fr; } }
  .compare-card {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: 10px;
    padding: 16px 18px;
  }
  .compare-card.bad  { border-top: 3px solid var(--red); }
  .compare-card.good { border-top: 3px solid var(--green); }
  .compare-card h4 {
    font-size: 12px;
    text-transform: uppercase;
    letter-spacing: .07em;
    margin-bottom: 10px;
  }
  .compare-card.bad  h4 { color: var(--red); }
  .compare-card.good h4 { color: var(--green); }

  /* ── DATA TYPE TABLE ── */
  table {
    width: 100%;
    border-collapse: collapse;
    margin: 18px 0;
    font-size: 13.5px;
  }
  th {
    background: var(--surface2);
    color: var(--muted);
    font-size: 11px;
    text-transform: uppercase;
    letter-spacing: .07em;
    padding: 10px 14px;
    text-align: left;
    border-bottom: 1px solid var(--border);
  }
  td {
    padding: 10px 14px;
    border-bottom: 1px solid rgba(46,50,80,.5);
    color: #c8d0e0;
  }
  tr:last-child td { border-bottom: none; }
  tr:hover td { background: rgba(108,142,247,.04); }
  .tag {
    display: inline-block;
    padding: 2px 8px;
    border-radius: 4px;
    font-size: 11px;
    font-weight: 600;
  }
  .tag.yes  { background: rgba(52,211,153,.15); color: var(--green); }
  .tag.no   { background: rgba(248,113,113,.15); color: var(--red); }
  .tag.high { background: rgba(251,191,36,.15);  color: var(--yellow); }
  .tag.mid  { background: rgba(108,142,247,.15); color: var(--accent); }
  .tag.low  { background: rgba(52,211,153,.15);  color: var(--green); }

  /* ── STEP LIST ── */
  .steps { list-style: none; padding: 0; margin: 18px 0; }
  .steps li {
    display: flex;
    gap: 14px;
    align-items: flex-start;
    padding: 12px 0;
    border-bottom: 1px solid rgba(46,50,80,.4);
  }
  .steps li:last-child { border-bottom: none; }
  .step-num {
    width: 26px; height: 26px;
    background: rgba(108,142,247,.15);
    border: 1px solid rgba(108,142,247,.3);
    border-radius: 6px;
    display: flex; align-items: center; justify-content: center;
    font-size: 12px; font-weight: 700; color: var(--accent);
    flex-shrink: 0; margin-top: 2px;
  }
  .steps li p { margin: 0; font-size: 14px; color: #b8c4d8; }
  .steps li strong { color: var(--text); }

  /* ── RULE CARDS ── */
  .rules {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    gap: 16px;
    margin: 24px 0;
  }
  @media(max-width:600px){ .rules { grid-template-columns: 1fr; } }
  .rule-card {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: 12px;
    padding: 20px 18px;
    text-align: center;
  }
  .rule-icon { font-size: 1.8rem; margin-bottom: 10px; }
  .rule-card h4 { font-size: 13px; font-weight: 700; color: var(--accent); margin-bottom: 8px; }
  .rule-card p  { font-size: 12.5px; color: var(--muted); margin: 0; line-height: 1.55; }

  /* ── DIVIDER ── */
  hr { border: none; border-top: 1px solid var(--border); margin: 40px 0; }

  /* ── FOOTER ── */
  footer {
    text-align: center;
    padding: 32px 24px;
    border-top: 1px solid var(--border);
    color: var(--muted);
    font-size: 12.5px;
  }
  footer a { color: var(--accent); text-decoration: none; }
  footer a:hover { text-decoration: underline; }

  /* ── INLINE CODE ── */
  p code, li code, td code {
    background: rgba(108,142,247,.12);
    color: #a5b4fc;
    padding: 1px 6px;
    border-radius: 4px;
    font-family: 'Cascadia Code', 'Fira Code', monospace;
    font-size: 12.5px;
  }

  ul.plain { padding-left: 20px; margin: 10px 0 14px; }
  ul.plain li { font-size: 14px; color: #b0bcd4; margin-bottom: 5px; }
</style>
</head>
<body>

<!-- ═══════════════════════════════════════════════════════ HEADER -->
<header>
  <div class="badge">C# · 1-kurs talabalari uchun</div>
  <h1>Null: Dasturlashtagi<br><span>"Milliard Dollarlik Xato"</span></h1>
  <p class="sub">Har bir dasturchi bilishi shart bo'lgan tushuncha — sodda tilda, real misollar bilan.</p>
  <div class="meta">
    <span>Senior Software Architect</span>
    <span>C# · .NET</span>
    <span>Boshlang'ich daraja</span>
  </div>
</header>

<!-- ═══════════════════════════════════════════════════════ TOC -->
<div class="toc-wrap">
  <div class="toc">
    <h3>Mundarija</h3>
    <ol>
      <li><span>Ma'lumot turlari: Asosdan boshlaylik</span></li>
      <li><span>Null o'zi nima?</span></li>
      <li><span>Tarixiy xato: "Milliard dollarlik xato"</span></li>
      <li><span>Xavf va oqibatlar</span></li>
      <li><span>C# da null bilan ishlash</span></li>
      <li><span>Himoyalanish strategiyasi</span></li>
    </ol>
  </div>
</div>

<!-- ═══════════════════════════════════════════════════════ MAIN -->
<main>

<!-- ─────────────────────────────────────── SECTION 1 -->
<section>
  <div class="section-label">
    <div class="section-num">1</div>
    <h2>Ma'lumot Turlari: Asosdan Boshlaylik</h2>
  </div>

  <p>Dasturlashni o'rganishda birinchi savol: <em>"Kompyuter ma'lumotlarni qanday saqlaydi?"</em> Bunga javob bermasdan null tushunchasini tushunib bo'lmaydi. Shuning uchun avval asosdan boshlaymiz.</p>

  <div class="analogy">
    <div class="analogy-icon">🗄️</div>
    <div class="analogy-body">
      <h4>Xotira = Katakchalar to'plami</h4>
      <p>Kompyuter xotirasini (RAM) ulkan jadval deb tasavvur qiling. Har bir katakchaning o'z manzili bor. O'zgaruvchi e'lon qilganingizda, dastur shu jadvaldan bo'sh katakcha ajratib oladi va u yerga qiymat yozadi.</p>
    </div>
  </div>

  <h3>Value Types va Reference Types</h3>
  <p>C# da barcha ma'lumot turlari ikki guruhga bo'linadi. Bu farqni tushunish — null ni tushunishning kaliti.</p>

  <table>
    <thead>
      <tr>
        <th>Tur</th>
        <th>Misol</th>
        <th>Xotirada nima saqlanadi?</th>
        <th>Null bo'lishi mumkinmi?</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>Value Type</strong> (Qiymat turi)</td>
        <td><code>int</code>, <code>double</code>, <code>bool</code>, <code>char</code></td>
        <td>Qiymatning o'zi (masalan: <code>42</code>)</td>
        <td><span class="tag no">Yo'q</span></td>
      </tr>
      <tr>
        <td><strong>Reference Type</strong> (Havola turi)</td>
        <td><code>string</code>, <code>class</code>, <code>array</code></td>
        <td>Ob'yekt joylashgan xotira manzili</td>
        <td><span class="tag yes">Ha</span></td>
      </tr>
    </tbody>
  </table>

  <div class="analogy">
    <div class="analogy-icon">📬</div>
    <div class="analogy-body">
      <h4>Farqni tushunish uchun taqqoslash</h4>
      <p><strong>Value Type</strong> — xatga pul solib yuborish. Qiymat to'g'ridan-to'g'ri o'zgaruvchida turadi.<br>
      <strong>Reference Type</strong> — xatga bank kartasi raqamini yozib yuborish. O'zgaruvchida pul emas, balki pulning <em>manzili</em> turadi.</p>
    </div>
  </div>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — Value Type vs Reference Type</span>
    </div>
    <pre><code><span class="cm">// ── VALUE TYPES ──────────────────────────────────────────</span>
<span class="cm">// Qiymat to'g'ridan-to'g'ri o'zgaruvchida saqlanadi</span>

<span class="ty">int</span> yosh = <span class="nm">20</span>;          <span class="cm">// Xotirada: [20]</span>
<span class="ty">double</span> baho = <span class="nm">4.5</span>;      <span class="cm">// Xotirada: [4.5]</span>
<span class="ty">bool</span> faol = <span class="kw">true</span>;       <span class="cm">// Xotirada: [true]</span>

<span class="cm">// Value type hech qachon null bo'lmaydi!</span>
<span class="cm">// int yosh = null;  ← Bu xato beradi</span>


<span class="cm">// ── REFERENCE TYPES ──────────────────────────────────────</span>
<span class="cm">// O'zgaruvchida ob'yektning xotira manzili saqlanadi</span>

<span class="ty">string</span> ism = <span class="st">"Alisher"</span>;  <span class="cm">// O'zgaruvchida: [manzil → "Alisher"]</span>
<span class="ty">int</span>[] sonlar = { <span class="nm">1</span>, <span class="nm">2</span>, <span class="nm">3</span> }; <span class="cm">// O'zgaruvchida: [manzil → massiv]</span>

<span class="cm">// Reference type null bo'lishi MUMKIN:</span>
<span class="ty">string</span> familiya = <span class="kw">null</span>;  <span class="cm">// O'zgaruvchida: [hech qanday manzil yo'q]</span></code></pre>
  </div>

  <div class="callout info">
    <strong>💡 Eslab qoling</strong>
    Value type o'zgaruvchilar doim qiymatga ega. Reference type o'zgaruvchilar esa "hali hech narsaga ishora qilmayapman" degan holatda bo'lishi mumkin — bu holat <strong>null</strong> deyiladi.
  </div>
</section>

<!-- ─────────────────────────────────────── SECTION 2 -->
<section>
  <div class="section-label">
    <div class="section-num">2</div>
    <h2>Null O'zi Nima?</h2>
  </div>

  <div class="analogy">
    <div class="analogy-icon">📚</div>
    <div class="analogy-body">
      <h4>Kutubxona misoli</h4>
      <p>Siz kutubxonada kitob qidiryapsiz. Javon raqamini bilib oldingiz, javonga borib qaradingiz — lekin u yerda hech narsa yo'q. Javon bo'sh. Kutubxonachi: <em>"Bu kitob bizda mavjud emas"</em> deydi. Dasturlashda bu holat — <strong>null</strong>.</p>
    </div>
  </div>

  <p>Texnik jihatdan: <strong>null</strong> — bu Reference Type o'zgaruvchining hech qanday ob'yektga ishora qilmayotganligini bildiruvchi maxsus qiymat. U "bo'sh xotira manzili" emas — u umuman manzil yo'qligini anglatadi.</p>

  <h3>Null qachon paydo bo'ladi?</h3>

  <ul class="steps">
    <li>
      <div class="step-num">1</div>
      <p><strong>E'lon qilingan, lekin qiymat berilmagan o'zgaruvchi.</strong> Sinf ichidagi reference type maydonlar avtomatik null bo'ladi.</p>
    </li>
    <li>
      <div class="step-num">2</div>
      <p><strong>Metod null qaytarsa.</strong> Masalan, ma'lumotlar bazasida qidirilgan narsa topilmasa.</p>
    </li>
    <li>
      <div class="step-num">3</div>
      <p><strong>Dasturchi ataylab null tayinlasa.</strong> "Bu o'zgaruvchi hali tayyor emas" degan ma'noda.</p>
    </li>
    <li>
      <div class="step-num">4</div>
      <p><strong>Tashqi manbadan (API, fayl, foydalanuvchi) ma'lumot kelmasa.</strong> Internet uzilishi, fayl yo'qligi va hokazo.</p>
    </li>
  </ul>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — Null qanday ko'rinadi?</span>
    </div>
    <pre><code><span class="cm">// 1. Ataylab null tayinlash</span>
<span class="ty">string</span> talabaNomi = <span class="kw">null</span>;

<span class="cm">// 2. Sinf ichida avtomatik null</span>
<span class="kw">class</span> <span class="ty">Talaba</span>
{
    <span class="kw">public</span> <span class="ty">string</span> Ism;    <span class="cm">// Avtomatik null</span>
    <span class="kw">public</span> <span class="ty">string</span> Email;  <span class="cm">// Avtomatik null</span>
    <span class="kw">public</span> <span class="ty">int</span>    Yosh;   <span class="cm">// Value type — avtomatik 0 (null emas!)</span>
}

<span class="cm">// 3. Metod null qaytarishi</span>
<span class="ty">string</span> <span class="fn">GetStudentName</span>(<span class="ty">int</span> id)
{
    <span class="kw">if</span> (id <= <span class="nm">0</span>)
        <span class="kw">return</span> <span class="kw">null</span>;  <span class="cm">// Topilmadi — null qaytaramiz</span>

    <span class="kw">return</span> <span class="st">"Alisher Navoiy"</span>;
}

<span class="cm">// 4. Null tekshiruvi</span>
<span class="ty">string</span> ism = <span class="fn">GetStudentName</span>(<span class="nm">-1</span>);

<span class="kw">if</span> (ism == <span class="kw">null</span>)
    Console.<span class="fn">WriteLine</span>(<span class="st">"Talaba topilmadi."</span>);
<span class="kw">else</span>
    Console.<span class="fn">WriteLine</span>(<span class="st">$"Talaba: {ism}"</span>);</code></pre>
  </div>
</section>

<!-- ─────────────────────────────────────── SECTION 3 -->
<section>
  <div class="section-label">
    <div class="section-num">3</div>
    <h2>Tarixiy Xato: "The Billion Dollar Mistake"</h2>
  </div>

  <p>1965-yilda britaniyalik kompyuter olimi <strong>Toni Xoar (Tony Hoare)</strong> ALGOL W dasturlash tilini yaratayotganida birinchi marta <em>null reference</em> tushunchasini kiritdi. U o'sha paytda buni oddiy va qulay yechim deb hisobladi.</p>

  <blockquote>
    "Null reference ni ixtiro qilganimni o'zimning <strong>milliard dollarlik xatom</strong> deb atayman. O'sha paytda buni amalga oshirish juda oson edi. Lekin bu noaniq havolalar natijasida tizimlarning ishdan chiqishi, xavfsizlik zaifliklari va tizim nosozliklari paydo bo'ldi. Bu oxirgi 40 yil davomida milliardlab dollar zarar keltirgan."
    <cite>— Tony Hoare, QCon London, 2009</cite>
  </blockquote>

  <h3>Nima uchun bu shuncha katta muammo?</h3>

  <p>Null ning asosiy muammosi — u <em>ko'rinmas</em>. Kompilyator sizga "bu o'zgaruvchi null bo'lishi mumkin" deb ogohlantirmaydi (kamida eski versiyalarda). Dastur yoziladi, testdan o'tadi, ishga tushiriladi — va keyin kutilmagan paytda "portlaydi".</p>

  <div class="callout warn">
    <strong>⚠️ Statistika</strong>
    Stack Overflow ma'lumotlariga ko'ra, "NullReferenceException" so'rovi yiliga <strong>20 million marta</strong> qidiriladi. Bu dasturchilar uchun eng keng tarqalgan muammodir.
  </div>

  <div class="analogy">
    <div class="analogy-icon">💣</div>
    <div class="analogy-body">
      <h4>Nima uchun "milliard dollar"?</h4>
      <p>Null xatolari tufayli yirik kompaniyalar (bank tizimlari, aviakompaniyalar, tibbiyot dasturlari) ishdan chiqqan. Har bir "crash" — bu yo'qotilgan foydalanuvchilar, qayta tiklash xarajatlari, va ba'zan hayot uchun xavfli vaziyatlar. Yig'indisi — milliardlab dollar.</p>
    </div>
  </div>
</section>

<!-- ─────────────────────────────────────── SECTION 4 -->
<section>
  <div class="section-label">
    <div class="section-num">4</div>
    <h2>Xavf va Oqibatlar: NullReferenceException</h2>
  </div>

  <p>C# da null ob'yektga murojaat qilsangiz, dastur darhol <strong>NullReferenceException (NRE)</strong> xatosi bilan to'xtaydi. Bu eng keng tarqalgan runtime xatoliklardan biridir.</p>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — NullReferenceException qanday yuzaga keladi?</span>
    </div>
    <pre><code><span class="ty">string</span> talabaNomi = <span class="kw">null</span>;

<span class="cm">// ❌ XATO: null ob'yektdan .Length so'ramoqchimiz</span>
<span class="ty">int</span> uzunlik = talabaNomi.<span class="fn">Length</span>;
<span class="cm">// → System.NullReferenceException: Object reference not set to an instance of an object.</span>
<span class="cm">//   Dastur shu yerda to'xtaydi!</span>


<span class="cm">// ── Real loyiha misoli ──────────────────────────────────</span>
<span class="kw">class</span> <span class="ty">Talaba</span>
{
    <span class="kw">public</span> <span class="ty">string</span> Ism   { <span class="kw">get</span>; <span class="kw">set</span>; }
    <span class="kw">public</span> <span class="ty">string</span> Email { <span class="kw">get</span>; <span class="kw">set</span>; }
}

<span class="ty">Talaba</span> <span class="fn">GetTalaba</span>(<span class="ty">int</span> id)
{
    <span class="kw">if</span> (id != <span class="nm">42</span>)
        <span class="kw">return</span> <span class="kw">null</span>;  <span class="cm">// Topilmadi</span>

    <span class="kw">return</span> <span class="kw">new</span> <span class="ty">Talaba</span> { Ism = <span class="st">"Alisher"</span>, Email = <span class="st">"ali@uni.uz"</span> };
}

<span class="ty">Talaba</span> t = <span class="fn">GetTalaba</span>(<span class="nm">99</span>);  <span class="cm">// null qaytadi</span>

Console.<span class="fn">WriteLine</span>(t.Ism);   <span class="cm">// ❌ NullReferenceException!</span>
<span class="cm">// Foydalanuvchi ko'radi: "500 Internal Server Error"</span></code></pre>
  </div>

  <h3>Real loyihalarda oqibatlar</h3>

  <table>
    <thead>
      <tr><th>Vaziyat</th><th>Null sababi</th><th>Oqibat</th><th>Ehtimollik</th></tr>
    </thead>
    <tbody>
      <tr>
        <td>Database so'rovi</td>
        <td>Ma'lumot topilmadi</td>
        <td>500 Server Error</td>
        <td><span class="tag high">Juda yuqori</span></td>
      </tr>
      <tr>
        <td>API javob</td>
        <td>Network xatosi</td>
        <td>Servis to'xtaydi</td>
        <td><span class="tag high">Yuqori</span></td>
      </tr>
      <tr>
        <td>Foydalanuvchi kiritishi</td>
        <td>Bo'sh maydon</td>
        <td>Noto'g'ri xabar</td>
        <td><span class="tag high">Juda yuqori</span></td>
      </tr>
      <tr>
        <td>Fayl o'qish</td>
        <td>Fayl yo'q</td>
        <td>Ma'lumot yo'qolishi</td>
        <td><span class="tag mid">O'rtacha</span></td>
      </tr>
      <tr>
        <td>Collection lookup</td>
        <td>Noto'g'ri kalit</td>
        <td>Dastur crash</td>
        <td><span class="tag mid">O'rtacha</span></td>
      </tr>
    </tbody>
  </table>

  <div class="callout danger">
    <strong>🔴 Asosiy qoida</strong>
    Har qanday tashqi manbadan kelgan ma'lumot — database, API, fayl, foydalanuvchi kiritishi — null bo'lishi mumkin. <strong>Doimo tekshiring!</strong>
  </div>
</section>

<!-- ─────────────────────────────────────── SECTION 5 -->
<section>
  <div class="section-label">
    <div class="section-num">5</div>
    <h2>C# da Null bilan Ishlash</h2>
  </div>

  <h3>Eski uslub: if-else tekshiruvi</h3>
  <p>Dastlabki dasturchilar har doim <code>if</code> bloki orqali tekshirishar edi. Bu ishlaydi, lekin kod juda ko'p <code>if-else</code> bloklari bilan to'lib ketadi.</p>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — Eski uslub</span>
    </div>
    <pre><code><span class="ty">string</span> ism = <span class="fn">GetStudentName</span>();

<span class="kw">if</span> (ism != <span class="kw">null</span>)
{
    Console.<span class="fn">WriteLine</span>(<span class="st">$"Talaba: {ism}"</span>);
    Console.<span class="fn">WriteLine</span>(<span class="st">$"Uzunligi: {ism.Length}"</span>);
}
<span class="kw">else</span>
{
    Console.<span class="fn">WriteLine</span>(<span class="st">"Talaba topilmadi."</span>);
}
<span class="cm">// Ishlaydi, lekin har joyda shunday yozish zerikarli...</span></code></pre>
  </div>

  <h3>Zamonaviy uslub 1: Null-Conditional Operator <code>?.</code></h3>
  <p>C# 6.0 dan boshlab: agar ob'yekt null bo'lsa, xato bermaydi — shunchaki null qaytaradi.</p>

  <div class="compare">
    <div class="compare-card bad">
      <h4>❌ Xavfli</h4>
      <div class="code-wrap" style="margin:0">
        <pre style="padding:12px 14px;font-size:12px"><code><span class="ty">string</span> ism = <span class="fn">GetName</span>();
<span class="ty">int</span> n = ism.<span class="fn">Length</span>;
<span class="cm">// null bo'lsa → CRASH!</span></code></pre>
      </div>
    </div>
    <div class="compare-card good">
      <h4>✅ Xavfsiz</h4>
      <div class="code-wrap" style="margin:0">
        <pre style="padding:12px 14px;font-size:12px"><code><span class="ty">string</span> ism = <span class="fn">GetName</span>();
<span class="ty">int</span>? n = ism?.<span class="fn">Length</span>;
<span class="cm">// null bo'lsa → n = null</span></code></pre>
      </div>
    </div>
  </div>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — Null-Conditional Operator (?.) misollari</span>
    </div>
    <pre><code><span class="ty">string</span> ism = <span class="fn">GetStudentName</span>();

<span class="cm">// ?. — "agar null bo'lmasa, davom et"</span>
<span class="ty">int</span>? uzunlik = ism?.<span class="fn">Length</span>;       <span class="cm">// null bo'lsa → uzunlik = null</span>
<span class="ty">string</span> katta = ism?.<span class="fn">ToUpper</span>();   <span class="cm">// null bo'lsa → katta = null</span>

<span class="cm">// Zanjir holida ham ishlaydi:</span>
<span class="kw">class</span> <span class="ty">Talaba</span> { <span class="kw">public</span> <span class="ty">Manzil</span> Manzil { <span class="kw">get</span>; <span class="kw">set</span>; } }
<span class="kw">class</span> <span class="ty">Manzil</span> { <span class="kw">public</span> <span class="ty">string</span> Shahar { <span class="kw">get</span>; <span class="kw">set</span>; } }

<span class="ty">Talaba</span> t = <span class="fn">GetTalaba</span>();
<span class="ty">string</span> shahar = t?.Manzil?.Shahar;
<span class="cm">// t null bo'lsa → shahar = null (xato yo'q!)</span>
<span class="cm">// t.Manzil null bo'lsa → shahar = null (xato yo'q!)</span></code></pre>
  </div>

  <h3>Zamonaviy uslub 2: Null-Coalescing Operator <code>??</code></h3>
  <p>"Null bo'lsa, o'rniga shu qiymatni ishlatgin" — default qiymat berish uchun.</p>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — Null-Coalescing Operator (??) misollari</span>
    </div>
    <pre><code><span class="ty">string</span> ism = <span class="fn">GetStudentName</span>();

<span class="cm">// ?? — "null bo'lsa, o'ng tomondagini ishlatgin"</span>
<span class="ty">string</span> korinishIsm = ism ?? <span class="st">"Noma'lum talaba"</span>;
Console.<span class="fn">WriteLine</span>(korinishIsm);  <span class="cm">// Hech qachon null bo'lmaydi!</span>

<span class="cm">// ?. va ?? ni birlashtirib ishlatish — eng kuchli kombinatsiya:</span>
<span class="ty">Talaba</span> t = <span class="fn">GetTalaba</span>(<span class="nm">99</span>);
<span class="ty">string</span> email = t?.Email ?? <span class="st">"noma'lum@uni.uz"</span>;
<span class="ty">int</span>    uzunlik = t?.Ism?.<span class="fn">Length</span> ?? <span class="nm">0</span>;

Console.<span class="fn">WriteLine</span>(<span class="st">$"Email: {email}"</span>);    <span class="cm">// Xavfsiz!</span>
Console.<span class="fn">WriteLine</span>(<span class="st">$"Uzunlik: {uzunlik}"</span>); <span class="cm">// Xavfsiz!</span></code></pre>
  </div>

  <h3>Zamonaviy uslub 3: Nullable Reference Types (C# 8.0+)</h3>
  <p>C# 8.0 dan boshlab kompilyatorga "null xavfi" haqida ogohlantirish imkoniyatini berdik. Bu eng kuchli himoya vositasi.</p>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — Nullable Reference Types (#nullable enable)</span>
    </div>
    <pre><code><span class="warn-c">#nullable enable</span>  <span class="cm">// Bu rejimni yoqamiz</span>

<span class="cm">// string  → null bo'lmasligi KERAK</span>
<span class="cm">// string? → null bo'lishi MUMKIN</span>

<span class="ty">string</span>  tasdiqlanganIsm = <span class="st">"Alisher"</span>;  <span class="ok">// ✅ To'g'ri</span>
<span class="ty">string</span>? ixtiyoriyIsm   = <span class="kw">null</span>;        <span class="ok">// ✅ To'g'ri — ? belgisi ruxsat beradi</span>

<span class="cm">// tasdiqlanganIsm = null;  ← ⚠️ Kompilyator ogohlantiradi!</span>


<span class="kw">void</span> <span class="fn">IsmiChop</span>(<span class="ty">string</span> ism)  <span class="cm">// Non-nullable — null kelmaydi</span>
{
    Console.<span class="fn">WriteLine</span>(ism.<span class="fn">ToUpper</span>());  <span class="ok">// Xavfsiz!</span>
}

<span class="kw">void</span> <span class="fn">XavfsizChop</span>()
{
    <span class="ty">string</span>? ism = <span class="fn">GetOptionalName</span>();

    <span class="cm">// IsmiChop(ism);  ← ⚠️ Kompilyator: "Possible null reference"</span>

    <span class="cm">// To'g'ri uslub — avval tekshir:</span>
    <span class="kw">if</span> (ism != <span class="kw">null</span>)
    {
        <span class="fn">IsmiChop</span>(ism);  <span class="ok">// ✅ Endi xavfsiz</span>
    }
}</code></pre>
  </div>

  <div class="callout success">
    <strong>✅ Tavsiya</strong>
    Yangi loyihalarni har doim <code>#nullable enable</code> bilan boshlang. Kompilyator sizning "null xavfsizligi bo'yicha shaxsiy yordamchingiz"ga aylanadi.
  </div>
</section>

<!-- ─────────────────────────────────────── SECTION 6 -->
<section>
  <div class="section-label">
    <div class="section-num">6</div>
    <h2>Himoyalanish Strategiyasi</h2>
  </div>

  <h3>Strategiya 1: Guard Clauses — Erta Tekshiruv</h3>
  <p>Metod boshida null tekshiring va darhol chiqing. Bu kodni o'qishni osonlashtiradi.</p>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — Guard Clauses</span>
    </div>
    <pre><code><span class="kw">void</span> <span class="fn">TalabaQayta</span>(<span class="ty">Talaba</span> talaba)
{
    <span class="cm">// Guard clause — erta chiqish</span>
    <span class="kw">if</span> (talaba == <span class="kw">null</span>)
    {
        Console.<span class="fn">WriteLine</span>(<span class="st">"Xato: talaba null bo'lishi mumkin emas."</span>);
        <span class="kw">return</span>;
    }

    <span class="cm">// Bu yerga kelganda talaba null emas — xavfsiz!</span>
    Console.<span class="fn">WriteLine</span>(<span class="st">$"Talaba: {talaba.Ism}"</span>);
    Console.<span class="fn">WriteLine</span>(<span class="st">$"Email:  {talaba.Email}"</span>);
}

<span class="cm">// C# 11+ da yanada qisqaroq:</span>
<span class="kw">void</span> <span class="fn">TalabaQayta</span>(<span class="ty">Talaba</span> talaba)
{
    ArgumentNullException.<span class="fn">ThrowIfNull</span>(talaba);
    <span class="cm">// Endi talaba null emas — davom etamiz</span>
}</code></pre>
  </div>

  <h3>Strategiya 2: Null Object Pattern — Bo'sh Ob'yekt</h3>
  <p>Null qaytarish o'rniga "bo'sh" lekin ishlaydigan ob'yekt qaytaring. Bu null tekshiruvlarini butunlay yo'q qiladi.</p>

  <div class="code-wrap">
    <div class="code-header">
      <div class="code-dots"><span></span><span></span><span></span></div>
      <span class="code-lang">C# — Null Object Pattern</span>
    </div>
    <pre><code><span class="kw">class</span> <span class="ty">Talaba</span>
{
    <span class="kw">public</span> <span class="ty">string</span> Ism   { <span class="kw">get</span>; <span class="kw">set</span>; }
    <span class="kw">public</span> <span class="ty">string</span> Email { <span class="kw">get</span>; <span class="kw">set</span>; }

    <span class="cm">// "Bo'sh talaba" — null o'rniga ishlatamiz</span>
    <span class="kw">public static</span> <span class="ty">Talaba</span> Noma'lum => <span class="kw">new</span> <span class="ty">Talaba</span>
    {
        Ism   = <span class="st">"Noma'lum"</span>,
        Email = <span class="st">"no-email@uni.uz"</span>
    };
}

<span class="ty">Talaba</span> <span class="fn">GetTalaba</span>(<span class="ty">int</span> id)
{
    <span class="cm">// Topilmasa null emas, bo'sh ob'yekt qaytaramiz</span>
    <span class="kw">if</span> (id <= <span class="nm">0</span>)
        <span class="kw">return</span> Talaba.Noma'lum;

    <span class="kw">return</span> <span class="kw">new</span> <span class="ty">Talaba</span> { Ism = <span class="st">"Alisher"</span>, Email = <span class="st">"ali@uni.uz"</span> };
}

<span class="cm">// Ishlatish — null tekshiruvi KERAK EMAS!</span>
<span class="ty">Talaba</span> t = <span class="fn">GetTalaba</span>(<span class="nm">-1</span>);
Console.<span class="fn">WriteLine</span>(t.Ism);   <span class="ok">// "Noma'lum" — hech qachon crash bo'lmaydi!</span>
Console.<span class="fn">WriteLine</span>(t.Email);  <span class="ok">// "no-email@uni.uz"</span></code></pre>
  </div>

  <h3>Strategiya 3: Default Qiymatlar</h3>
  <p>Null qaytarish o'rniga ma'noli default qiymat bering.</p>

  <div class="compare">
    <div class="compare-card bad">
      <h4>❌ Yomon yondashuv</h4>
      <div class="code-wrap" style="margin:0">
        <pre style="padding:12px 14px;font-size:12px"><code><span class="ty">string</span> <span class="fn">GetEmail</span>(<span class="ty">int</span> id)
{
    <span class="kw">if</span> (id <= <span class="nm">0</span>)
        <span class="kw">return</span> <span class="kw">null</span>; <span class="cm">// Xavfli!</span>
    <span class="kw">return</span> <span class="st">"ali@uni.uz"</span>;
}</code></pre>
      </div>
    </div>
    <div class="compare-card good">
      <h4>✅ Yaxshi yondashuv</h4>
      <div class="code-wrap" style="margin:0">
        <pre style="padding:12px 14px;font-size:12px"><code><span class="ty">string</span> <span class="fn">GetEmail</span>(<span class="ty">int</span> id)
{
    <span class="kw">if</span> (id <= <span class="nm">0</span>)
        <span class="kw">return</span> <span class="ty">string</span>.Empty; <span class="cm">// Xavfsiz!</span>
    <span class="kw">return</span> <span class="st">"ali@uni.uz"</span>;
}</code></pre>
      </div>
    </div>
  </div>

  <hr>

  <h3>Xulosa: Null dan Qo'rqmaslik, Uni Boshqarishni O'rganish</h3>
  <p>Null — bu dasturlashning haqiqati. Uni yo'q qilib bo'lmaydi, lekin uni boshqarish mumkin. Muammo null ning o'zida emas — uni <em>tekshirmaslikda</em>.</p>

  <div class="callout info">
    <strong>💡 Asosiy fikr</strong>
    Zamonaviy C# sizga kuchli vositalar beradi: <code>?.</code>, <code>??</code>, va <code>#nullable enable</code>. Ularni o'rganing va har doim ishlating. Kompilyator sizning yordamchingiz — uning ogohlantirishlarini e'tiborsiz qoldirmang.
  </div>
</section>

<!-- ─────────────────────────────────────── RULES -->
<section>
  <div class="section-label">
    <div class="section-num">📌</div>
    <h2>Talaba Uchun Eslatma: Uch Asosiy Qoida</h2>
  </div>

  <div class="rules">
    <div class="rule-card">
      <div class="rule-icon">🔍</div>
      <h4>1. Doimo Null Tekshiring</h4>
      <p>Reference type o'zgaruvchilar bilan ishlashdan oldin <code>!= null</code> yoki <code>?.</code> operatorini ishlating. Bu sizning birinchi himoya chizig'ingiz.</p>
    </div>
    <div class="rule-card">
      <div class="rule-icon">🛡️</div>
      <h4>2. Default Qiymat Bering</h4>
      <p>Null qaytarish o'rniga ma'noli default qiymat yoki bo'sh ob'yekt qaytaring. <code>??</code> operatori bu ishni bir qatorda hal qiladi.</p>
    </div>
    <div class="rule-card">
      <div class="rule-icon">⚙️</div>
      <h4>3. Kompilyatorga Ishoning</h4>
      <p>C# 8.0+ da <code>#nullable enable</code> yoqing. Kompilyator ogohlantirishlarini o'qing va tuzating — ular xatolarni oldindan ko'rsatadi.</p>
    </div>
  </div>
</section>

</main>

<!-- ═══════════════════════════════════════════════════════ FOOTER -->
<footer>
  <p style="margin-bottom:8px">
    <a href="https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references" target="_blank">Microsoft Docs: Nullable Reference Types</a>
     · 
    <a href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/" target="_blank">C# Language Reference</a>
  </p>
  <p>C#/NET. Boboqandov Maxmud</p>
</footer>

</body>
</html>
