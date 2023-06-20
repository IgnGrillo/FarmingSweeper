using Features.Cell.Scripts.Domain.Events;
using UnityEngine;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class PublishOnCellSecondaryStatusChange : IPublishOnCellSecondaryStatusChange
    {
        public void Execute(CellSecondaryStatus cellSecondaryStatus)
        {
            Debug.Log("PublishOnCellSecondaryStatusChange");
            EventBus.Publish(new OnSecondaryAction(cellSecondaryStatus));
        }
    }
}