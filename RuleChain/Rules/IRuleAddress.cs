namespace RuleChain.Rules
{
    public interface IRuleAddress
    {
        byte[] Data { get; }
        string ToString();
    }
}