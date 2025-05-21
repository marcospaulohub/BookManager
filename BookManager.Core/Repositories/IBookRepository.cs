using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IBookRepository : _IRepository<Book>
    {
        Book? GetByTitle(string title);
        Book? GetByIsbn(string isbn);
    }
}
