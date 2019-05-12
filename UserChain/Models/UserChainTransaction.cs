using System;
using FinChain.Models;
using FinChain.Models.Accounts;
using UserChain.Models.Enums;

namespace UserChain.Models
{
    public class UserChainTransaction
    {
        public DateTime Time { get; }
        public UserChainTransactionType Type { get; }
        public TransactionStatus Status { get; set; }
        public Account Sender { get; }
        public Guid? ContractId { get; }
        public object[] Params { get; }
        public string Code { get; }

        private UserChainTransaction(Account sender, Guid? contractId, UserChainTransactionType type,
            string code, params object[] @params)
        {
            Sender = sender;
            ContractId = contractId;
            Type = type;
            Code = code;
            Params = @params;
            Time = DateTime.UtcNow;
            Status = TransactionStatus.Created;
        }

        public static UserChainTransaction CreateDeployTransaction(Account sender, Guid? contractId, string code)
        {
            return new UserChainTransaction(sender, contractId, UserChainTransactionType.Deploy, code, null);
        }

        public static UserChainTransaction CreateCallTransaction(Account sender, Guid? contractId,
            params object[] @params)
        {
            return new UserChainTransaction(sender, contractId, UserChainTransactionType.CallContractFunction,
                null, @params);
        }
    }
}