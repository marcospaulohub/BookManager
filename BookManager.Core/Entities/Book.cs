using System;
using System.Collections.Generic;
using System.Linq;

namespace BookManager.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string iSBN, DateTime publicationDate, IEnumerable<Author> authors) : base()
        {
            Title = title;
            ISBN = iSBN;
            PublicationDate = publicationDate;
            Authors = authors
                .Select(a => new BookAuthor { Author = a })
                .ToList();
        }

        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public DateTime PublicationDate { get; private set; }
        public List<BookAuthor> Authors { get; set; } = [];
    }
}
