






string[] nums = Console.ReadLine().Split(" ");
int sum = 0;

foreach (var num in nums)
{
    try
    {
        int curr = int.Parse(num);
        sum += curr;
    }
    catch (FormatException e)
    {
        Console.WriteLine($"The element '{num}' is in wrong format!");
    }
    catch (OverflowException e)
    {
        Console.WriteLine($"The element '{num}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{num}' processed - current sum: {sum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {sum}");