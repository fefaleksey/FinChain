namespace UserChain.Accounts
{
    public interface IAddress
    {
        byte[] Data { get; }
        string ToString();
    }
}