using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace LibrarySystemApp
{
    class CLI
    {
        private const string booksFile = "books.csv";
        private const string membersFile = "members.csv";
        private const string bookRequestsFile = "bookRequests.csv";
        private const string bookRatingsFile = "bookRatings.csv";

        static void Main(string[] args)
        {
        
            Library library = new Library();
            library.LoadBooksFromFile(booksFile);
            library.LoadMembersFromFile(membersFile);
            library.LoadBookRequestsFromFile(bookRequestsFile);
            library.LoadBookRatingsFromFile(bookRatingsFile);

            while (true)
            {
                Console.WriteLine("\n--- Library System ---");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine().Trim();

                if (choice == "1")
                {
                    Member loggedInMember = HandleLogin(library);
                    if (loggedInMember != null)
                    {
                        Console.WriteLine($"Welcome back, {loggedInMember.GetFirstName()}!");
                        Console.WriteLine($"Membership Type: {loggedInMember.GetMembershipType()}");
                        MemberMenu(library, loggedInMember);
                    }
                }
                else if (choice == "2")
                {
                    HandleRegistration(library);
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option! Try Again!");
                }
            }
        }

        static Member HandleLogin(Library library)
        {
            Console.Write("Enter Member ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            foreach (Member m in library.GetMembers())
            {
                if (m.GetId() == id && m.GetPassword() == password)
                {
                    return m;
                }
            }

            Console.WriteLine("Invalid ID or Password. Try Again!");
            return null;
        }

        static void HandleRegistration(Library library)
        {
            Console.Write("Enter First Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();


            // Generate id: find the highest existing ID and add 1
            int id = 1000;
            foreach (Member m in library.GetMembers())
            {
                if (m.GetId() >= id)
                {
                    id = m.GetId() + 1;
                }
            }

            DateTime joinedDate = DateTime.Now;

            Member member = new Member(id, name, surname, password, joinedDate, Member.MembershipLevel.Member);
            library.AddMember(member);
            library.SaveMembersToFile(membersFile);

            Console.WriteLine($"Successfully registered! Your Member ID is {id}");
        }


        static void MemberMenu(Library library, Member member)
        {
            if (member.GetMembershipType() == Member.MembershipLevel.Admin)
            {
                AdminMenu(library, member);
            }
            else if (member.GetMembershipType() == Member.MembershipLevel.Member)
            {
                RegularMemberMenu(library, member);
            }
        }

        private static Book GetBookFromInput()
        {
            Console.Write("Enter author: ");
            string author = Console.ReadLine();
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter genre:");
            string genre = Console.ReadLine();
            return new Book(author, title, year, genre);
        }

        static void AdminMenu(Library library, Member member)
        {
            while (true)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. List Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Remove Book");
                Console.WriteLine("4. View Members");
                Console.WriteLine("5. View Borrowed Books (Not Implemented)");
                Console.WriteLine("6. View Book Requests");
                Console.WriteLine("7. Log out");
                Console.WriteLine("8. Display book ratings");
                Console.WriteLine("9. Rate Book");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine().Trim();

                if (choice == "1")
                {
                    Console.WriteLine("Choose an option (type 'author', 'year', or 'genre'; leave blank to show all):");
                    string option = Console.ReadLine();
                    if (option == "")
                    {
                        library.ListBooks();
                    }
                    else if (option == "author")
                    {
                        Console.WriteLine("Enter author name: ");
                        string author = Console.ReadLine();
                        library.ListBooksByAuthor(author);
                    }
                    else if (option == "genre")
                    {
                        Console.WriteLine("Enter genre name: ");
                        string genre = Console.ReadLine();
                        library.ListBooksByGenre(genre);
                    }
                    else if (option == "year")
                    {
                        Console.WriteLine("Enter year: ");
                        int year = int.Parse(Console.ReadLine());
                        library.ListBooksByYear(year);
                    }
                    else
                    {
                        Console.WriteLine("Invalid option!");
                    }
                }
                else if (choice == "2")
                {
                    Book book = GetBookFromInput();
                    library.AddBook(book);
                    library.SaveBooksToFile(booksFile);
                    Console.WriteLine("Successfully added a book!");
                }
                else if (choice == "3")
                {
                    Book book = GetBookFromInput();
                    library.RemoveBook(book);
                    library.SaveBooksToFile(booksFile);
                    Console.WriteLine("Successfully removed a book!");
                }
                else if (choice == "4")
                {
                    library.ListMembers();
                }
                else if (choice == "6")
                {
                    library.ListBookRequests();
                }
                else if (choice == "7")
                {
                    Console.WriteLine("Logging out...");
                    break;
                }
                else if (choice == "8")
                {
                    library.ListAvarageBookRatings();
                }
                else if (choice == "9")
                {
                    Book book = GetBookFromInput();
                    Console.WriteLine("Rate Book 1 to 5:");
                    int rating = int.Parse(Console.ReadLine());
                    library.AddBookRating(book, member, (BookRating.RatingScale)rating);
                    library.SaveBookRatingsToFile(bookRatingsFile);
                }
                else
                {
                    Console.WriteLine("Wrong option! Try Again!");
                }
            }
        }
        
        static void RegularMemberMenu(Library library, Member member)
        {
            while (true)
            {
                Console.WriteLine("\n--- Member Menu ---");
                Console.WriteLine("1. List Books");
                Console.WriteLine("2. Borrow Book (Not Implemented)");
                Console.WriteLine("3. Return Book (Not Implemented)");
                Console.WriteLine("4. View Borrowed Books (Not Implemented)");
                Console.WriteLine("5. Rate Book (Not Implemented)");
                Console.WriteLine("6. Request Book");
                Console.WriteLine("7. View Book Requests");
                Console.WriteLine("8. Log out");
                Console.WriteLine("9. Display book ratings");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine().Trim();

                if (choice == "1")
                {
                    Console.WriteLine("Choose an option (type 'author', 'year', or 'genre'; leave blank to show all):");
                    string option = Console.ReadLine();
                    if (option == "")
                    {
                        library.ListBooks();
                    }
                    else if (option == "author")
                    {
                        Console.WriteLine("Enter author name: ");
                        string author = Console.ReadLine();
                        library.ListBooksByAuthor(author);
                    }
                    else if (option == "genre")
                    {
                        Console.WriteLine("Enter genre name: ");
                        string genre = Console.ReadLine();
                        library.ListBooksByGenre(genre);
                    }
                    else if (option == "year")
                    {
                        Console.WriteLine("Enter year: ");
                        int year = int.Parse(Console.ReadLine());
                        library.ListBooksByYear(year);
                    }
                    else
                    {
                        Console.WriteLine("Invalid option!");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Feature not implemented yet.");
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Feature not implemented yet.");
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Feature not implemented yet.");
                }
                else if (choice == "5")
                {
                    Book book = GetBookFromInput();
                    Console.WriteLine("Rate Book 1 to 5:");
                    int rating = int.Parse(Console.ReadLine());
                    library.AddBookRating(book, member, (BookRating.RatingScale)rating);
                    library.SaveBookRatingsToFile(bookRatingsFile);
                }
                else if (choice == "6")
                {
                    Book book = GetBookFromInput();
                    library.AddBookRequest(book, member);
                    library.SaveBookRequestsToFile(bookRequestsFile);
                    Console.WriteLine("Successfully added book request!");
                }
                else if (choice == "7")
                {
                    library.ListBookRequests();
                    Console.WriteLine("Presented books requests.");
                }
                else if (choice == "8")
                {
                    Console.WriteLine("Logging out...");
                    break;
                }
                else if (choice == "9")
                {
                    library.ListAvarageBookRatings();
                }
                else
                {
                    Console.WriteLine("Wrong option! Try Again!");
                }
            }
        }
    }
}
