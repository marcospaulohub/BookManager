using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infra.Persistence.Mappings
{
    public class LoanMap : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .ToTable("Loan");

            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.UserId)
                .IsRequired();

            builder
                .Property(l => l.BookId)
                .IsRequired();

            builder
                .Property(l => l.LoanDate)
                .IsRequired();

            builder
                .Property(l => l.ReturnDate)
                .IsRequired();

            builder
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.User.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.User.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
