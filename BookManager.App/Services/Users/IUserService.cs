using BookManager.App.Models;
using BookManager.App.Models.Users;

namespace BookManager.App.Services.Users
{
    public interface IUserService
    {
        ResultViewModel<int> Insert(CreateUserInputModel model);
        ResultViewModel<UserViewModel?> GetById(int id);
        ResultViewModel<List<UserViewModel>> GetAll();
    }
}
