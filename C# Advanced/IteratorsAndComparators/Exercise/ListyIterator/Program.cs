namespace ListyIterator;

public class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        ListyIterator<string> iterator = new(input[1..]);

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        Console.WriteLine(iterator.Current);
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", iterator));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
