namespace RuleChain.Rules
{
    public sealed class RuleAddress : IRuleAddress
    {
        public override string ToString() => System.Text.Encoding.UTF8.GetString(Data);

        public RuleAddress(byte[] address)
        {
            this.Data = address;
        }

        public byte[] Data { get; }
    }
}