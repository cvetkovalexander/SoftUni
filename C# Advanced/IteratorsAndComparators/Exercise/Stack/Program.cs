namespace Stack;

public class Program
{
    static void Main(string[] args)
    {
        CustomStack<string> stack = new();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            if (input == "Pop")
                stack.Pop();
            else
            {
                string[] items = input.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                stack.Push(items);
            }
        }
        foreach (var item in stack)
            Console.WriteLine(item);
    }
}