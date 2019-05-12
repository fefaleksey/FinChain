using System;

namespace FinChain.Models.Accounts
{
    public sealed class AccountAddress : IEquatable<AccountAddress>
    {
        private readonly Guid _address;
        public override string ToString() => _address.ToString();

        public AccountAddress()
        {
            _address = Guid.NewGuid();
        }

        public bool Equals(AccountAddress other) => _address.Equals(other._address);

        public override int GetHashCode()
        {
            return _address.GetHashCode();
        }
    }
}
