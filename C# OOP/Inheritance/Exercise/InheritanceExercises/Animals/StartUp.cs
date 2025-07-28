namespace Animals;

public class StartUp
{
    static void Main()
    {
        string animal;
        while ((animal = Console.ReadLine()) != "Beast!")
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = data[0];
            int age = int.Parse(data[1]);
            string gender = data[2];


            try
            {
                if (animal == nameof(Dog))
                {
                    Dog dog = new(name, age, gender);
                    Console.WriteLine(dog);
                }
                else if (animal == nameof(Cat))
                {
                    Cat cat = new(name, age, gender);
                    Console.WriteLine(cat);
                }
                else if (animal == nameof(Frog))
                {
                    Frog frog = new(name, age, gender);
                    Console.WriteLine(frog);
                }
                else if (animal == nameof(Kitten))
                {
                    Kitten kitten = new(name, age);
                    Console.WriteLine(kitten);
                }
                else if (animal == nameof(Tomcat))
                {
                    Tomcat tomcat = new(name, age);
                    Console.WriteLine(tomcat);
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input!");
            }
            
        }
    }
}