using System.Reflection.Metadata;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();

                if (IsStudentExisting(students, tokens[0], tokens[1]))
                {
                    Student student = students.Find(student => student.FirstName == tokens[0] && student.LastName == tokens[1]);

                    student.Age = int.Parse(tokens[2]);
                    student.HomeTown = tokens[3];

                }

                else
                {
                Student student = new(tokens[0], tokens[1], int.Parse(tokens[2]), tokens[3]);
                students.Add(student);
                }

            }

            string city = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old. ");
                }
            }

        }
        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }

}
