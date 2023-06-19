using Features.Cell.Scripts.Presentation;

namespace Features.Cell.Scripts.Domain.Actions
{
    public interface ISetFlagStatus
    {
        void Execute(CellPresenter cellPresenter, FlagStatus status);
    }
}