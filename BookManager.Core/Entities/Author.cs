using System;
using System.Collections.Generic;

namespace BookManager.Core.Entities
{
    public class Author : BaseEntity
    {
        public Author() : base() { } 
        public Author(string name) : base()
        {
            Name = name;
        }

        public Author(string name, string? nationality, DateTime? birthDate, DateTime? deathDate, string? biography, string? officialWebsite)
        {
            Name = name;
            Nationality = nationality;
            BirthDate = birthDate;
            DeathDate = deathDate;
            Biography = biography;
            OfficialWebsite = officialWebsite;
        }

        public string Name { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
        public string? OfficialWebsite { get; set; }
        public List<BookAuthor> Books { get; set; } = [];
    }
}
