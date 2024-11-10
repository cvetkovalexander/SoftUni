namespace _02.Articles
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

        public static Article NewContent(string newContent, Article newArticle)
        {
            newArticle.Content = newContent;
            return newArticle;
        }

        public static Article NewAuthor(string newAuthor, Article newArticle)
        {
            newArticle.Author = newAuthor;
            return newArticle;
        }

        public static Article NewTitle(string newTitle, Article newArticle)
        {
            newArticle.Title = newTitle;
            return newArticle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine().Split(", ");
            string title = article[0];
            string content = article[1];
            string author= article[2];

            Article newArticle = new(title, content, author);

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] arguments = Console.ReadLine().Split(": ");
                
                switch (arguments[0])
                {
                    case "Edit":
                        string newContent = arguments[1];
                        newArticle = Article.NewContent(newContent, newArticle);
                        break;
                    case "ChangeAuthor": 
                        string newAuthor = arguments[1];
                        newArticle = Article.NewAuthor(newAuthor, newArticle);
                        break;
                    case "Rename":
                        string newTitle = arguments[1];
                        newArticle = Article.NewTitle(newTitle, newArticle);
                        break;
                }
            }

            Console.WriteLine(newArticle);
        }
    }
}
