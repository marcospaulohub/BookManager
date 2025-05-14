using BookManager.App.Models;
using BookManager.App.Models.Loans;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;

namespace BookManager.App.Services.Loans
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public ResultViewModel<int> Insert(CreateLoanInputModel model)
        {
            var loan = new Loan(
                model.UserId,
                model.BookId
                );

            var loanId = _loanRepository.Insert(loan);

            return ResultViewModel<int>.Success(loanId);
        }

        public ResultViewModel<LoanViewModel?> GetById(int id)
        {
            var loan = _loanRepository.GetById(id);

            return loan is null ?
                ResultViewModel<LoanViewModel?>.Error("Empréstimo não encontrado!") :
                ResultViewModel<LoanViewModel?>.Success(LoanViewModel.FromEntity(loan));
        }
    }
}
