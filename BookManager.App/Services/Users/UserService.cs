using BookManager.App.Models;
using BookManager.App.Models.Users;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using BookManager.Core.ValueObject;

namespace BookManager.App.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ResultViewModel<int> Insert(CreateUserInputModel model)
        {
            var user = new User(
                model.Name,
                new Email(model.Email)
                );

            var userId = _userRepository.Insert(user);

            return ResultViewModel<int>.Success(userId);
        }

        public ResultViewModel<UserViewModel?> GetById(int id)
        {
            var user = _userRepository.GetById(id);

            return user is null ?
                ResultViewModel<UserViewModel?>.Error("Usuário não encontrado!") :
                ResultViewModel<UserViewModel?>.Success(UserViewModel.FromEntity(user));
        }

        public ResultViewModel<List<UserViewModel>> GetAll()
        {
            var listBooks =
                _userRepository.GetAll();

            var list = listBooks.Select(
                UserViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(list);
        }

    }
}
