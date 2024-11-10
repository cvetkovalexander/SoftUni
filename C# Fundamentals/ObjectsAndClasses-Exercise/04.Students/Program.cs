using System.Collections.Generic;
using System.Diagnostics;

namespace _04.Students
{
    class Student
    {
        public Student(string firstName, string lastName, decimal grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Grade { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new();

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] studentsArgs = Console.ReadLine().Split();
                Student student = new(studentsArgs[0], studentsArgs[1], decimal.Parse(studentsArgs[2]));
                students.Add(student);
            }
            List<Student> sorted = students.OrderByDescending(student => student.Grade).ToList();

            foreach (Student student in sorted)
            {
                Console.WriteLine(student);
            }
        }
    }
}
