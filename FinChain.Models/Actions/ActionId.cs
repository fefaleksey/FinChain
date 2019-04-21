using System;

namespace Actions
{
    public class ActionId : IEquatable<ActionId>
    {
        public Guid Id { get; }

        public ActionId()
        {
            Id = new Guid();
        }

        public bool Equals(ActionId other) => Id.Equals(other.Id);
    }
}