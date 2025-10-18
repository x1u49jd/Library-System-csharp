namespace LibrarySystemApp
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime JoinedDate { get; set; }

        public MembershipLevel MembershipType { get; set; }

        public enum MembershipLevel
        {
            Member,
            Admin
        }

        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public Member(int id, string firstName, string surname, string password, DateTime joinedDate, MembershipLevel membershipType = MembershipLevel.Member)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Password = password;
            JoinedDate = joinedDate;
            MembershipType = membershipType;

        }

        public int GetId()
        {
            return Id;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetSurname()
        {
            return Surname;
        }

        public string GetPassword()
        {
            return Password;
        }

        public DateTime GetJoinedDate()
        {
            return JoinedDate;
        }

        public MembershipLevel GetMembershipType()
        {
            return MembershipType;
        }
    }
}