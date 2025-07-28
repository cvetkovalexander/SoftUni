namespace Demo;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            string path = @"C:\Users\Admin\Desktop\C# OOP\SOLID"; // Смени с реален път
            File.WriteAllText(path, "Hello, Татенце!");
            Console.WriteLine("Файлът е записан успешно!");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"⚠️ Грешка: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Друга грешка: {ex.Message}");
        }
    }
}