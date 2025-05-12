using System;

namespace BookManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email) : base()
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public String Email { get; private set; }
    }
}
