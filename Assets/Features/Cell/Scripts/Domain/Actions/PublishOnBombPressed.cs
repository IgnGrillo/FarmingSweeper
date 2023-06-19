using Features.Cell.Scripts.Domain.Events;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class PublishOnBombPressed : IPublishOnBombPressed
    {
        public void Execute()
        {
            EventBus.Publish(new OnBombPressed());
        }
    }
}