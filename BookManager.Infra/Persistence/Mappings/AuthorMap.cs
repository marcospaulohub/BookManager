using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infra.Persistence.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .ToTable("Author");

            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(a => a.Nationality)
                .HasColumnType("varchar(100)");

            builder
                .Property(a => a.Biography)
                .HasColumnType("varchar(max)");

            builder
                .Property(a => a.OfficialWebsite)
                .HasColumnType("varchar(200)");

            #region Exemplo de mapeamento
            /*
             Esse exemplo mostra como seria o mapeamento sem a utilização do objeto BookAuthor e o BookAuthorMap.
             Com as classes BookAuthor e BookAuthorMap focamos o mapeamento apenas nessas classe.
             */

            //builder
            //    .HasMany(a => a.Books)
            //    .WithOne(ba => ba.Author)
            //    .HasForeignKey(ba => ba.AuthorId);
            #endregion

        }
    }
}
