namespace RuleChain.Rules
{
    class RuleId : IRuleId
    {
        public IRuleAddress RuleAddress { get; }
        public string Alias { get; }

        public RuleId(string @alias)
        {
            Alias = alias;
            // TODO: initialize RuleAddress
        }
    }
}