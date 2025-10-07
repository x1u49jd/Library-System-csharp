using System.Formats.Asn1;
using System.Linq.Expressions;

public class Library
{
    private List<Book> books = new List<Book>();

    // public method to add books to the list (PascalCase)
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void ListBooks()
    {
        foreach (Book book in books)
        {
            Console.WriteLine($"{book.GetAuthor()}, {book.GetTitle()}, {book.GetYear()}");
        }
    }

    public void SaveBooksToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Book book in books)
                {
                    writer.WriteLine($"{book.GetAuthor()}, {book.GetTitle()}, {book.GetYear}");
                    Console.WriteLine($"Accounts saved to {filename}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while saving accounts to file : {e.Message}");
        }
    }
}