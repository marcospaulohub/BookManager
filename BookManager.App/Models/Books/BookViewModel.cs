using BookManager.Core.Entities;

namespace BookManager.App.Models.Books
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string? iSBN, DateTime? publicationDate, string authorsIds)
        {
            Id = id;
            Title = title;
            ISBN = iSBN;
            PublicationDate = publicationDate;
            AuthorsIds = authorsIds;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string? ISBN { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string AuthorsIds { get; set; }

        public static BookViewModel? FromEntity(Book entity)
            => new(entity.Id,
                entity.Title,
                entity.ISBN,
                entity.PublicationDate,
                GetListAuthors(entity));
       

        private static string GetListAuthors(Book book)
        {
            var authorIds = "";

            foreach (var author in book.Authors)
            {
                authorIds += $"{author.Id.ToString() }";
            }

            return authorIds;
        }
            
    }
}
