using BookManager.Core.Enums;

namespace BookManager.Core.Entities
{
    public class Copy : BaseEntity
    {
        public string? Barcode { get; set; }
        public CopyCondition Condition { get; set; }
        public string? Location { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}
