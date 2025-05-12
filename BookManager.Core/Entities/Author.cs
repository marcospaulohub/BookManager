using System;
using System.Collections.Generic;

namespace BookManager.Core.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
        public string? OfficialWebsite { get; set; }
        public List<BookAuthor> Books { get; set; } = [];
    }
}
