using System;
using System.IO;
using SkiaSharp;                         // Rasm geometriyasi va SKRectI uchun
using YoloDotNet;                        // Asosiy Yolo kutubxonasi
using YoloDotNet.Models;                 // YoloOptions modeli uchun
using YoloDotNet.Extensions;             // image.Draw() va image.Save() uchun
using YoloDotNet.ExecutionProvider.Cpu;  // CPU bilan ishlash uchun

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(".NET YOLO Face Detection boshlandi...");

        string modelPath = @"D:\\maxmu\\Documents\\Microsoft\\model.onnx";
        string inputImagePath = @"D:\Asosiy\Media\Image\\IMG_5610.jpg";
        string outputImagePath = @"D:\Asosiy\Media\Image\\result_faces.jpg";

        // Fayllar mavjudligini tekshirish
        if (!File.Exists(modelPath))
        {
            Console.WriteLine($"Xato: '{modelPath}' fayli topilmadi!");
            return;
        }
        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine($"Xato: '{inputImagePath}' fayli topilmadi!");
            return;
        }

        // 1. CPU Konfiguratsiyasini sozlash
        var options = new YoloOptions
        {
            ExecutionProvider = new CpuExecutionProvider(modelPath)
        };

        // 2. Yolo obyektini yaratish
        using var yolo = new Yolo(options);

        // 3. SkiaSharp yordamida rasmni xotiraga yuklash
        using var image = SKBitmap.Decode(inputImagePath);

        Console.WriteLine("Rasm tahlil qilinmoqda...");

        // 4. Neyrotarmoqni ishga tushirish (Inference)
        var results = yolo.RunObjectDetection(image, confidence: 0.50, iou: 0.7);

        Console.WriteLine($"\nTopilgan yuzlar soni: {results.Count}");

        // 5. Natijalarni ekranga to'g'ri koordinatalar bilan chiqarish
        foreach (var detection in results)
        {
            // BoundingBox bu aslida SkiaSharp.SKRectI obyektidir
            var box = detection.BoundingBox;

            // XATO TUZATILDI: SKRectI tarkibida X/Y yo'q, o'rniga Left/Top ishlatiladi!
            Console.WriteLine($"- Yuz koordinatasi: Chap={box.Left}, Yuqori={box.Top}, " +
                              $"Kengligi={box.Width}, Balandligi={box.Height} " +
                              $"| Ishonch darajasi: {detection.Confidence:P2}");
        }

        // 6. Rasm ustiga qizil kvadrat chizish va uni saqlash
        image.Draw(results);
        image.Save(outputImagePath);

        Console.WriteLine($"\nNatija rasmi '{outputImagePath}' nomi bilan muvaffaqiyatli saqlandi!");
    }
}
