using BookManager.Core.Entities;

namespace BookManager.App.Models.Authors
{
    public class AuthorSummaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static AuthorSummaryViewModel FromEntity(Author author) =>
            new() { Id = author.Id, Name = author.Name };
    }
}
