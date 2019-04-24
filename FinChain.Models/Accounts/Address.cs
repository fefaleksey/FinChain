using System;

namespace FinChain.Models.Accounts
{
    public sealed class Address : IEquatable<Address>
    {
        private readonly Guid _address;
        public override string ToString() => _address.ToString();

        public Address()
        {
            _address = Guid.NewGuid();
        }

        public bool Equals(Address other) => _address.Equals(other._address);

        public override int GetHashCode()
        {
            return _address.GetHashCode();
        }
    }
}
