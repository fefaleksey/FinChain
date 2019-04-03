namespace UserChain.Accounts
{
    public interface IAccount
    {
        IAddress Address { get; }
        string Alias { get; }
        AccountType Type { get; }
    }
}