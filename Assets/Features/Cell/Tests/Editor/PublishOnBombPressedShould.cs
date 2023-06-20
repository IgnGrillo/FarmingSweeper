using Features.Cell.Scripts.Domain.Actions;
using Features.Cell.Scripts.Domain.Events;
using NUnit.Framework;

namespace Features.Cell.Tests.Editor
{
    public class PublishOnBombPressedShould
    {
        private bool _eventBusSubscriptionFlag;

        [Test]
        public void PublishOnBombPressedWhenExecute()
        {
            var publishOnBombPressed = GivenAnAction();
            GivenAClearEventBus();
            GivenAnOnBombPressedEventBusSubscription();
            WhenExecute(publishOnBombPressed);
            ThenEventSubscribedWasCalled();
        }

        private static PublishOnBombPressed GivenAnAction() =>
                new();

        private static void GivenAClearEventBus() =>
                EventBus.Clear();

        private void GivenAnOnBombPressedEventBusSubscription() =>
                EventBus.Subscribe<OnBombPressed>(_ => _eventBusSubscriptionFlag = true);

        private static void WhenExecute(IPublishOnBombPressed publishOnBombPressed) =>
                publishOnBombPressed.Execute();

        private void ThenEventSubscribedWasCalled() =>
                Assert.IsTrue(_eventBusSubscriptionFlag);
    }
}