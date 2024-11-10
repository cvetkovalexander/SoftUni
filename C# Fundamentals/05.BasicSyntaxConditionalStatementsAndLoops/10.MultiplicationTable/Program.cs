 

     class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int timesCounter = int.Parse(Console.ReadLine());

            do
        {
            Console.WriteLine($"{num} X {timesCounter} = {num * timesCounter}");
            timesCounter++;
        }while (timesCounter <= 10);
        }
    }

