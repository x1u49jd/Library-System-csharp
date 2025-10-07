public class Book
{
    //properties with getters and setters (or accessors) in PaScalCase
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }


    // constructor and parameters in camelCase
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
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