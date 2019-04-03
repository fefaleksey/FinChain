namespace UserChain
{
    public interface IAddress
    {
//        byte[] ToByteArray();
        byte[] Data { get; }
        string ToString();
    }
}