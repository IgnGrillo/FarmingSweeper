using System;
using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using UniRx;

namespace Features.Cell.Scripts.Presentation
{
    public class CellPresenter
    {
        private readonly IPublishOnBombPressed _publishOnBombPressed;
        private readonly IPublishOnBlankPressed _publishOnBlankPressed;
        private readonly IUpdateCellSecondaryStatus _onCellSecondaryStatusChange;
        private readonly IPublishOnCellSecondaryStatusChange _publishOnCellSecondaryStatusChange;
        private readonly IGetColorOfCell _getColorOfCell;
        private readonly ICellView _view;

        public CellPresenter(IPublishOnBombPressed publishOnBombPressed,
                             IPublishOnBlankPressed publishOnBlankPressed,
                             IUpdateCellSecondaryStatus onCellSecondaryStatusChange,
                             IPublishOnCellSecondaryStatusChange publishOnCellSecondaryStatusChange,
                             IGetColorOfCell getColorOfCell,
                             ICellView view)
        {
            _publishOnBombPressed = publishOnBombPressed;
            _publishOnBlankPressed = publishOnBlankPressed;
            _onCellSecondaryStatusChange = onCellSecondaryStatusChange;
            _publishOnCellSecondaryStatusChange = publishOnCellSecondaryStatusChange;
            _getColorOfCell = getColorOfCell;
            _view = view;
        }

        public void Initialize(MineSweeperCell cell)
        {
            _view.OnPressed += () => OnViewPressed(cell);
            _view.OnSecondaryPressed += () => OnViewSecondaryPressed(cell);
        }

        private void OnViewPressed(MineSweeperCell cell) => Observable.Return(cell)
                                                                      .Do(OnPressed)
                                                                      .Subscribe();

        private void OnViewSecondaryPressed(MineSweeperCell cell) => Observable.Return(cell)
                                                                      .Do(OnSecondaryPressed)
                                                                      .Subscribe();

        private void OnPressed(MineSweeperCell mineSweeperCell)
        {
            if (mineSweeperCell.IsBomb) OnBombPressed();
            else OnBlankSpacePressed(mineSweeperCell);
        }

        private void OnBombPressed()
        {
            _view.PlayOnBombPressedAnimation();
            _publishOnBombPressed.Execute();
        }

        private void OnBlankSpacePressed(MineSweeperCell mineSweeperCell)
        {
            _view.PlayOnBlankSpacePressedAnimation();
            _view.DisplayAmountOfBombsNearby(mineSweeperCell.BombsNearby,
                    _getColorOfCell.Execute(mineSweeperCell.BombsNearby));
            _publishOnBlankPressed.Execute();
        }

        private void OnSecondaryPressed(MineSweeperCell mineSweeperCell)
        {
            var cellSecondaryStatus = mineSweeperCell.SecondaryStatus;
            if (cellSecondaryStatus == CellSecondaryStatus.Blank)
                MoveFromBlankToFlagged(mineSweeperCell);
            else if (cellSecondaryStatus == CellSecondaryStatus.Flagged)
                MoveFromFlaggedToMystery(mineSweeperCell);
            else if (cellSecondaryStatus == CellSecondaryStatus.Mystery)
                MoveFromMysteryToBlank(mineSweeperCell);
            else
                throw new ArgumentOutOfRangeException(nameof(cellSecondaryStatus), cellSecondaryStatus, null);
        }

        private void MoveFromBlankToFlagged(MineSweeperCell mineSweeperCell)
        {
            _view.PlayPlaceFlagAnimation();
            _onCellSecondaryStatusChange.Execute(mineSweeperCell, CellSecondaryStatus.Flagged);
            _publishOnCellSecondaryStatusChange.Execute(CellSecondaryStatus.Flagged);
        }

        private void MoveFromFlaggedToMystery(MineSweeperCell mineSweeperCell)
        {
            _view.PlayPlaceMysteryAnimation();
            _onCellSecondaryStatusChange.Execute(mineSweeperCell, CellSecondaryStatus.Mystery);
            _publishOnCellSecondaryStatusChange.Execute(CellSecondaryStatus.Mystery);
        }

        private void MoveFromMysteryToBlank(MineSweeperCell mineSweeperCell)
        {
            _view.PlayBlankAnimation();
            _onCellSecondaryStatusChange.Execute(mineSweeperCell, CellSecondaryStatus.Blank);
            _publishOnCellSecondaryStatusChange.Execute(CellSecondaryStatus.Blank);
        }
    }
}