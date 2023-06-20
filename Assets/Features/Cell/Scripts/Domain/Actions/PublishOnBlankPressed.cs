using Features.Cell.Scripts.Domain.Events;
using UnityEngine;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class PublishOnBlankPressed : IPublishOnBlankPressed
    {
        public void Execute()
        {
            Debug.Log("PublishOnBlankPressed");
            EventBus.Publish(new OnBlankSpacePressed());
        }
    }
}