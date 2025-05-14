using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookManagerDbContext _context;

        public AuthorRepository(BookManagerDbContext context)
        {
            _context = context;
        }

        public int Insert(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();

            return author.Id;
        }
        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
        public void Delete(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
        public Author? GetById(int id)
        {
            var author = _context
                .Authors
                .Include(b => b.Books)
                .SingleOrDefault(a => a.Id == id && a.DeletedAt == null);

            return author;
        }
        public IEnumerable<Author> GetAll()
        {
            var listAuthors = _context
                .Authors
                .Include(b => b.Books) // a.Books é List<BookAuthor>
                    .ThenInclude(ba => ba.Book) // aqui traz os dados da entidade Book
                .Where(a  => a.DeletedAt == null)
                .ToList();

            return listAuthors;
        }
        public Author? GetByName(string name)
        {
            var author = _context
                .Authors
                .Include(b => b.Books)
                .FirstOrDefault(a => a.Name == name && a.DeletedAt == null);

            return author;
        }
    }
}
