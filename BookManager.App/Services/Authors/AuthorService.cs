using BookManager.App.Models;
using BookManager.App.Models.Authors;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;

namespace BookManager.App.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public ResultViewModel<int> Insert(CreateAuthorInputModel model)
        {
            var author = new Author(
                model.Name,
                model.Nationality,
                model.BirthDate,
                model.DeathDate,
                model.Biography,
                model.OfficialWebsite
                );

            var authorId = _authorRepository.Insert(author);

            return ResultViewModel<int>.Success(authorId);
        }

        public ResultViewModel<AuthorViewModel?> GetById(int id)
        {
            var author = _authorRepository.GetById(id);

            return author is null ?
                ResultViewModel<AuthorViewModel?>.Error("Autor não encontrado!") :
                ResultViewModel<AuthorViewModel?>.Success(AuthorViewModel.FromEntity(author));
        }

        public ResultViewModel<List<AuthorViewModel>> GetAll()
        {
            var listAuthors =
                _authorRepository.GetAll();

            var list = listAuthors.Select(
                AuthorViewModel.FromEntity).ToList();

            return ResultViewModel<List<AuthorViewModel>>.Success(list);
        }

        public ResultViewModel Update(int id, UpdateAuthorInputModel model)
        {
            var author = _authorRepository.GetById(id);

            if (author is null)
                return ResultViewModel.Error("Not Found");

            if (model.Name is not null) author.Name = model.Name;
            if (model.Nationality is not null) author.Nationality = model.Nationality;
            if (model.Biography is not null) author.Biography = model.Biography;
            if (model.OfficialWebsite is not null) author.OfficialWebsite = model.OfficialWebsite;
            if (model.BirthDate is not null) author.BirthDate = model.BirthDate;
            if (model.DeathDate is not null) author.DeathDate = model.DeathDate;


            if (model.Nationality == string.Empty) author.Nationality = null;
            if (model.Biography == string.Empty) author.Biography = null;
            if (model.OfficialWebsite == string.Empty) author.OfficialWebsite = null;

            _authorRepository.Update(author);

            return ResultViewModel.Success();
        }
    }
}
