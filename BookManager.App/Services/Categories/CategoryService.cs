using BookManager.App.Models;
using BookManager.App.Models.Categories;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;

namespace BookManager.App.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public ResultViewModel<int> Insert(CreateCategoryInputModel model)
        {
            var category = new Category( model.Name,model.Description );

            var categoryId = _categoryRepository.Insert(category);

            return ResultViewModel<int>.Success(categoryId);
        }
        public ResultViewModel Update(int id, UpdateCategoryInputModel model)
        {
            var category = _categoryRepository.GetById(id);

            if (category is null)
                return ResultViewModel.Error("Not Found");

            if(model.Name is not null) category.Name = model.Name;
            if(model.Description is not null) category.Description = model.Description;

            if (model.Description == string.Empty) category.Description = null;

            _categoryRepository.Update(category);

            return ResultViewModel.Success();
        }
        public ResultViewModel Delete(int id)
        {
            var category = _categoryRepository.GetById(id);

            if (category is null)
                return ResultViewModel.Error("Not Found");

            _categoryRepository.Delete(category);

            return ResultViewModel.Success();
        }
        public ResultViewModel<CategoryViewModel?> GetById(int id)
        {
            var category = _categoryRepository.GetById(id);

            return category is null ?
                ResultViewModel<CategoryViewModel?>.Error("Categoria não encontrada!") :
                ResultViewModel<CategoryViewModel?>.Success(CategoryViewModel.FromEntity(category));
        }
        public ResultViewModel<List<CategoryViewModel>> GetAll()
        {
            var listCategories = _categoryRepository.GetAll();

            var list = listCategories.Select(CategoryViewModel.FromEntity).ToList();

            return ResultViewModel<List<CategoryViewModel>>.Success(list);
        }
    }
}
