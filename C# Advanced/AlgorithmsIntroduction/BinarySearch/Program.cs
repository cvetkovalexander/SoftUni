namespace BinarySearch;

public class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6};
        int numForSearch = int.Parse(Console.ReadLine());

       

        Console.WriteLine(BinarySearch.IndexOf(numbers, numForSearch));
    }
}
