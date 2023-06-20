using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using Features.Cell.Scripts.Domain.Events;
using NUnit.Framework;

namespace Features.Cell.Tests.Editor
{
    public class PublishOnCellSecondaryStatusChangeShould
    {
        private CellSecondaryStatus _eventBusSubscriptionValue = CellSecondaryStatus.Null;

        [TestCase(CellSecondaryStatus.Blank)]
        [TestCase(CellSecondaryStatus.Flagged)]
        [TestCase(CellSecondaryStatus.Mystery)]
        public void PublishOnBombPressedWithCorrectStatusWhenExecute(CellSecondaryStatus cellSecondaryStatus)
        {
            var publishOnBombPressed = GivenAnAction();
            GivenAClearEventBus();
            GivenAnOnSecondaryActionEventBusSubscription();
            WhenExecute(publishOnBombPressed, cellSecondaryStatus);
            ThenEventSubscribedWasCalled(cellSecondaryStatus);
        }

        private static PublishOnCellSecondaryStatusChange GivenAnAction() =>
                new();

        private static void GivenAClearEventBus() =>
                EventBus.Clear();

        private void GivenAnOnSecondaryActionEventBusSubscription() =>
                EventBus.Subscribe<OnSecondaryAction>(secondaryAction =>
                        _eventBusSubscriptionValue = secondaryAction.CellSecondaryStatusChangedTo);

        private static void WhenExecute(IPublishOnCellSecondaryStatusChange action,
                                        CellSecondaryStatus cellSecondaryStatus) =>
                action.Execute(cellSecondaryStatus);

        private void ThenEventSubscribedWasCalled(CellSecondaryStatus expected) =>
                Assert.AreEqual(expected, _eventBusSubscriptionValue);
    }
}