using System.Text;

namespace NewsFeed;

public class NewsFeed
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    public List<Article> Articles { get; set; }
    public NewsFeed(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        Articles = new();
    }

    public void AddArticle(Article article)
    {
        if (Articles.Count < Capacity && !Articles.Any(x => x.Title == article.Title))
        {
            Articles.Add(article);
        }
    }

    public bool DeleteArticle(string title)
    {
        foreach (var article in Articles)
        {
            if (article.Title == title)
            {
                Articles.Remove(article);
                return true;
            }
        }

        return false;
    }

    public Article GetShortestArticle()
    {
        return Articles.OrderBy(x => x.WordCount).FirstOrDefault();
    }

    public string GetArticleDetails(string title)
    {
        foreach (var article in Articles)
        {
            if (article.Title == title)
            {
                return article.ToString();
            }
        }
        return $"Article with title '{title}' not found.";
    }

    public int GetArticlesCount() => Articles.Count;

    public string Report()
    {
        StringBuilder result = new();
        result.AppendLine($"{Name} newsfeed content:");
        foreach (var article in Articles.OrderBy(x => x.WordCount))
        {
            result.AppendLine($"{article.Author}: {article.Title}");
        }

        return result.ToString().Trim();
    }
}