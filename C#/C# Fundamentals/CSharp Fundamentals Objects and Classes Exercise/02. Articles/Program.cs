using System;

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

    public void Rename(string title)
    {
        Title = title;
    }

    public void Edit(string content)
    {
        Content = content;
    }

    public void ChangeAuthor(string author)
    {
        Author= author;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }

}

internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(", ");

        Article article = new Article(input[0], input[1], input[2]);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] currentCommand = Console.ReadLine().Split(": ");
            string command = currentCommand[0];
            string changeValue = currentCommand[1];

            if (command == "Rename")
            {
                article.Rename(changeValue);
            }
            else if (command == "Edit")
            {
                article.Edit(changeValue);
            }
            else if (command == "ChangeAuthor")
            {
                article.ChangeAuthor(changeValue);
            }

        }

        Console.WriteLine(article.ToString());

    }
}