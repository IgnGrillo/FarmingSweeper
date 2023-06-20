using Features.Cell.Scripts.Domain.Actions;

namespace Features.Cell.Scripts.Providers
{
    public static class CellActionProvider
    {
        private static IPublishOnBombPressed _publishOnBombPressed;
        private static PublishOnBlankPressed _publishOnBlankPressed;
        private static UpdateCellSecondaryStatus _updateCellSecondaryStatus;
        private static PublishOnCellSecondaryStatusChange _publishOnCellSecondaryStatusChange;
        private static GetColorOfCell _getColorOfCell;

        public static IPublishOnBombPressed GetPublishOnBombPressed() =>
                _publishOnBombPressed ??= new PublishOnBombPressed();
        
        public static IPublishOnBlankPressed GetPublishOnBlankPressed() =>
                _publishOnBlankPressed ??= new PublishOnBlankPressed();
        
        public static IUpdateCellSecondaryStatus GetUpdateCellSecondaryStatus() =>
                _updateCellSecondaryStatus ??= new UpdateCellSecondaryStatus();
        
        public static IPublishOnCellSecondaryStatusChange GetPublishOnCellSecondaryStatusChange() =>
                _publishOnCellSecondaryStatusChange ??= new PublishOnCellSecondaryStatusChange();
        
        public static IGetColorOfCell GetGetColorOfCell(CellDisplayColorByBombsNearby displayColorByBombsNearby) =>
                        _getColorOfCell ??= new GetColorOfCell(displayColorByBombsNearby);
    }
}