class Program
{
    static void Main()
    {
        Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split();
            decimal grade = decimal.Parse(input[1]);
            if (!studentGrades.ContainsKey(input[0]))
            {
                studentGrades[input[0]] = new List<decimal>();
                studentGrades[input[0]].Add(grade);
            }
            else
            {
                studentGrades[input[0]].Add(grade);
            }
        }

        foreach ((string name, List<decimal> grades) in studentGrades)
        {
            Console.WriteLine($"{name} -> {string.Join(" ", grades.Select(g => g.ToString("F2")))} (avg: {grades.Average():F2})");
        }
    }
}
