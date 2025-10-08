public class Book
{
    //properties with getters and setters (or accessors) in PaScalCase

    public string Author { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }


    // constructor and parameters in camelCase
    public Book(string author, string title, int year)
    {
        Author = author;
        Title = title;
        Year = year;
    }

    public string GetTitle()
    {
        return Title;
    }

    public string GetAuthor()
    {
        return Author;
    }

    public int GetYear()
    {
        return Year;
    }
}