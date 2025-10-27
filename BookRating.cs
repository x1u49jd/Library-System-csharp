using System.Dynamic;

namespace LibrarySystemApp
{
    public class BookRating
    {
        public Book RatedBook { get; set; }
        public Member RatingMember { get; set; }
        public RatingScale Rating { get; set; }

        public BookRating(Book book, Member member, RatingScale rating)
        {
            RatedBook = book;
            RatingMember = member;
            Rating = rating;
        }

        public enum RatingScale
        {
            One = 1,
            Two = 2 ,
            Three = 3,
            Four = 4,
            Five = 5
        }
    }
}