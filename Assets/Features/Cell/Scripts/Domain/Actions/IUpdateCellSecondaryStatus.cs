namespace Features.Cell.Scripts.Domain.Actions
{
    public interface IUpdateCellSecondaryStatus
    {
        void Execute(MineSweeperCell cell, CellSecondaryStatus cellSecondaryStatus);
    }
}