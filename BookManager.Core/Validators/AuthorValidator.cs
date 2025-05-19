using BookManager.Core.Entities;
using FluentValidation;
using System;

namespace BookManager.Core.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("O nome do autor é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.");

            RuleFor(a => a.BirthDate)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("A data de nascimento não pode ser futura.");

            RuleFor(a => a.Nationality)
                .Must(n => n == "Brasileiro" || n == "Estrangeiro")
                .WithMessage("Nacionalidade deve ser 'Brasileiro' ou 'Estrangeiro'.");

        }
    }
}
