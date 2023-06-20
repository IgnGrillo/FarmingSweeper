using Features.Cell.Scripts.Domain.Events;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class PublishOnBlankPressed : IPublishOnBlankPressed
    {
        public void Execute()
        {
            EventBus.Publish(new OnBlankSpacePressed());
        }
    }
}