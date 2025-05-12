using BookManager.Core.Entities;
using BookManager.Infra.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence
{
    public class BookManagerDbContext : DbContext
    {
        public BookManagerDbContext(
            DbContextOptions<BookManagerDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new BookAuthorMap());
            builder.ApplyConfiguration(new AuthorMap());

            base.OnModelCreating(builder);
        }
    }
}
