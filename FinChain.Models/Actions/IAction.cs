namespace FinChain.Models.Actions
{
    public interface IAction
    {
        ActionId Id { get; }
        RequirementId RequirementsId { get; }

        bool IsActive { get; }

        void Execute(params object[] list);
    }
}