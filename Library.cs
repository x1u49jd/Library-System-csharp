using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;

namespace LibrarySystemApp 
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        private List<Member> members = new List<Member>();

        private List<BookRequest> bookRequests = new List<BookRequest>();

        // public method to add books to the list (PascalCase)
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            bool found = false;

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author == book.Author &&
                    books[i].Title == book.Title &&
                    books[i].Year == book.Year)
                {
                    found = true;
                    books.RemoveAt(i);
                    break;
                }
            }

            Console.WriteLine(found ? "Book successfully removed!" : "Book not found!");
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
                    foreach (Book b in books)
                    {
                        writer.WriteLine($"{b.GetAuthor()}, {b.GetTitle()}, {b.GetYear()}");
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
                    Console.WriteLine($"File {filename} does not exist. Starting with an empty book list.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while loading books from file : {e.Message}");
            }
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public void AddMember(Member member)
        {
            members.Add(member);
        }

        public void RemoveMember(Member member)
        {
            bool found = false;

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Id == member.Id)
                {
                    found = true;
                    members.RemoveAt(i);
                    break;
                }
            }

            Console.WriteLine(found ? "Member successfully removed!" : "Member not found!");
        }

        public void ListMembers()
        {
            foreach (Member m in members)
            {
                Console.WriteLine($"{m.GetId()}, {m.GetFirstName()}, {m.GetSurname()}, {m.GetPassword()}, {m.GetJoinedDate()}, {m.GetMembershipType()}");
            }
        }

        public void SaveMembersToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Member m in members)
                    {
                        writer.WriteLine($"{m.GetId()}, {m.GetFirstName()}, {m.GetSurname()}, {m.GetPassword()}, {m.GetJoinedDate()}, {m.GetMembershipType()}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while saving members to file : {e.Message}");
            }
        }

        public void LoadMembersFromFile(string filename)
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
                            if (parts.Length == 6)
                            {
                                int id = int.Parse(parts[0].Trim());
                                string firstName = parts[1].Trim();
                                string surname = parts[2].Trim();
                                string password = parts[3].Trim();
                                DateTime joinedDate = DateTime.Parse(parts[4].Trim());
                                Member.MembershipLevel membershipType = (Member.MembershipLevel)Enum.Parse(typeof(Member.MembershipLevel), parts[5].Trim());                            
                                members.Add(new Member(id, firstName, surname, password, joinedDate, membershipType));
                            }
                        }
                    }
                    Console.WriteLine($"Members loaded from {filename}");
                }
                else
                {
                    Console.WriteLine($"File {filename} does not exist. Starting with an empty member list.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while loading members from file : {e.Message}");
            }
        }

        public List<Member> GetMembers()
        {
            return members;
        }

        public void AddBookRequest(Book book, Member member)
        {
            BookRequest request = new BookRequest(book, member);
            bookRequests.Add(request);
            Console.WriteLine($"Book request added for '{book.GetTitle()}' by {member.GetFirstName()} {member.GetSurname()}");
        }

        public void SaveBookRequestsToFile(string filename)
        {
             try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (BookRequest b in bookRequests)
                    {
                        writer.WriteLine($"{b.RequestedBook.Author}, {b.RequestedBook.Title}, {b.RequestedBook.Year}, {b.RequestingMember.GetId()}, {b.RequestDate}, {b.Status}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while saving book requests to file : {e.Message}");
            }
        }
    }
}