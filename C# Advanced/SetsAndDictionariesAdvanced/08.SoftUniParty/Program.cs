class Program
{
    static void Main()
    {
        HashSet<string> nums = new();

        string input;
        while ((input = Console.ReadLine()) != "PARTY")
        {
            if (input.Length == 8)
                nums.Add(input);
        }
        
        while ((input = Console.ReadLine()) != "END")
        {
            if (nums.Contains(input) && input.Length == 8)
            {
                nums.Remove(input);
            }
        }
        
        Console.WriteLine(nums.Count);
        foreach (var id in nums.Where(id => char.IsDigit(id[0])))
        {
            Console.WriteLine(id);
        }

        foreach (var id in nums.Where(id => char.IsLetter(id[0])))
        {
            Console.WriteLine(id);
        }
    }
}