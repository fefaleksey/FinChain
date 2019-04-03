namespace RuleChain.Rules
{
    public interface IRuleId
    {
        IRuleAddress RuleAddress { get; }
        string Alias { get; }
    }
}