using System;

namespace FinChain.Models.Actions
{
    public class RequirementId : IEquatable<RequirementId>
    {
        private Guid Id { get; }

        public RequirementId()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(RequirementId other) => Id.Equals(other.Id);
    }
}