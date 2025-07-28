namespace QuickSort;

public class Program
{
    static void Main(string[] args)
    {
        Quick<int> quickSort = new();
        int[] array = { 5, 3, 12, 8, 7, 54, 1, 9 };

        quickSort.QuickSort(array, 0, array.Length - 1);

        foreach (var num in array)
            Console.Write($"{num} ");
    }
}
