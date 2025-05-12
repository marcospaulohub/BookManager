using System;

namespace BookManager.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public void SetAsUpdated()
        {
            UpdatedAt = DateTime.Now;
        }

        public void SetAsDeleted()
        {
            DeletedAt = DateTime.Now;
        }
    }
}
