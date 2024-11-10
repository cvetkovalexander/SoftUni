namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            
            char[] stringArray = username.ToCharArray();
            Array.Reverse(stringArray);
            string reversedUsername = new string(stringArray);

            int attempts = 4;

            while (attempts > 0)
            {
                string password = Console.ReadLine();
                attempts--;
                if (password == reversedUsername)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else if (attempts == 0)
                {
                    Console.WriteLine($"User {username} blocked!");
                }
                else 
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    
                }
                
            }
            

          






        }
    }
}
