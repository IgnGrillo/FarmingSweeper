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
            _view = For<ICellView>();
            _presenter = new CellPresenter(_getCellType,
                    _publishOnBombPressed,
                    _publishOnBlankSpacePressed,
                    _getFlagStatus,
                    _setFlagStatus,
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
            GivenAGetFlagStatueThatReturns(FlagStatus.NotPlaced);
            GivenAPresenterInitialization();
            WhenOnFlagged();
            ThenSetFlagStatusWith(FlagStatus.Placed);
        }

        [Test]
        public void PlayPlaceFlagAnimationWhenOnPlaceFlagIsCalledAndCellHasNoFlag()
        {
            GivenAGetFlagStatueThatReturns(FlagStatus.NotPlaced);
            GivenAPresenterInitialization();
            WhenOnFlagged();
            ThenPlayFaceFlagAnimation();
        }

        private void GivenAPresenterInitialization() =>
                _presenter.Initialize();

        private void GivenAGetCellTypeThatReturns(CellType cellType) =>
                _getCellType.Execute().Returns(Observable.Return(cellType));

        private void GivenAGetFlagStatueThatReturns(FlagStatus flagStatus) => 
                _getFlagStatus.Execute().Returns(Observable.Return(flagStatus));

        private void WhenViewIsPressed() =>
                _view.OnPressed.Invoke();

        private void WhenOnFlagged() => 
                _view.OnFlagged.Invoke();

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

        private void ThenPlayFaceFlagAnimation() => 
                _view.Received(1).PlayPlaceFlagAnimation();
    }
}