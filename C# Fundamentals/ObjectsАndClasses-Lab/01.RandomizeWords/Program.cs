namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sentence = Console.ReadLine().Split();

            Random random = new();
            for (int i = 0; i < sentence.Length; i++)
            {
                int randomIndex = random.Next(0, sentence.Length);

                string temp = sentence[i];
                sentence[i] = sentence[randomIndex];
                sentence[randomIndex] = temp;
            }
            foreach (string word in sentence)
            {
                Console.WriteLine(word);
            }
        }
    }
}
