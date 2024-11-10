
namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());

            
            if (a > b)
            {
                char swap = a;
                a = b;
                b = swap;
            }
            CharactersBetween(a, b);
        }

        static void CharactersBetween(char a, char b)
        {
            for (int i = a + 1;  i < b; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
