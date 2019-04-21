using System;

namespace UserChain.Accounts
{
    public class Account : IAccount
    {
        public Guid Address { get; }
        public string Alias { get; }
        public AccountType Type { get; }
        public uint Balance { get; set; }

        public Account(IAddress address, string @alias, AccountType type)
        {
            Address = Guid.NewGuid();
            Alias = alias;
            Type = type;
            Balance = 0;
        }
    }
}