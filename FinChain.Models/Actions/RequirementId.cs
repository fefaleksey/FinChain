using System;

namespace FinChain.Models.Actions
{
    public class RequirementId : IEquatable<ActionId>
    {
        public Guid Id { get; }

        public RequirementId()
        {
            Id = new Guid();
        }

        public bool Equals(ActionId other) => Id.Equals(other.Id);
    }
}