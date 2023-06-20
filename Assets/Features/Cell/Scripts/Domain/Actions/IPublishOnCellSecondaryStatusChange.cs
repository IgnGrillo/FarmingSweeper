namespace Features.Cell.Scripts.Domain.Actions
{
    public interface IPublishOnCellSecondaryStatusChange
    {
        void Execute(CellSecondaryStatus cellSecondaryStatus);
    }
}