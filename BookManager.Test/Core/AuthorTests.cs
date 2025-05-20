using BookManager.App.Validators.Authors;
using BookManager.Test.Fakes;
using FluentValidation.TestHelper;

namespace BookManager.Test.Core
{
    public class AuthorTests
    {
        private readonly CreateAuthorInputModelValidator _validator = new();

        [Fact]
        public void Author_Should_Have_Valid_Name()
        {
            // Testar se autor tem nome válido
            var author = FakeDataHelper.CreateFakeAuthor();

            Assert.False(string.IsNullOrWhiteSpace(author.Name));
        }

        [Fact]
        public void Should_Create_List_Of_Authors()
        {
            // Testar múltiplas instâncias

            var authors = FakeDataHelper.CreateFakeAuthors(5);

            Assert.Equal(5, authors.Count);
            Assert.All(authors, a => Assert.False(string.IsNullOrEmpty(a.Name)));
        }

        [Fact]
        public void Author_BirthDate_Should_Not_Be_In_The_Future()
        {
            // Data de nascimento não pode ser futura

            // Arrange
            var author = FakeDataHelper.CreateFakeAuthor();
            author.BirthDate = DateTime.Today.AddDays(1); // Forçar data inválida

            // Act
            var result = _validator.TestValidate(author);

            // Assert
            result.ShouldHaveValidationErrorFor(a => a.BirthDate)
                .WithErrorMessage("A data de nascimento não pode ser futura.");

        }

        [Fact]
        public void Author_Name_Should_Not_Be_Empty()
        {
            // Nome do autor é obrigatório

            // Arrange
            var author = FakeDataHelper.CreateFakeAuthor();
            author.Name = "";

            // Act
            var result = _validator.TestValidate(author);

            // Assert
            result.ShouldHaveValidationErrorFor(a => a.Name)
                .WithErrorMessage("O nome do autor é obrigatório.");

        }

        [Fact]
        public void Author_Name_Must_Be_At_Least_3_Characters_Long()
        {
            // Nome do autor é obrigatório

            // Arrange
            var author = FakeDataHelper.CreateFakeAuthor();
            author.Name = "AB";

            // Act
            var result = _validator.TestValidate(author);

            // Assert
            result.ShouldHaveValidationErrorFor(a => a.Name)
                .WithErrorMessage("O nome deve ter pelo menos 3 caracteres.");

        }
        

        [Fact]
        public void Author_Nationality_Should_Be_Valid()
        {
            // Nacionalidade deve ser brasileira ou estrangeira

            var author = FakeDataHelper.CreateFakeAuthor();
            var validNationalities = new[] { "Brasileiro", "Estrangeiro" };

            Assert.Contains(author.Nationality, validNationalities);
        }

        [Fact]
        public void Should_Pass_Validation_For_Valid_Author()
        {
            var author = FakeDataHelper.CreateFakeAuthor();
            var result = _validator.TestValidate(author);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Should_Fail_When_BirthDate_Is_Future()
        {
            var author = FakeDataHelper.CreateFakeAuthor();
            author.BirthDate = DateTime.Today.AddDays(1);

            var result = _validator.TestValidate(author);
            result.ShouldHaveValidationErrorFor(a => a.BirthDate);
        }

        [Fact]
        public void Should_Fail_When_Name_Is_Empty()
        {
            var author = FakeDataHelper.CreateFakeAuthor();
            author.Name = "";

            var result = _validator.TestValidate(author);
            result.ShouldHaveValidationErrorFor(a => a.Name);
        }

        [Fact]
        public void Should_Fail_When_Nationality_Is_Invalid()
        {
            var author = FakeDataHelper.CreateFakeAuthor();
            author.Nationality = "Extraterrestre";

            var result = _validator.TestValidate(author);
            result.ShouldHaveValidationErrorFor(a => a.Nationality);
        }

    }
}
