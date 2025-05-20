using Bogus;
using BookManager.App.Models.Authors;
using BookManager.App.Models.Books;
using BookManager.Core.Entities;

namespace BookManager.Test.Fakes
{
    public static class FakeDataHelper
    {
        public static CreateBookInputModel CreateFakeBook() => _bookFaker.Generate();
        public static CreateAuthorInputModel CreateFakeAuthor() => _authorFaker.Generate();
        
        //public static BookAuthor CreateFakeBookAuthor() => _bookAuthorFaker.Generate();

        public static List<CreateBookInputModel> CreateFakeBooks(int count) => _bookFaker.Generate(count);
        public static List<CreateAuthorInputModel> CreateFakeAuthors(int count) => _authorFaker.Generate(count);
        
        //public static List<BookAuthor> CreateFakeBookAuthors(int count) => _bookAuthorFaker.Generate(count);

        private static readonly Faker<CreateBookInputModel> _bookFaker = new Faker<CreateBookInputModel>()
            //.RuleFor(b => b.Id, f => f.Random.Int(1, 1000))
            .RuleFor(b => b.Title, f => f.Commerce.ProductName())
            .RuleFor(b => b.ISBN, f => f.Random.Replace("###-#-##-######-#"));

        private static readonly Faker<CreateAuthorInputModel> _authorFaker = new Faker<CreateAuthorInputModel>()
            //.RuleFor(a => a.Id, f => f.Random.Int(1, 1000))
            .RuleFor(a => a.Name, f => f.Name.FullName())
            .RuleFor(a => a.Nationality, "Brasileiro")
            .RuleFor(a => a.BirthDate, f => f.Date.Past(50, DateTime.Today.AddYears(-20)))
            .RuleFor(a => a.Biography, f => f.Lorem.Paragraph())
            .RuleFor(a => a.OfficialWebsite, f => f.Internet.Url());

        //private static readonly Faker<BookAuthor> _bookAuthorFaker = new Faker<BookAuthor>()
        //    .RuleFor(ba => ba.Id, f => f.Random.Int(1, 1000))
        //    .RuleFor(ba => ba.Book, f => CreateFakeBook())
        //    .RuleFor(ba => ba.Author, f => CreateFakeAuthor());
    }
}
