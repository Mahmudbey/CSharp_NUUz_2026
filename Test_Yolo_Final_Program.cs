using System;
using YoloDotNet;
using YoloDotNet.Models;
using YoloDotNet.ExecutionProvider.Cpu;
using SkiaSharp;

class Program
{
    static void Main(string[] args)
    {
        // 1. Set your model path
        string modelPath = "path/to/your/yolov8n-face.onnx"; // UPDATE THIS PATH!

        // Check if model file exists
        if (!System.IO.File.Exists(modelPath))
        {
            Console.WriteLine($"Error: Model file not found at {modelPath}");
            Console.WriteLine("Please update the modelPath variable with the correct path to your YOLO .onnx model file.");
            Console.WriteLine("\nYou can download YOLOv8 models from:");
            Console.WriteLine("https://github.com/ultralytics/assets/releases");
            return;
        }

        // 2. Configure YOLO with CPU execution provider
        var options = new YoloOptions
        {
            ExecutionProvider = new CpuExecutionProvider(modelPath)
        };

        // 3. Load the model
        using var yolo = new Yolo(options);

        // 4. Set your image path
        string imagePath = @"D:\Asosiy\Download\Edge\Panda.jpg";

        // Check if image file exists
        if (!System.IO.File.Exists(imagePath))
        {
            Console.WriteLine($"Error: Image file not found at {imagePath}");
            Console.WriteLine("Please update the imagePath variable with a valid image file.");
            return;
        }

        // 5. Load the image
        using var bitmap = SKBitmap.Decode(imagePath);

        if (bitmap == null)
        {
            Console.WriteLine("Error: Could not decode image file.");
            return;
        }

        Console.WriteLine($"Image loaded: {bitmap.Width}x{bitmap.Height}");

        // 6. Run object detection
        Console.WriteLine("Running object detection...");
        var results = yolo.RunObjectDetection(bitmap, confidence: 0.5, iou: 0.45);

        // 7. Display detection results
        Console.WriteLine($"\nDetected {results.Count} object(s):");

        foreach (var detection in results)
        {
            var box = detection.BoundingBox;
            Console.WriteLine($"- Label: {detection.Label.Name} " +
                              $"| Confidence: {detection.Confidence:P2} " +
                              $"| Box: [{box.Left}, {box.Top}, {box.Width}, {box.Height}]");
        }

        // 8. Draw bounding boxes on the image
        if (results.Count > 0)
        {
            Console.WriteLine("\nDrawing bounding boxes...");

            using var canvas = new SKCanvas(bitmap);
            using var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 3,
                IsAntialias = true
            };

            using var font = new SKFont
            {
                Size = 20
            };

            using var textPaint = new SKPaint
            {
                Color = SKColors.Red,
                IsAntialias = true
            };

            foreach (var detection in results)
            {
                var box = detection.BoundingBox;
                canvas.DrawRect(box, paint);

                var label = $"{detection.Label.Name} {detection.Confidence:P0}";
                canvas.DrawText(label, box.Left, box.Top - 5, font, textPaint);
            }

            // 9. Save the output image
            string outputPath = "output_detected_faces.jpg";
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Jpeg, 95);
            using var stream = System.IO.File.OpenWrite(outputPath);
            data.SaveTo(stream);

            Console.WriteLine($"Output saved to {outputPath}");
        }
        else
        {
            Console.WriteLine("\nNo objects detected.");
        }

        Console.WriteLine($"\nModel info: {yolo.ModelInfo}");
    }
}
