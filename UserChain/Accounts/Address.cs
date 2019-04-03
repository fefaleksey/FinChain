namespace UserChain.Accounts
{
    public sealed class Address : IAddress
    {
//        public byte[] ToByteArray() => _address;

        public override string ToString() => System.Text.Encoding.UTF8.GetString(Data);

        public Address(byte[] address)
        {
            this.Data = address;
        }

        public byte[] Data { get; }
    }
}
