class Program
{
    static void Main()
    {
        //Console.WriteLine(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray().Sum());


        int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Console.WriteLine(Sum(array, 0));

    }

    private static int Sum(int[] array, int index)
    {
        if (index == array.Length - 1)
            return array[index];

        int rest = Sum(array, index + 1);
        int sum = array[index] + rest;

        return sum;
    }
}
