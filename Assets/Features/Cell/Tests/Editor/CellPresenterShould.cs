using System;
using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using Features.Cell.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;
using UniRx;
using static NSubstitute.Substitute;

namespace Features.Cell.Tests.Editor
{
    public class CellPresenterShould
    {
        private IGetCellType _getCellType;
        private IPublishOnBombPressed _publishOnBombPressed;
        private IPublishOnBlankSpacePressed _publishOnBlankSpacePressed;
        private IGetFlagStatus _getFlagStatus;
        private ISetFlagStatus _setFlagStatus;
        private IGetAmountOfBombsNearby _getAmountOfBombsNearby;
        private ICellView _view;
        private CellPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _getCellType = For<IGetCellType>();
            _publishOnBombPressed = For<IPublishOnBombPressed>();
            _publishOnBlankSpacePressed = For<IPublishOnBlankSpacePressed>();
            _getFlagStatus = For<IGetFlagStatus>();
            _setFlagStatus = For<ISetFlagStatus>();
            _getAmountOfBombsNearby = For<IGetAmountOfBombsNearby>();
            _view = For<ICellView>();
            _presenter = new CellPresenter(_getCellType,
                    _publishOnBombPressed,
                    _publishOnBlankSpacePressed,
                    _getFlagStatus,
                    _setFlagStatus,
                    _getAmountOfBombsNearby,
                    _view);
        }

        [Test]
        public void GetCellTypeWhenPressed()
        {
            GivenAPresenterInitialization();
            WhenViewIsPressed();
            ThenGetCellTypeIsCalled();
        }

        [Test]
        public void SendOnBombPressedEventWhenABombWasPressed()
        {
            GivenAGetCellTypeThatReturns(CellType.Bomb);
            GivenAPresenterInitialization();
            WhenViewIsPressed();
            ThenPublishOnBombPressedIsCalled();
        }

        [Test]
        public void PlayOnBombPressedAnimationWhenABombWasPressed()
        {
            GivenAGetCellTypeThatReturns(CellType.Bomb);
            GivenAPresenterInitialization();
            WhenViewIsPressed();
            ThenPlayOnBombPressedAnimation();
        }

        [Test]
        public void SendOnBlankSpacePressedEventWhenABlankSpaceWasPressed()
        {
            GivenAGetCellTypeThatReturns(CellType.Blank);
            GivenAPresenterInitialization();
            WhenViewIsPressed();
            ThenPublishOnBlankSpacePressedIsCalled();
        }
        
        [Test]
        public void PlayOnBlankSpacePressedAnimationWhenABlankSpaceWasPressed()
        {
            GivenAGetCellTypeThatReturns(CellType.Blank);
            GivenAPresenterInitialization();
            WhenViewIsPressed();
            ThenPlayOnBlankSpacePressedAnimation();
        }

        [Test]
        public void SetFlagStatusAsPlacedWhenOnPlaceFlagIsCalledAndCellHasNoFlag()
        {
            GivenAGetFlagStatueThatReturns(FlagStatus.Removed);
            GivenAPresenterInitialization();
            WhenOnFlagged();
            ThenSetFlagStatusWith(FlagStatus.Placed);
        }

        [Test]
        public void PlayPlaceFlagAnimationWhenOnPlaceFlagIsCalledAndCellHasNoFlag()
        {
            GivenAGetFlagStatueThatReturns(FlagStatus.Removed);
            GivenAPresenterInitialization();
            WhenOnFlagged();
            ThenPlayPlaceFlagAnimation();
        }
        
        [Test]
        public void SetFlagStatusAsNotPlacedWhenOnPlaceFlagIsCalledAndCellHasFlagPlaced()
        {
            GivenAGetFlagStatueThatReturns(FlagStatus.Placed);
            GivenAPresenterInitialization();
            WhenOnFlagged();
            ThenSetFlagStatusWith(FlagStatus.Removed);
        }
        
        [Test]
        public void PlayRemoveFlagAnimationWhenOnPlaceFlagIsCalledAndCellHasFlag()
        {
            GivenAGetFlagStatueThatReturns(FlagStatus.Placed);
            GivenAPresenterInitialization();
            WhenOnFlagged();
            ThenPlayRemoveFlagAnimation();
        }

        [Test]
        public void GetAmountOfBombsNearbyIsCalledWhenPresenterIsInitialized()
        {
            WhenInitialized();
            ThenGetAmountOfBombsIsCalled();
        }
        
        [Test]
        public void DisplayAmountOfBombsNearbyWhenPresenterIsInitialized()
        {
            var initialAmountOfBombs = new Random().Next(0, 100);
            GivenAGetAmountOfBombsThatReturn(initialAmountOfBombs);
            WhenInitialized();
            ThenDisplayAmountOfBombsIsCalledWith(initialAmountOfBombs);
        }

        private void GivenAPresenterInitialization() =>
                _presenter.Initialize();

        private void GivenAGetCellTypeThatReturns(CellType cellType) =>
                _getCellType.Execute().Returns(Observable.Return(cellType));

        private void GivenAGetFlagStatueThatReturns(FlagStatus flagStatus) => 
                _getFlagStatus.Execute().Returns(Observable.Return(flagStatus));

        private void GivenAGetAmountOfBombsThatReturn(int initialAmountOfBombs) => 
                _getAmountOfBombsNearby.Execute().Returns(Observable.Return(initialAmountOfBombs));

        private void WhenViewIsPressed() =>
                _view.OnPressed.Invoke();

        private void WhenOnFlagged() => 
                _view.OnFlagged.Invoke();

        private void WhenInitialized() => 
                _presenter.Initialize();

        private void ThenGetCellTypeIsCalled() =>
                _getCellType.Received(1).Execute();

        private void ThenPublishOnBombPressedIsCalled() =>
                _publishOnBombPressed.Received(1).Execute();

        private void ThenPlayOnBombPressedAnimation() =>
                _view.Received(1).PlayOnBombPressedAnimation();

        private void ThenPublishOnBlankSpacePressedIsCalled() =>
                _publishOnBlankSpacePressed.Received(1).Execute();

        private void ThenPlayOnBlankSpacePressedAnimation() =>
                _view.Received(1).PlayOnBlankSpacePressedAnimation();

        private void ThenSetFlagStatusWith(FlagStatus flagStatus) => 
                _setFlagStatus.Received(1).Execute(_presenter, flagStatus);

        private void ThenPlayPlaceFlagAnimation() => 
                _view.Received(1).PlayPlaceFlagAnimation();

        private void ThenPlayRemoveFlagAnimation() => 
                _view.Received(1).PlayRemoveFlagAnimation();

        private void ThenGetAmountOfBombsIsCalled() => 
                _getAmountOfBombsNearby.Received(1).Execute();

        private void ThenDisplayAmountOfBombsIsCalledWith(int initialAmountOfBombs) => 
                _view.Received(1).DisplayAmountOfBombsNearby(initialAmountOfBombs);
    }
}