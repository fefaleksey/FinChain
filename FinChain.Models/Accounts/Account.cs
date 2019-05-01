namespace FinChain.Models.Accounts
{
    public class Account
    {
        public Address AccountAddress { get; }
        public AccountType Type { get; }
        public int Balance { get; set; }

        public Account(AccountType type)
        {
            AccountAddress = new Address();
            Type = type;
            Balance = 0;
        }
    }
}