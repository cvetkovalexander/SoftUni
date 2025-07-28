class Program
{
    static void Main()
    {
        HashSet<string> carNumbers = new();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(", ");
            switch (tokens[0])
            {
                case "IN":
                    carNumbers.Add(tokens[1]);
                    break;
                case "OUT":
                    carNumbers.Remove(tokens[1]);
                    break;
            }
        }

        if (carNumbers.Count > 0)
        {
            foreach (var number in carNumbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("Parking Lot is Empty");
        }
    }
}
