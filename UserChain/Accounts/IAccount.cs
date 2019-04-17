using System;

namespace UserChain.Accounts
{
    public interface IAccount
    {
        Guid Address { get; }
        string Alias { get; }
        AccountType Type { get; }
        uint Balance { get; set; }
    }
}