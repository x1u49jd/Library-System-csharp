using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LibrarySystemApp
{
    class CLI
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.LoadBooksFromFile("books.csv");
            library.LoadMembersFromFile("members.csv");
            library.LoadBookRequestsFromFile("bookRequests.csv");

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
            library.SaveMembersToFile("members.csv");

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
                    Console.Write("Enter genre:");
                    string genre = Console.ReadLine();
                    library.AddBook(new Book(author, title, year, genre));
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
                    Console.Write("Enter genre:");
                    string genre = Console.ReadLine();
                    library.RemoveBook(new Book(author, title, year, genre));
                    library.SaveBooksToFile("books.csv");
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
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine().Trim();

                if (choice == "1")
                {
                    Console.WriteLine("Choose option (show all/by author/by year/by genre): ");
                    string option = Console.ReadLine();
                    if (option == "show all")
                    {
                        library.ListBooks();
                    }
                    else if (option == "by author")
                    {
                        Console.WriteLine("Enter author name: ");
                        string author = Console.ReadLine();
                        library.ListBooksByAuthor(author);
                    }
                    else if (option == "by genre")
                    {
                        Console.WriteLine("Enter genre name: ");
                        string genre = Console.ReadLine();
                        library.ListBooksByGenre(genre);
                    }
                    else if (option == "by year")
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
                    Console.WriteLine("Feature not implemented yet.");
                }
                else if (choice == "6")
                {
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter year: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Enter genre:");
                    string genre = Console.ReadLine();
                    library.AddBookRequest(new Book(author, title, year, genre), member);
                    library.SaveBookRequestsToFile("bookRequests.csv");
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
            }
        }
    }
}
