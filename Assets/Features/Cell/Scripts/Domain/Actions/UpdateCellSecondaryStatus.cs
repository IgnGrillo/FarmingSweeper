namespace Features.Cell.Scripts.Domain.Actions
{
    public class UpdateCellSecondaryStatus : IUpdateCellSecondaryStatus
    {
        public void Execute(MineSweeperCell cell, CellSecondaryStatus cellSecondaryStatus)
        {
            cell.SecondaryStatus = cellSecondaryStatus;
        }
    }
}