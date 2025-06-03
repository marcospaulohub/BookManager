using BookManager.Core.Entities;

namespace BookManager.App.Models.Users
{
    public class UserViewModel
    {
        public UserViewModel(int id, string name, string email, int totalLoans)
        {
            Id = id;
            Name = name;
            Email = email;
            TotalLoans = totalLoans;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int TotalLoans { get; set; }

        public static UserViewModel? FromEntity(User entity)
            => new(entity.Id,
                entity.Name,
                entity.Email.Address,
                entity.Loans.Count);
    }
}
