using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;

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
                    writer.WriteLine($"{book.GetAuthor()}, {book.GetTitle()}, {book.GetYear()}");
                    Console.WriteLine($"Accounts saved to {filename}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while saving accounts to file : {e.Message}");
        }
    }

    public void LoadBooksFromFile(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string author = parts[0].Trim();
                            string title = parts[1].Trim();
                            int year = int.Parse(parts[2].Trim());
                            books.Add(new Book(author, title, year));
                        }
                    }
                }
                Console.WriteLine($"Books loaded from {filename}");
            }
            else
            {
                Console.WriteLine($"File {filename} does not exist. Starting with an empty library.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while loading books from file : {e.Message}");
        }
    }
}