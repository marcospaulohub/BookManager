using BookManager.Core.Entities;

namespace BookManager.App.Models.Categories
{
    public class CategoryViewModel
    {
        public CategoryViewModel(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public static CategoryViewModel? FromEntity(Category entity)
            => new(entity.Id, entity.Name, entity.Description);
    }
}
