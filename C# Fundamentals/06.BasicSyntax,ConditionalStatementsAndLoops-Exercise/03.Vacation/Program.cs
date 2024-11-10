namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;

            switch (typeOfGroup)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price = countOfPeople * 8.45;
                            break;
                        case "Saturday":
                            price = countOfPeople * 9.8;
                            break;
                        case "Sunday":
                            price = countOfPeople * 10.46;
                            break;
                    }
                    if (countOfPeople >= 30)
                        price *= 0.85;
                    break;
                case "Business":
                    if (countOfPeople >= 100)
                        countOfPeople -= 10; 
                    switch (day)                       
                    {                                  
                        case "Friday":
                            price = countOfPeople * 10.9;
                            break;
                        case "Saturday":
                            price = countOfPeople * 15.6;
                            break;
                        case "Sunday":
                            price = countOfPeople * 16;
                            break;
                    }                   
                    break;
                case "Regular":                    
                    switch (day)
                    {
                        case "Friday":
                            price = countOfPeople * 15;
                            break;
                        case "Saturday":
                            price = countOfPeople * 20;
                            break;
                        case "Sunday":
                            price = countOfPeople * 22.5;
                            break;
                    }
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                        price *= 0.95;
                    break;
            }
            Console.WriteLine($"Total price: {price:F2}");
        }
    }
}
