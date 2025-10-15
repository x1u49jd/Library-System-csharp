namespace LibrarySystemApp {
    class CLI
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.LoadBooksFromFile("books.csv");
            library.LoadMembersFromFile("members.csv");

            while (true)
            {

                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine().Trim();

                if (choice == "1")
                {
                    Console.WriteLine("Enter Member ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();

                    foreach (Member m in library.GetMembers())
                    {
                        if (m.GetId() == id && m.GetPassword() == password)
                        {
                            Console.WriteLine($"Welcome back, {m.GetFirstName()}!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID or Password. Try Again!");
                            break;
                        }
                    }

                }
                if (choice == "2")
                {
                    Console.WriteLine("Enter First Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();

                    int id = new Random().Next(1000, 9999);
                    DateTime joinedDate = DateTime.Now;

                    Member member = new Member(id, name, surname, password, joinedDate);
                    library.AddMember(member);
                    library.SaveMembersToFile("members.csv");
                    Console.WriteLine($"Successfully registered! Your Member ID is {id}");
                }
                if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option! Try Again!");
                }
                
                /*
                Console.WriteLine("1. List Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Remove Book");
                Console.WriteLine("4. Exit");
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
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter year: ");
                    int year = int.Parse(Console.ReadLine());
                    library.RemoveBook(new Book(author, title, year));
                    library.SaveBooksToFile("books.csv");
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.Write("Wrong option! Try Again!");
                }
                */
            }
        }
    }
}