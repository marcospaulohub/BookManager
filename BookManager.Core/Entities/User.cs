using BookManager.Core.ValueObjects;
using System.Collections.Generic;

namespace BookManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User() : base() { }

        public User(string name, Email email) : base()
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public List<Loan> Loans { get; set; } = [];
    }
}
