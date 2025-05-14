using System;
using System.Collections.Generic;

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
        public string Email { get; private set; }
        public List<Loan> Loans { get; set; } = [];
    }
}
