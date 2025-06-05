using BookManager.App.Models;
using BookManager.App.Models.Books;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;

namespace BookManager.App.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public ResultViewModel<int> Insert(CreateBookInputModel model)
        {
            var numberString = model.AuthorsIds;

            var numberArray = numberString.Split(',');

            var numberConvertedFromString = Array.ConvertAll(numberArray, Convert.ToInt32);

            List<Author> authors = new();

            for (int i = 0; i < numberConvertedFromString.Length; i++)
            {
                var author = _authorRepository.GetById(numberConvertedFromString[i]);

                if (author is null)
                    return ResultViewModel<int>.Error("Autor não encontrado!");

                authors.Add(author);
            }

            var book = new Book(
                model.Title,
                model.ISBN,
                model.PublicationDate,
                authors
                );

            var bookId = _bookRepository.Insert(book);

            return ResultViewModel<int>.Success(bookId);
        }
        public ResultViewModel<BookViewModel?> GetById(int id)
        {
            var book = _bookRepository.GetById(id);

            return book is null ?
                ResultViewModel<BookViewModel?>.Error("Livro não encontrado!") :
                ResultViewModel<BookViewModel?>.Success(BookViewModel.FromEntity(book));
        }

        public ResultViewModel<List<BookViewModel>> GetAll()
        {
            var listBooks = _bookRepository.GetAll();

            var list = listBooks.Select(
                BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(list);
        }

        public ResultViewModel Update(int id, UpdateBookInputModel model)
        {
            var book = _bookRepository.GetById(id);

            if (book is null)
                return ResultViewModel.Error("Not Found");

            if(model.Title is not null) book.Title = model.Title;
            if(model.ISBN is not null) book.ISBN = model.ISBN;

            if (model.ISBN == string.Empty) book.ISBN = null;

            _bookRepository.Update(book);

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book is null)
                return ResultViewModel.Error("Not Found");

            _bookRepository.Delete(book);

            return ResultViewModel.Success();
        }
    }
}
