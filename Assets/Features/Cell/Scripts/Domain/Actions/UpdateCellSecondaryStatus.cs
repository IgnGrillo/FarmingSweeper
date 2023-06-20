using Features.Cell.Scripts.Domain;

namespace Features.Cell.Tests.Editor
{
    public class UpdateCellSecondaryStatus : IUpdateCellSecondaryStatus
    {
        public void Execute(MineSweeperCell cell, CellSecondaryStatus cellSecondaryStatus)
        {
            cell.SecondaryStatus = cellSecondaryStatus;
        }
    }
}