using System;
using System.Linq;
using System.Collections.Generic;

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
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Article> list = new List<Article>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(", ");
            Article article = new Article(input[0], input[1], input[2]);
            list.Add(article);
        }
        
        string command = Console.ReadLine();

        if (command == "title")
        {
            list.OrderBy(t => t.Title)
                .ToList()
                .ForEach(t => Console.WriteLine(t.ToString()));
        }
        else if (command == "content")
        {
            list.OrderBy(c => c.Content)
                .ToList()
                .ForEach(c => Console.WriteLine(c.ToString()));
        }
        else if (command == "author")
        {
            list.OrderBy(a => a.Author)
                .ToList()
                .ForEach(a => Console.WriteLine(a.ToString()));
        }

    }
}