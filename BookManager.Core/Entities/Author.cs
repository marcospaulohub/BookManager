using System;
using System.Collections.Generic;

namespace BookManager.Core.Entities
{
    public class Author : BaseEntity
    {
        public Author(string name, string nationality) : base()
        {
            Name = name;
            Nationality = nationality;
        }

        public string Name { get; private set; }
        public string Nationality { get; private set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
        public string? OfficialWebsite { get; set; }
        public List<Book> Books { get; set; } = [];
    }
}
