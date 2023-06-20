using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using Features.Cell.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using static NSubstitute.Substitute;

namespace Features.Cell.Tests.Editor
{
    public class CellPresenterShould
    {
        private IPublishOnBombPressed _publishOnBombPressed;
        private IPublishOnBlankPressed _publishOnBlankPressed;
        private IUpdateCellSecondaryStatus _updateCellSecondaryStatus;
        private IPublishOnCellSecondaryStatusChange _publishOnCellSecondaryStatusChange;
        private IGetColorOfCell _getColorOfCell;
        private ICellView _view;
        private CellPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _publishOnBombPressed = For<IPublishOnBombPressed>();
            _publishOnBlankPressed = For<IPublishOnBlankPressed>();
            _publishOnCellSecondaryStatusChange = For<IPublishOnCellSecondaryStatusChange>();
            _updateCellSecondaryStatus = For<IUpdateCellSecondaryStatus>();
            _getColorOfCell = For<IGetColorOfCell>();
            _view = For<ICellView>();
            _presenter = new CellPresenter(
                    _publishOnBombPressed,
                    _publishOnBlankPressed,
                    _updateCellSecondaryStatus,
                    _publishOnCellSecondaryStatusChange,
                    _getColorOfCell,
                    _view);
        }

        [Test]
        public void SendOnBombPressedEventWhenABombWasPressed()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(true);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenViewIsPressed();
            ThenPublishOnBombPressedIsCalled();
        }

        [Test]
        public void PlayOnBombPressedAnimationWhenABombWasPressed()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(true);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenViewIsPressed();
            ThenPlayOnBombPressedAnimation();
        }

        [Test]
        public void SendOnBlankSpacePressedEventWhenABlankSpaceWasPressed()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(false);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenViewIsPressed();
            ThenPublishOnBlankSpacePressedIsCalled();
        }
        
        [Test]
        public void DisplayAmountOfBombsNearbyWhenABlankSpaceWasPressed()
        {
            var bombsNearby = 5;
            var colorObtained = Random.ColorHSV();
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(bombsNearby:bombsNearby);
            GivenAGetColorOfCellThatReturnsColorWith(bombsNearby, colorObtained);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenViewIsPressed();
            ThenDisplayAmountOfBombsWith(bombsNearby, colorObtained);
        }


        [Test]
        public void PlayOnBlankSpacePressedAnimationWhenABlankSpaceWasPressed()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(false);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenViewIsPressed();
            ThenPlayOnBlankSpacePressedAnimation();
        }

        [Test]
        public void PlayPlaceFlagAnimationWhenOnSecondaryPressedIsCalledAndCellHasNoFlag()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Blank);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenPlayPlaceFlagAnimation();
        }

        [Test]
        public void SetFlagStatusAsPlacedWhenOnSecondaryPressedIsCalledAndCellHasNoFlag()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Blank);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenUpdateSecondaryStatueTo(aMineSweeperCellWithBomb, CellSecondaryStatus.Flagged);
        }

        [Test]
        public void PublishOnCellSecondaryStatusChangeToFlaggedWhenOnSecondaryPressedIsCalledAndCellHasNoFlag()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Blank);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenPublishOnSecondaryStatusChangeTo(CellSecondaryStatus.Flagged);
        }

        [Test]
        public void PlayPlaceMysteryAnimationWhenOnSecondaryPressedIsCalledAndCellHasFlag()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Flagged);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenPlayPlaceMysteryAnimation();
        }

        [Test]
        public void SetFlagStatusAsMysteryWhenOnSecondaryPressedIsCalledAndCellHasFlag()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Flagged);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenUpdateSecondaryStatueTo(aMineSweeperCellWithBomb, CellSecondaryStatus.Mystery);
        }

        [Test]
        public void PublishOnCellSecondaryStatusChangeToMysteryWhenOnPlaceFlagIsCalledAndCellHasFlag()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Flagged);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenPublishOnSecondaryStatusChangeTo(CellSecondaryStatus.Mystery);
        }

        [Test]
        public void PlayPlayBlankAnimationWhenOnSecondaryPressedIsCalledAndCellHasMysterySign()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Mystery);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenPlayBlankAnimation();
        }

        [Test]
        public void SetFlagStatusAsBlankWhenOnSecondaryPressedIsCalledAndCellHasMysterySign()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Mystery);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenUpdateSecondaryStatueTo(aMineSweeperCellWithBomb, CellSecondaryStatus.Blank);
        }

        [Test]
        public void PublishOnCellSecondaryStatusChangeToBlankWhenOnPlaceFlagIsCalledAndCellHasMysterySign()
        {
            var aMineSweeperCellWithBomb = GivenAMineSweeperCellWith(secondaryStatus: CellSecondaryStatus.Mystery);
            GivenAPresenterInitialization(aMineSweeperCellWithBomb);
            WhenOnFlagged();
            ThenPublishOnSecondaryStatusChangeTo(CellSecondaryStatus.Blank);
        }

        private static MineSweeperCell GivenAMineSweeperCellWith(bool isBomb = false,
                                                                 CellSecondaryStatus secondaryStatus = CellSecondaryStatus.Blank,
                                                                 int bombsNearby = 0) => 
                new(isBomb, secondaryStatus, bombsNearby);

        private void GivenAPresenterInitialization(MineSweeperCell mineSweeperCell) =>
                _presenter.Initialize(mineSweeperCell);

        private void GivenAGetColorOfCellThatReturnsColorWith(int bombsNearby = 1, Color colorObtained = default) => 
                _getColorOfCell.Execute(bombsNearby).Returns(colorObtained);

        private void WhenViewIsPressed() =>
                _view.OnPressed.Invoke();

        private void WhenOnFlagged() =>
                _view.OnSecondaryPressed.Invoke();

        private void ThenPublishOnBombPressedIsCalled() =>
                _publishOnBombPressed.Received(1).Execute();

        private void ThenPlayOnBombPressedAnimation() =>
                _view.Received(1).PlayOnBombPressedAnimation();

        private void ThenPublishOnBlankSpacePressedIsCalled() =>
                _publishOnBlankPressed.Received(1).Execute();
        
        private void ThenDisplayAmountOfBombsWith(int bombsNearby, Color colorObtained) => 
                _view.DisplayAmountOfBombsNearby(bombsNearby, colorObtained);

        private void ThenPlayOnBlankSpacePressedAnimation() =>
                _view.Received(1).PlayOnBlankSpacePressedAnimation();

        private void ThenPlayPlaceFlagAnimation() =>
                _view.Received(1).PlayPlaceFlagAnimation();

        private void ThenUpdateSecondaryStatueTo(MineSweeperCell cell, CellSecondaryStatus secondaryStatus) =>
                _updateCellSecondaryStatus.Received(1).Execute(cell, secondaryStatus);

        private void ThenPublishOnSecondaryStatusChangeTo(CellSecondaryStatus secondaryStatus) =>
                _publishOnCellSecondaryStatusChange.Received(1).Execute(secondaryStatus);

        private void ThenPlayPlaceMysteryAnimation() =>
                _view.Received(1).PlayPlaceMysteryAnimation();
        
        private void ThenPlayBlankAnimation() =>
                _view.Received(1).PlayBlankAnimation();
    }
}