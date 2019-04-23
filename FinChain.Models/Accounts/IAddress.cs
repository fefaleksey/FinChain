namespace FinChain.Models.Accounts
{
    public interface IAddress
    {
        byte[] Data { get; }
        string ToString();
    }
}