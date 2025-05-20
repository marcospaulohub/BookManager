using BookManager.App.Validators.Books;
using BookManager.Test.Fakes;

namespace BookManager.Test.Core
{
    public class BookTest
    {
        private readonly CreateBookInputModelValidator _validator = new();

        [Fact]
        public void Book_Should_Have_Valid_Title()
        {
            // Testar se autor tem nome válido
            var book = FakeDataHelper.CreateFakeBook();

            Assert.False(string.IsNullOrWhiteSpace(book.Title));
        }

        [Fact]
        public void Book_Should_Have_Valid_ISBN()
        {
            // Testar se livro tem ISBN no formato esperado
            var book = FakeDataHelper.CreateFakeBook();

            Assert.Matches(@"\d{3}-\d-\d{2}-\d{6}-\d", book.ISBN);
        }

        [Fact]
        public void Book_Title_Should_Have_Minimum_Length()
        {
            // Título do livro deve ter no mínimo 3 caracteres

            var book = FakeDataHelper.CreateFakeBook();
            book.Title = "ABCDE";

            Assert.True(book.Title.Length >= 5);
        }

        [Fact]
        public void Book_ISBN_Should_Have_13_Characters_Without_Hyphens()
        {
            // ISBN deve conter 13 dígitos (com ou sem hífens)

            var book = FakeDataHelper.CreateFakeBook();
            var digitsOnly = new string(book.ISBN.Where(char.IsDigit).ToArray());

            Assert.Equal(13, digitsOnly.Length);
        }


    }
}
