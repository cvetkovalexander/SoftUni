class Student
{
    public Student(string name, double grade, int grades)
    {
        Name = name;
        Grade = grade;
        Grades = grades;
    }
    public string Name { get; set; }
    public double Grade { get; set; }
    public int Grades { get; set; }
    public double Average => Grade / Grades;
    public void AddGrade(double grade)
    {
        Grade += grade;
    }

    public override string ToString()
    {
        return $"{Name} -> {Average:F2}";
    }
}
class Program
{
    static void Main()
    {
        Dictionary<string, Student> studentsGrades = new();
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string name = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());
            int grades = 1;

            Student student = new(name, grade, grades);

            if (!studentsGrades.ContainsKey(name))
            {
                studentsGrades.Add(student.Name, student);
            }
            else
            {
                studentsGrades[name].AddGrade(grade);
                studentsGrades[name].Grades++;
            }
            
        }

        foreach (Student student in studentsGrades.Values)
        {
            if (student.Average >= 4.5)
            {
                Console.WriteLine(student);
            }
        }

    }
}