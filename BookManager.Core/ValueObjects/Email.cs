using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookManager.Core.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; }

        // Regex básica para validação de e-mail
        private static readonly Regex EmailRegex =
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("E-mail não pode ser vazio.", nameof(address));

            if (!EmailRegex.IsMatch(address))
                throw new ArgumentException("Formato de e-mail inválido.", nameof(address));

            Address = address.Trim().ToLowerInvariant(); // Normalização
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Address;
        }

        public override string ToString() => Address;
    }
}
