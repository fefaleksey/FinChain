namespace UserChain.Accounts
{
    public class Account : IAccount
    {
        public IAddress Address { get; }
        public string Alias { get; }
        public AccountType Type { get; }

        public Account(IAddress address, string @alias, AccountType type)
        {
            Address = address;
            Alias = alias;
            Type = type;
        }
    }
}