using System;
using System.Collections.Generic;

namespace LibrarySystemApp
{
    class CLI
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.LoadBooksFromFile("books.csv");
            library.LoadMembersFromFile("members.csv");

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
            while (true)
            {
                Console.WriteLine("\n--- Member Menu ---");
                Console.WriteLine("1. List Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Remove Book");
                Console.WriteLine("4. Log out");
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
                    Console.WriteLine("Successfully removed a book!");
                }
                else if (choice == "4")
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
    }
}
