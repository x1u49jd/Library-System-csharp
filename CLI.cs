class CLI
{
    static void Main(string[] args)
    {
        Library library = new Library();
        library.AddBook(new Book("Kull: Exile of Atlantis", "Robert E. Howard", 1967));
        library.AddBook(new Book("Hobbit", "J.R.R Tolkien", 1937));
        library.AddBook(new Book("Pride and Prejudice", "Jane Austen", 1813));

        while (true)
        {

            Console.WriteLine("1. List Books");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine().Trim();

            if (choice == "1")
            {
                library.ListBooks();
            }
            else if (choice == "2")
            {
                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                Console.Write("Enter author: ");
                string author = Console.ReadLine();
                Console.Write("Enter year: " );
                int year = int.Parse(Console.ReadLine());
                library.AddBook(new Book(title, author, year));
                library.SaveBooksToFile("books.csv");
                Console.WriteLine("Successfully added a book!");

            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.Write("Wrong option! Try Again!");
            }
        }
    }
}