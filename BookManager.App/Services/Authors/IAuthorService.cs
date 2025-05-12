using BookManager.App.Models;
using BookManager.App.Models.Authors;

namespace BookManager.App.Services.Authors
{
    public interface IAuthorService
    {
        ResultViewModel<int> Insert(CreateAuthorInputModel model);
        ResultViewModel<AuthorViewModel?> GetById(int id);
    }
}
