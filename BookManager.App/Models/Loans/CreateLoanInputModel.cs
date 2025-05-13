namespace BookManager.App.Models.Loans
{
    public class CreateLoanInputModel
    {
        public CreateLoanInputModel(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }

        public int UserId { get; private set; }
        public int BookId { get; private set; }
    }
}
