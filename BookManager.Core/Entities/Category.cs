using System.Collections.Generic;

namespace BookManager.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category() : base() { } 
            
        public Category(string name, string? description) 
            : base()
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
