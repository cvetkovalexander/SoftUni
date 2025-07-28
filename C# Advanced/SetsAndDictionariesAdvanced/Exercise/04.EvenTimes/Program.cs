class Program
{
    static void Main()
    {
        Dictionary<int, int> nums = new Dictionary<int, int>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (!nums.ContainsKey(num))
            {
                nums.Add(num, 0);
            }
            nums[num]++;
        }

        //foreach (var (num, count) in nums)
        //{
            //if (count % 2 == 0)
            //{
               // Console.WriteLine(num);
            //}
        //}
        KeyValuePair<int, int> result = nums.Single(kvp => kvp.Value % 2 == 0);
        Console.WriteLine(result.Key);
    }
}
