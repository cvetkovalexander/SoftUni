using CommandPattern.Commands;
using CommandPattern.Contracts;

namespace CommandPattern;

public class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new();
        while (true)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (char.Parse(data[0]) is 'U')
                calculator.Undo(int.Parse(data[1]));
            
            else if (char.Parse(data[0]) is 'R')
                calculator.Redo(int.Parse(data[1]));

            else
            {
                ICommand command = char.Parse(data[0]) switch
                {
                    '+' => new PlusCommand(int.Parse(data[1])),
                    '-' => new MinusCommand(int.Parse(data[1])),
                    '*' => new MultiplyCommand(int.Parse(data[1])),
                    '/' => new DivideCommand(int.Parse(data[1])),
                    _ => throw new ArgumentException("Invalid command operator.")
                };

                calculator.ExecuteCommand(command);
            }
            Console.Clear();
            Console.WriteLine(calculator.ToString());
        }
    }
}