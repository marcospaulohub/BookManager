using BookManager.Core.Entities;

namespace BookManager.App.Models.Loans
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, int userId, int bookId, DateTime loanDate, DateTime returnDate)
        {
            Id = id;
            UserId = userId;
            BookId = bookId;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public static LoanViewModel? FromEntity(Loan entity)
            => new(entity.Id,
                entity.UserId,
                entity.BookId,
                entity.LoanDate,
                entity.ReturnDate);
    }
}
