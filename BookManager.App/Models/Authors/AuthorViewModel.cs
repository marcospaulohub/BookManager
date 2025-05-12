using BookManager.Core.Entities;

namespace BookManager.App.Models.Authors
{
    public class AuthorViewModel
    {
        public AuthorViewModel(int id, string name, string? nationality, DateTime? birthDate, DateTime? deathDate, string? biography, string? officialWebsite)
        {
            Id = id;
            Name = name;
            Nationality = nationality;
            BirthDate = birthDate;
            DeathDate = deathDate;
            Biography = biography;
            OfficialWebsite = officialWebsite;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
        public string? OfficialWebsite { get; set; }
        public string BooksIds { get; set; }

        public static AuthorViewModel? FromEntity(Author entity)
            => new(entity.Id,
                   entity.Name,
                   entity.Nationality,
                   entity.BirthDate,
                   entity.DeathDate,
                   entity.Biography,
                   entity.OfficialWebsite);

        private static string GetListBooks(Author author)
        {
            var bookIds = "";

            foreach (var book in author.Books)
            {
                bookIds += $"{book.Id.ToString()}";
            }

            return bookIds;
        }
    }
}
