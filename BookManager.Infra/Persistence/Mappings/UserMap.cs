using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infra.Persistence.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User");

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(b => b.Email)
                .HasColumnType("varchar(200)");
        }
    }
}
