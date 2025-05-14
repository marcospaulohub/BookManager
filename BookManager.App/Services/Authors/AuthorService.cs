using BookManager.App.Models;
using BookManager.App.Models.Authors;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
