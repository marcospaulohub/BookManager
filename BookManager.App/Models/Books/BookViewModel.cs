using BookManager.App.Models.Authors;
using BookManager.Core.Entities;

namespace BookManager.App.Models.Books
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string? iSBN, DateTime? publicationDate, List<AuthorSummaryViewModel> authors)
        {
            Id = id;
            Title = title;
            ISBN = iSBN;
            PublicationDate = publicationDate;
            Authors = authors;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string? ISBN { get; set; }
        public DateTime? PublicationDate { get; set; }
        public List<AuthorSummaryViewModel> Authors { get; set; }

        public static BookViewModel? FromEntity(Book entity)
            => new(entity.Id,
                entity.Title,
                entity.ISBN,
                entity.PublicationDate,
                entity.Authors.Select(ba => AuthorSummaryViewModel.FromEntity(ba.Author)).ToList()
                );
            
    }
}
