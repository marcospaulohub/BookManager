using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IAuthorRepository : _IRepository<Author>
    {
        Author GetByName(string name);
    }
}
