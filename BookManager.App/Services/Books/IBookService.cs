using BookManager.App.Models;
using BookManager.App.Models.Books;

namespace BookManager.App.Services.Books
{
    public interface IBookService
    {
        ResultViewModel<int> Insert(CreateBookInputModel model);
        ResultViewModel<BookViewModel?> GetById(int id);
        ResultViewModel<List<BookViewModel>> GetAll();
        ResultViewModel Update(int id, UpdateBookInputModel model);
        ResultViewModel Delete(int id);
    }
}
