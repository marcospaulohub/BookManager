using BookManager.Core.Entities;

namespace BookManager.App.Models.Books
{
    public class BookSummaryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public static BookSummaryViewModel FromEntity(Book book) =>
            new() { Id = book.Id, Title = book.Title };
    }
}
