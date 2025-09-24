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
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}