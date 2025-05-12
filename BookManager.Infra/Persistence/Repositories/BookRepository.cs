using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly BookManagerDbContext _context;

        public BookRepository(BookManagerDbContext context)
        {
            _context = context;
        }

        public int Insert(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book.Id;
        }
        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public Book GetById(int id)
        {
            var book = _context
                .Books
                .Include(a => a.Authors)
                .SingleOrDefault(b => b.Id == id && b.DeletedAt == null);

            return book;
        }
        public IEnumerable<Book> GetAll()
        {
            var listBooks = _context
                .Books
                .Where(b => b.DeletedAt == null)
                .ToList();

            return listBooks;
        }

        public Book? GetByIsbn(string isbn)
        {
            var book = _context
                .Books
                .Include(a => a.Authors)
                .SingleOrDefault(b => b.ISBN == isbn && b.DeletedAt == null);

            return book;
        }

        public Book? GetByTitle(string title)
        {
            var book = _context
                .Books
                .Include(a => a.Authors)
                .SingleOrDefault(b => b.Title == title && b.DeletedAt == null);

            return book;
        }
    }
}
