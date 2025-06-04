using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infra.Persistence.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("Category");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasColumnType("varchar(200)");
        }
    }
}
