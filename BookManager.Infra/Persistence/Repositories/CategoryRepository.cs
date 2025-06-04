using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookManagerDbContext _context;

        public CategoryRepository(BookManagerDbContext context)
        {
            _context = context;
        }

        public int Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category.Id;
        }
        public void Update(Category category)
        {
            category.SetAsUpdated();

            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public void Delete(Category category)
        {
            category.SetAsDeleted();

            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public Category GetById(int id)
        {
            var category = _context
                .Categories
                .Include(b => b.Books)
                    .ThenInclude(bc => bc.Capacity)
                .SingleOrDefault(c => c.Id == id && c.DeletedAt == null);

            return category;
        }
        public IEnumerable<Category> GetAll()
        {
            var listCategories = _context
                .Categories
                .Include(b => b.Books)
                    .ThenInclude(bc => bc.Book)
                .Where(c => c.DeletedAt == null)
                .ToList();

            return listCategories;
        }
    }
}
