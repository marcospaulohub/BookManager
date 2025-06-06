namespace BookManager.App.Models.Books
{
    public class CreateBookInputModel
    {
        public CreateBookInputModel() { }

        public CreateBookInputModel(string title, string? iSBN, DateTime publicationDate, string authorsIds)
        {
            Title = title;
            ISBN = iSBN;
            PublicationDate = publicationDate;
            AuthorsIds = authorsIds;
        }
        public string Title { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AuthorsIds { get; set; }
        public string CategoriesIds { get; set; }
    }
}
