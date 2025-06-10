namespace BookManager.Core.Entities
{
    public class BookCategory : BaseEntity
    {
        public BookCategory() : base() { }
        public BookCategory(Book book, Category category) : base()
        {
            Book = book;
            Category = category;

            book.Categories.Add(this);
            category.Books.Add(this);
        }

        public int BookId { get; set; }
        public Book Book { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
