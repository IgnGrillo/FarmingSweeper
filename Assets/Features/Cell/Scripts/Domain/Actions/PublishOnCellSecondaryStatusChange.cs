using Features.Cell.Scripts.Domain.Events;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class PublishOnCellSecondaryStatusChange : IPublishOnCellSecondaryStatusChange
    {
        public void Execute(CellSecondaryStatus cellSecondaryStatus)
        {
            EventBus.Publish(new OnSecondaryAction(cellSecondaryStatus));
        }
    }
}