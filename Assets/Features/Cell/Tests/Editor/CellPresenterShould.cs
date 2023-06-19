using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using Features.Cell.Scripts.Domain.Events;
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
        private ICellView _view;
        private CellPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _getCellType = For<IGetCellType>();
            _publishOnBombPressed = For<IPublishOnBombPressed>();
            _publishOnBlankSpacePressed = For<IPublishOnBlankSpacePressed>();
            _view = For<ICellView>();
            _presenter = new CellPresenter(_getCellType,
                    _publishOnBombPressed,
                    _publishOnBlankSpacePressed,
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

        private void GivenAPresenterInitialization() =>
                _presenter.Initialize();

        private void GivenAGetCellTypeThatReturns(CellType cellType) =>
                _getCellType.Execute().Returns(Observable.Return(cellType));

        private void WhenViewIsPressed() =>
                _view.OnPressed.Invoke();

        private void ThenGetCellTypeIsCalled() =>
                _getCellType.Received(1).Execute();

        private void ThenPublishOnBombPressedIsCalled() =>
                _publishOnBombPressed.Received(1).Execute();

        private void ThenPlayOnBombPressedAnimation() =>
                _view.Received(1).PlayOnBombPressedAnimation();

        private void ThenPublishOnBlankSpacePressedIsCalled() =>
                _publishOnBlankSpacePressed.Received(1).Execute();
    }
}