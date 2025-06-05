using BookManager.App.Models;
using BookManager.App.Models.Categories;

namespace BookManager.App.Services.Categories
{
    public interface ICategoryService 
    {
        ResultViewModel<int> Insert(CreateCategoryInputModel model);
        ResultViewModel Update(int id, UpdateCategoryInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel<CategoryViewModel?> GetById(int id);
        ResultViewModel<List<CategoryViewModel>> GetAll();
    }
}
