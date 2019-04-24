using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;

namespace UserChain.Transactions
{
    public interface ITransaction
    {
        
        DateTime Time { get; }

        TransactionStatus Status { get; }
        List<AccountType> GovernBy { get; }    //TODO: qn: enum or something else?
        Account Sender { get; }
        Account Receiver { get; }

        TransactionType Type();
    }
}