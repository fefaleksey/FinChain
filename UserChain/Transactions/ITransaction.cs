using System;
using System.Collections.Generic;

namespace RuleChain.Transactions
{
    public interface ITransaction
    {
        
        DateTime Time { get; }

        TransactionStatus Status { get; }
        List<UserType> GovernBy { get; }    //TODO: qn: enum or something else?
        IAddress Sender { get; }
        IAddress Receiver { get; }

        TransactionType Type();
    }
}