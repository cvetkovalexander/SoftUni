using System.Runtime.CompilerServices;

namespace _01.AdvertisementMessage
{
    class Advertisment
    {
        private readonly string[] phrases =
        {
            "Excellent product.", "Such a great product.", "I always use that product.",
            "Best product of its category.", "Exceptional product.", "I can't live without this product."
        };

        private readonly string[] events =
        {
            "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
        };

        private readonly string[] authors =
            { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

        private readonly string[] cities =
            { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        public string GetRandomMessage()
        {
            Random random = new Random();
            int index = random.Next(phrases.Length);
            string phrase = phrases[index];

            index = random.Next(events.Length);
            string @event = events[index];

            index = random.Next(authors.Length);
            string author = authors[index];

            index = random.Next(cities.Length);
            string city = cities[index];

            return $"{phrase} {@event} {author} – {city}.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int messages = int.Parse(Console.ReadLine());

            for (int i = 0; i < messages; i++)
            {
            Advertisment ad = new();
            Console.WriteLine(ad.GetRandomMessage());
            }
        }
    }
}
