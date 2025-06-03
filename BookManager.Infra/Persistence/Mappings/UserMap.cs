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
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .OwnsOne(u => u.Email)
                .Property(u => u.Address)
                .HasColumnName("Email")
                .HasColumnType("varchar(200)")
                .IsRequired(true);
        }
    }
}
