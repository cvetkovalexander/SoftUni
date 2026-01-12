namespace BookShop;

using BookShop.Models;
using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        //DbInitializer.ResetDatabase(db);

        //string? input = Console.ReadLine();
        //int count = int.Parse(Console.ReadLine());
        //Console.WriteLine(GetMostRecentBooks(db));

        Console.WriteLine(RemoveBooks(db));
    }

    // Problem 02
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        bool isCommandValid = Enum
           .TryParse(command, true, out AgeRestriction ageRestriciton);

        if (isCommandValid)
        {
            IEnumerable<string> bookTitles = context
                .Books
                .AsNoTracking()
                .Where(b => b.AgeRestriction == ageRestriciton)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var title in bookTitles)
                sb.AppendLine(title);

            return sb.ToString().TrimEnd();
        }

        return "";
    }

    // Problem 03
    public static string GetGoldenBooks(BookShopContext context) 
    {
        IEnumerable<string> bookTitles = context
            .Books
            .AsNoTracking()
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var title in bookTitles)
            sb.AppendLine(title);


        return sb.ToString().TrimEnd();
    }

    // Problem 04
    public static string GetBooksByPrice(BookShopContext context) 
    {
        var books = context
            .Books
            .AsNoTracking()
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => new 
            {
                b.Title,
                b.Price
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var book in books)
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");

        return sb.ToString().TrimEnd();
    }

    // Problem 05
    public static string GetBooksNotReleasedIn(BookShopContext context, int year) 
    {
        IEnumerable<string> titles = context
            .Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, titles);
    }

    // Problem 06
    public static string GetBooksByCategory(BookShopContext context, string input) 
    {
        string[] categoriesArr = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLowerInvariant())
            .ToArray();

        StringBuilder sb = new StringBuilder();
        if (categoriesArr.Any()) 
        {
            IEnumerable<string> titles = context
                .Books
                .AsNoTracking()
                .Where(b => b.BookCategories
                    .Select(bc => bc.Category)
                    .Any(c => categoriesArr.Contains(c.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var title in titles)
                sb.AppendLine(title);
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 07
    public static string GetBooksReleasedBefore(BookShopContext context, string date) 
    {
        //DateTime dateTime = DateTime.Parse(date);
        DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

        var books = context
            .Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate < parsedDate)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new 
            {
                b.Title,
                b.EditionType,
                b.Price
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var book in books)
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");

        return sb.ToString().TrimEnd();

    }

    // Problem 08
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input) 
    {
        var authors = context
            .Authors
            .AsNoTracking()
            .Where(a => a.FirstName.EndsWith(input))
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .Select(a => new {
                a.FirstName,
                a.LastName
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var a in authors)
            sb.AppendLine($"{a.FirstName} {a.LastName}");

        return sb.ToString().TrimEnd();
    }

    // Problem 09
    public static string GetBookTitlesContaining(BookShopContext context, string input) 
    {
        var titles = context
            .Books
            .AsNoTracking()
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, titles);
    }

    // Problem 10
    public static string GetBooksByAuthor(BookShopContext context, string input) 
    {
        var books = context
            .Books
            .AsNoTracking()
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new 
            {
                b.Title,
                authorFirstName = b.Author.FirstName,
                authorLastName = b.Author.LastName,
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var book in books)
            sb.AppendLine($"{book.Title} ({book.authorFirstName} {book.authorLastName})");


        return sb.ToString().TrimEnd();
    }

    // Problem 11
    public static int CountBooks(BookShopContext context, int lengthCheck) 
    {
        var count = context.
            Books
            .AsNoTracking()
            .Where(b => b.Title.Length > lengthCheck)
            .Select(b => b.Title)
            .ToArray()
            .Count();

        return count;
    }

    // Problem 12
    public static string CountCopiesByAuthor(BookShopContext context) 
    {
        var authorBookCopies = context
            .Authors
            .AsNoTracking()
            .Select(a => new 
            {
                a.FirstName,
                a.LastName,
                Copies = a.Books.Sum(b => b.Copies)
            })
            .OrderByDescending(a => a.Copies)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var author in authorBookCopies)
            sb.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");

        return sb.ToString().TrimEnd();
    }

    // Problem 13
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var categoriesTotalProfit = context
            .Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                TotalProfit = c.CategoryBooks
                    .Select(cb => cb.Book)
                    .Sum(b => b.Copies * b.Price)
            })
            .OrderByDescending(c => c.TotalProfit)
            .ThenBy(c => c.Name)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var category in categoriesTotalProfit)
            sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            
        return sb.ToString().TrimEnd();
    }

    // Problem 14
    public static string GetMostRecentBooks(BookShopContext context) 
    {
        var categoryRecentBooks = context
            .Categories
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                c.Name,
                RecentBooks = c.CategoryBooks
                    .Select(cb => cb.Book)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var category in categoryRecentBooks) 
        {
            sb.AppendLine($"--{category.Name}");
            foreach (var book in category.RecentBooks)
                sb.AppendLine($"{book.Title} ({book.ReleaseDate!.Value.Year})");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 15
    public static void IncreasePrices(BookShopContext context) 
    {
        IQueryable<Book> books = context
            .Books
            .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year < 2010);

        foreach (var book in books)
            book.Price += 5;

        context.SaveChanges();
    }

    // Problem 16
    public static int RemoveBooks(BookShopContext context) 
    {
        var booksToRemove = context
            .Books
            .Where(b => b.Copies < 4200);

        int count = booksToRemove.Count();

        context.Books.RemoveRange(booksToRemove);

        context.SaveChanges();

        return count;
    }
}


