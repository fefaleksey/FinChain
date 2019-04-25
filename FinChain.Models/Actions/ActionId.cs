using System;

namespace FinChain.Models.Actions
{
    public class ActionId : IEquatable<ActionId>
    {
        private Guid Id { get; }

        public ActionId()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(ActionId other) => Id.Equals(other.Id);
    }
}