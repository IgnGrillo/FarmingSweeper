using Features.Cell.Scripts.Domain.Actions;
using Features.Cell.Scripts.Domain.Events;
using NUnit.Framework;

namespace Features.Cell.Tests.Editor
{
    public class PublishOnBlankPressedShould
    {
        private bool _eventBusSubscriptionFlag;

        [Test]
        public void PublishOnBlankPressedWhenExecute()
        {
            var publishOnBlankPressed = GivenAnAction();
            GivenAClearEventBus();
            GivenAnOnBlankSpacePressedEventBusSubscription();
            WhenExecute(publishOnBlankPressed);
            ThenEventSubscribedWasCalled();
        }

        private static PublishOnBlankPressed GivenAnAction() => 
                new();

        private static void GivenAClearEventBus() =>
                        EventBus.Clear();

        private void GivenAnOnBlankSpacePressedEventBusSubscription() =>
                EventBus.Subscribe<OnBlankSpacePressed>(_ => _eventBusSubscriptionFlag = true);

        private static void WhenExecute(IPublishOnBlankPressed publishOnBlankPressed) =>
                publishOnBlankPressed.Execute();

        private void ThenEventSubscribedWasCalled() =>
                Assert.IsTrue(_eventBusSubscriptionFlag);
    }
}