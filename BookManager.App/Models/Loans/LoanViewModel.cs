using BookManager.Core.Entities;

namespace BookManager.App.Models.Loans
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, int userId, string userName, int bookId, string bookTitle, DateTime loanDate, DateTime returnDate)
        {
            Id = id;
            UserId = userId;
            UserName = userName;
            BookId = bookId;
            BookTitle = bookTitle;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public static LoanViewModel? FromEntity(Loan entity)
            => new(entity.Id,
                entity.UserId,
                entity.User.Name,
                entity.BookId,
                entity.Book.Title,
                entity.LoanDate,
                entity.ReturnDate);
    }
}
