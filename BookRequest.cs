using System.Dynamic;

namespace LibrarySystemApp
{
    public class BookRequest
    {
        public Book RequestedBook { get; set; }
        public Member RequestingMember { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }

        public BookRequest(Book book, Member member)
        {
            RequestedBook = book;
            RequestingMember = member;
            RequestDate = DateTime.Now;
            Status = RequestStatus.Pending;
        }

        public enum RequestStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }
}