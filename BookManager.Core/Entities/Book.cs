using System;
using System.Collections.Generic;

namespace BookManager.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, DateTime publicationDate) : base()
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationDate = publicationDate;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public DateTime PublicationDate { get; private set; }
        public List<Author> Authors { get; set; } = [];
    }
}
