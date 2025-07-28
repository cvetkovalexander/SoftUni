namespace GenericArrayCreator;

public class StartUp
{
    public static void Main(string[] args)
    {
        string[] strings = ArrayCreator.Create(5, "Pesho");

        foreach (var s in strings)
        {
            Console.WriteLine(s);
        }

        int[] nums = ArrayCreator.Create(10, 33);
        foreach (var num in nums)
        {
            Console.WriteLine(num);
        }
    }
}