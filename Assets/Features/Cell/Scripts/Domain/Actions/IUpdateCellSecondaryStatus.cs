using Features.Cell.Scripts.Domain;

namespace Features.Cell.Tests.Editor
{
    public interface IUpdateCellSecondaryStatus
    {
        void Execute(MineSweeperCell cell, CellSecondaryStatus cellSecondaryStatus);
    }
}