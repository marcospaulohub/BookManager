using BookManager.App.Models;
using BookManager.App.Models.Loans;

namespace BookManager.App.Services.Loans
{
    public interface ILoanService
    {
        ResultViewModel<int> Insert(CreateLoanInputModel model);
        ResultViewModel<LoanViewModel?> GetById(int id);
        ResultViewModel<List<LoanViewModel>> GetAll();
    }
}
