namespace _01.CompanyRoster
{
    class Employee
    {

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
        public List<string> Departments {
            get;
            set;
        }
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
            Departments = new();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                employees.Add(new(arguments[0], int.Parse(arguments[1]), arguments[2]));
                
            }

            decimal highestAverage = decimal.MinValue;

        }
    }
}
