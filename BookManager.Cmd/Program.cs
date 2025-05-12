using BookManager.Core.Entities;

namespace BookManager.Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var autor1 = new Author { Id = 1, Name = "José Sampaio" };
            var autor2 = new Author { Id = 1, Name = "Sampaio Neto" };

            var listAuthor = new List<Author> { autor1, autor2 };
           

            var book = new Book("Ensaio sobre a cegueira", "978-1234567890", new DateTime(1995, 01, 01), listAuthor);

            Console.WriteLine($"Livro: {book.Title}");
            Console.WriteLine($"Data de criação: {book.CreatedAt}");

            foreach(var a in book.Authors)
            {
                Console.WriteLine($"Autor: {a.Author.Name}");
            }
        }
    }
}
