using System;

namespace BookManager.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

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
