using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetByName(string name);
    }
}
