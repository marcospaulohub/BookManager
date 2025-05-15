using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookManagerDbContext _context;

        public UserRepository(BookManagerDbContext context)
        {
            _context = context;
        }

        public int Insert(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();

            return item.Id;
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
        }

        public void Delete(User item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            var user = _context
                .Users
                .Include(l => l.Loans)
                .SingleOrDefault(u => u.Id == id && u.DeletedAt == null);

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var listUser = _context
                .Users
                .Include(l => l.Loans)
                .Where(u => u.DeletedAt ==  null)
                .ToList();

            return listUser;
        }
        
    }
}
