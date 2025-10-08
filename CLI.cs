class CLI
{
    static void Main(string[] args)
    {
        Library library = new Library();
        library.LoadBooksFromFile("books.csv");

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
                Console.Write("Enter author: ");
                string author = Console.ReadLine();
                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                Console.Write("Enter year: ");
                int year = int.Parse(Console.ReadLine());
                library.AddBook(new Book(author, title, year));
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