using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        char[] chars = input.ToCharArray();

        StringBuilder nums = new();
        StringBuilder letters = new();
        StringBuilder symbols = new();

        foreach (char letter in chars)
        {
            if (char.IsDigit(letter))
            {
                nums.Append(letter);
            }
            else if (char.IsLetter(letter))
            {
                letters.Append(letter);
            }
            else
            {
                symbols.Append(letter);
            }
        }

        Console.WriteLine(nums);
        Console.WriteLine(letters);
        Console.WriteLine(symbols);
    }
}
