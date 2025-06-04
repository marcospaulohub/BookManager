using System;

namespace BookManager.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int userId, int bookId) : base()
        {
            UserId = userId;
            BookId = bookId;
            LoanDate = DateTime.Today;
            ReturnDate = GetValidDateForReturn();
        }

        private const int LOAN_PERIOD = 14;

        public int UserId { get; private set; }
        public User User { get; set; }
        public int BookId { get; private set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }

        private DateTime GetValidDateForReturn()
        {
            var dateForReturn = DateTime.Today.AddDays(LOAN_PERIOD);

            if (dateForReturn.DayOfWeek == DayOfWeek.Saturday) dateForReturn = dateForReturn.AddDays(2);

            if (dateForReturn.DayOfWeek == DayOfWeek.Sunday) dateForReturn = dateForReturn.AddDays(1);

            return dateForReturn;
        }
    }
}
