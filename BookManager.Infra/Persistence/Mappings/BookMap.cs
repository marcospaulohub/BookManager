using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infra.Persistence.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .ToTable("Book");

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Title)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(b => b.ISBN)
                .HasColumnType("varchar(20)");

            #region Exemplo de mapeamento
            /*
             Esse exemplo mostra como seria o mapeamento sem a utilização do objeto BookAuthor e o BookAuthorMap.
             Com as classes BookAuthor e BookAuthorMap focamos o mapeamento apenas nessas classes.
             */

            //builder
            //    .HasMany(b => b.Authors)
            //    .WithOne(ba => ba.Book)
            //    .HasForeignKey(b => b.BookId);

            #endregion
        }
    }
}
