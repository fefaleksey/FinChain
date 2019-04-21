namespace Actions
{
    public interface IAction
    {
        ActionId RequirementsId { get; }

        bool IsActive { get; }

        void Execute(params object[] list);
    }
}