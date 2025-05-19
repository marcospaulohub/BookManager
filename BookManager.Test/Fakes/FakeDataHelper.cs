using Bogus;
using BookManager.Core.Entities;

namespace BookManager.Test.Fakes
{
    public static class FakeDataHelper
    {
        public static Book CreateFakeBook() => _bookFaker.Generate();
        public static Author CreateFakeAuthor() => _authorFaker.Generate();
        public static BookAuthor CreateFakeBookAuthor() => _bookAuthorFaker.Generate();

        public static List<Book> CreateFakeBooks(int count) => _bookFaker.Generate(count);
        public static List<Author> CreateFakeAuthors(int count) => _authorFaker.Generate(count);
        public static List<BookAuthor> CreateFakeBookAuthors(int count) => _bookAuthorFaker.Generate(count);

        private static readonly Faker<Book> _bookFaker = new Faker<Book>()
            .RuleFor(b => b.Id, f => f.Random.Int(1, 1000))
            .RuleFor(b => b.Title, f => f.Commerce.ProductName())
            .RuleFor(b => b.ISBN, f => f.Random.Replace("###-#-##-######-#"));

        private static readonly Faker<Author> _authorFaker = new Faker<Author>()
            .RuleFor(a => a.Id, f => f.Random.Int(1, 1000))
            .RuleFor(a => a.Name, f => f.Name.FullName())
            .RuleFor(a => a.Nationality, "Brasileiro")
            .RuleFor(a => a.BirthDate, f => f.Date.Past(50, DateTime.Today.AddYears(-20)))
            .RuleFor(a => a.Biography, f => f.Lorem.Paragraph())
            .RuleFor(a => a.OfficialWebsite, f => f.Internet.Url());

        private static readonly Faker<BookAuthor> _bookAuthorFaker = new Faker<BookAuthor>()
            .RuleFor(ba => ba.Id, f => f.Random.Int(1, 1000))
            .RuleFor(ba => ba.Book, f => _bookFaker.Generate())
            .RuleFor(ba => ba.Author, f => _authorFaker.Generate());
    }
}
