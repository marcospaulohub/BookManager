using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BookManagerDbContext _context;

        public LoanRepository(BookManagerDbContext context)
        {
            _context = context;
        }

        public int Insert(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return loan.Id;
        }

        public void Update(Loan loan)
        {
            _context.Loans.Update(loan);
            _context.SaveChanges();
        }

        public void Delete(Loan loan)
        {
            _context.Loans.Update(loan);
            _context.SaveChanges();
        }
        public Loan GetById(int id)
        {
            var loan = _context
                .Loans
                .Include(u => u.User)
                .Include(b => b.Book)
                .SingleOrDefault(l => l.Id == id && l.DeletedAt == null);

            return loan;
        }

        public IEnumerable<Loan> GetAll()
        {
            var listLoan = _context
                .Loans
                .Include(u => u.User)
                .Include(b => b.Book)
                .Where(l => l.DeletedAt == null)
                .ToList();

            return listLoan;
        }
    }
}
