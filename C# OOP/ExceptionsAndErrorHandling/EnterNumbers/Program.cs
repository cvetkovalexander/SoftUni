

using System;

int previous = 1;
int count = 0;
int[] nums = new int[10];


while (count < 10)
{
    try
    {
        int n = ReadNumbers(previous, 100);
        nums[count++] = n;
        previous = n;
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (FormatException e)
    {
        Console.WriteLine("Invalid Number!");
    }
}

Console.WriteLine(string.Join(", ", nums));


static int ReadNumbers(int start, int end)
{
    int n = int.Parse(Console.ReadLine());
    if (n <= start || n >= end)
    {
        throw new ArgumentException($"Your number is not in range {start} - {end}!");
    }

    return n;
}




