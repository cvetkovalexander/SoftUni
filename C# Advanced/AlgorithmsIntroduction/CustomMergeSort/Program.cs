namespace CustomMergeSort;

public class Program
{
    static void Main(string[] args)
    {
        Mergesort<int> mergeSort = new();

        int[] array = new []{13, 2 , 1 ,20};
        //Random ran = new();
        //for (int i = 0; i < array.Length; i++)
        //{
        //    int ranNum = ran.Next(99);
        //    array[i] = ranNum;
        //}

        foreach (var num in array)
            Console.Write($"{num} ");
        Console.WriteLine();

        mergeSort.Sort(array);

        foreach (var num in array)
            Console.Write($"{num} ");
        Console.WriteLine();
    }
}