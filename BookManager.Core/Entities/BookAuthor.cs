namespace BookManager.Core.Entities
{
    public class BookAuthor : BaseEntity
    {
        public BookAuthor(int bookId, int authorId) : base()
        {
            BookId = bookId;
            AuthorId = authorId;
        }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
