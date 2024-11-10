namespace _06.BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            
            int open = 0;
            int close = 0;

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                
                if (input == "(")
                {
                    open++;
                }
                if (input == ")")
                {
                    close++;
                    if (open - close != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
                
            }
            if (open == close)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }
    }
}
