using BookManager.App.Models.Books;
using FluentValidation;

namespace BookManager.App.Validators.Books
{
    public class CreateBookInputModelValidator : AbstractValidator<CreateBookInputModel>
    {
        public CreateBookInputModelValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                    .WithMessage("O titulo é obrigatório.")
                .MinimumLength(3)
                    .WithMessage("O titulo deve ter pelo menos 3 caracteres.")
                .MaximumLength(200)
                    .WithMessage("O titulo deve ter no máximo 200 caracteres.");

            RuleFor(b => b.ISBN)
                .MinimumLength(5)
                    .WithMessage("O ISBN deve ter pelo menos 5 caracteres.")
                .MaximumLength(20)
                    .WithMessage("O titulo deve ter no máximo 20 caracteres.");

            RuleFor(b => b.AuthorsIds)
                .NotEmpty()
                    .WithMessage("O id do autor é obrigatório")
                .Matches(@"^\d+(,\s*\d+)*$")
                    .WithMessage("O formato dos IDs dos autores é inválido. Use apenas números separados por vírgulas.");

        }
    }
}
