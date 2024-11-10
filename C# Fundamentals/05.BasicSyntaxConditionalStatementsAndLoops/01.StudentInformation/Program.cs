

     class Program
    {
        static void Main()
        {
            string sName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {sName}, Age: {age}, Grade: {grade:F2}");
        }
    }
