using BookManager.Core.Entities;
using FluentValidation;
using System;

namespace BookManager.Core.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("O título do Livro é obrigatório.")
                .MinimumLength(5).WithMessage("O título deve ter pelo menos 5 caracteres.");

            RuleFor(b => b.ISBN)
                .MinimumLength(5).WithMessage("O ISBN deve ter pelo menos 5 caracteres.")
                .MaximumLength(20).WithMessage("O ISBN deve ter no máximo 20 caracteres.");

            RuleFor(b => b.PublicationDate)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("A data de publicação não pode ser futura.");
        }

    }
}
