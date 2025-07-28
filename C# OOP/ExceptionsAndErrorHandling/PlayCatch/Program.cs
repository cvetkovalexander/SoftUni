






using System;

int[] nums = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int count = 0;
while (count < 3)
{
    try
    {
        string[] data = Console.ReadLine().Split(" ");
        switch (data[0])
        {
            case "Replace":
                nums[int.Parse(data[1])] = int.Parse(data[2]);
                break;
            case "Print":
                Console.WriteLine(string.Join(", ", nums[int.Parse(data[1])..(int.Parse(data[2]) + 1)]));
                break;
            case "Show":
                Console.WriteLine(nums[int.Parse(data[1])]);
                break;
        }
    }
    catch (IndexOutOfRangeException e)
    {
        Console.WriteLine("The index does not exist!");
        count++;
    }
    catch (FormatException e)
    {
        Console.WriteLine("The variable is not in the correct format!");
        count++;
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine("The index does not exist!");
        count++;
    }
}

Console.WriteLine(string.Join(", ", nums));