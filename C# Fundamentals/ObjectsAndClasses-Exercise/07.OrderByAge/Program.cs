namespace _07.OrderByAge
{
    class Human
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public Human(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Human> humans = new();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split();
                //humans.Add(new(arguments[0], arguments[1], int.Parse(arguments[2])));
                string name = arguments[0];
                string id = arguments[1];
                int age = int.Parse(arguments[2]);
                Human person = new(name, id, age);
                humans.Add(person);
                foreach (Human human in humans)
                {
                    if (id == human.ID)
                    {
                        human.Name = name;
                        human.Age = age;
                    }
                }
            }

            humans = humans.OrderBy(person => person.Age).ToList();

            foreach (Human human in humans)
            {
                Console.WriteLine($"{human.Name} with ID: {human.ID} is {human.Age} years old.");
            }

        }
    }
}
