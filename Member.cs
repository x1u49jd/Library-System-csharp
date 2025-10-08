namespace LibrarySystemApp
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime JoinedDate { get; set; }

        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public Member(int id, string firstName, string surname, string password, DateTime joinedDate)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Password = password;
            JoinedDate = joinedDate;
        }
    }
}