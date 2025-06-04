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
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new BookAuthorMap());
            builder.ApplyConfiguration(new AuthorMap());
            builder.ApplyConfiguration(new BookCategoryMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new LoanMap());

            base.OnModelCreating(builder);
        }
    }
}
