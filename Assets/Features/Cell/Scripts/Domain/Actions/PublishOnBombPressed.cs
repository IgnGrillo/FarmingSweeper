using Features.Cell.Scripts.Domain.Events;
using UnityEngine;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class PublishOnBombPressed : IPublishOnBombPressed
    {
        public void Execute()
        {
            Debug.Log("PublishOnBombPressed");
            EventBus.Publish(new OnBombPressed());
        }
    }
}