namespace RuleChain.Rules
{
    class RuleId : IRuleId
    {
        public IRuleAddress RuleAddress { get; }
        public string Alias { get; }

        public RuleId(string @alias)
        {
            var testAddress = new byte[] {1};
            RuleAddress = new RuleAddress(testAddress);
            Alias = alias;
            // TODO: initialize RuleAddress
        }
    }
}