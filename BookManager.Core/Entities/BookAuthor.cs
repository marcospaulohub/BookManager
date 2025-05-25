namespace BookManager.Core.Entities
{
    public class BookAuthor : BaseEntity
    {
        public BookAuthor() : base() { }
        public BookAuthor(Book book, Author author) : base()
        {
            Book = book;
            Author = author;

            book.Authors.Add(this);
            author.Books.Add(this);
        }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
