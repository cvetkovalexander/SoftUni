namespace _03.Articles2._0
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());
            List<Article> articles = new();

            for (int i = 0; i < articlesCount; i++)
            {
                string[] articleArgs = Console.ReadLine().Split(", ");
                Article article = new(articleArgs[0], articleArgs[1], articleArgs[2]);
                articles.Add(article);
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }

        }
    }
}
