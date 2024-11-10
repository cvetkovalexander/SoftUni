


namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            Characters(password);
            LettersDigits(password);
            AtLeastTwoDigits(password);
            ValidPass(password);
        }

        static void Characters(string input)
        {
            if (input.Length < 6 || input.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
        }
        static void LettersDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }
        }
        static void AtLeastTwoDigits(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
                {
                    count++;
                }
            }
            if (count < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }
        static void ValidPass(string input)
        {
            int count = 0;
            int foreachCount = 0;
            int negative = 0;
            if (input.Length >= 6 && input.Length <= 10)
            {
                count++;
            }
            foreach (char c in input)
            {
                if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
                {
                    foreachCount++;
                }
            }
            if (foreachCount >= 2)
            {
                count++;
            }
            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    negative++;
                }
            }
            if (negative == 0)
            {
                count++;
            }
            if (count == 3)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
