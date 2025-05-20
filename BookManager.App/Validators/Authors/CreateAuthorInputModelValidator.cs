using BookManager.App.Models.Authors;
using FluentValidation;

namespace BookManager.App.Validators.Authors
{
    public class CreateAuthorInputModelValidator : AbstractValidator<CreateAuthorInputModel>
    {
        public CreateAuthorInputModelValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                    .WithMessage("O nome do autor é obrigatório.")
                .MinimumLength(3)
                    .WithMessage("O nome deve ter pelo menos 3 caracteres.")
                .MaximumLength(100)
                    .WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(a => a.Nationality)
                .Must(n => n == "Brasileiro" || n == "Estrangeiro")
                .WithMessage("Nacionalidade deve ser 'Brasileiro' ou 'Estrangeiro'.");

            RuleFor(a => a.BirthDate)
                .LessThanOrEqualTo(DateTime.Today)
                    .WithMessage("A data de nascimento não pode ser futura.")
                .Must(a => a < DateTime.Now.AddYears(-18))
                    .WithMessage("O Autor precisar ser maior de idade.");
        }
    }
}
