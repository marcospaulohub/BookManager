using System.Collections.Generic;

namespace BookManager.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category(string name, string? description)
        {
            Name = name;
            Description = description;
            
            IsActive = true;
        }

        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public List<BookCategory> Books { get; set; } = [];
    }
}
