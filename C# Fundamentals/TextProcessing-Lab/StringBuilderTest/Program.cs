class Program
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        string revNum = "";

        while (num > 0)
        {
            revNum += (num % 10).ToString();
            num /= 10;
        }

        Console.WriteLine(revNum);
    }
}