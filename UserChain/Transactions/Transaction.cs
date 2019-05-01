using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;

namespace UserChain.Transactions
{
    public class Transaction
    {
        public DateTime Time { get; }
        public TransactionStatus Status { get; }
        public Account Sender { get; }
        public object[] Params { get; }
        
        public ActionId ContractToCall { get; }
        
        public Transaction(Account sender, ActionId contractToCall, params object[] @params)
        {
            Sender = sender;
            ContractToCall = contractToCall;
            Params = @params;
            Time = DateTime.UtcNow;
            Status = TransactionStatus.Created;
        }        
    }
}