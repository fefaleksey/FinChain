namespace FinChain.Models.Accounts
{
    public class Account
    {
        public AccountAddress AccountAddress { get; }
        public AccountType Type { get; }
        public int Balance { get; set; }

        public Account(AccountType type)
        {
            AccountAddress = new AccountAddress();
            Type = type;
            Balance = 0;
        }
    }
}