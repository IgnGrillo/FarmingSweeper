using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;
using static NSubstitute.Substitute;

namespace Features.Cell.Tests.Editor
{
    public class CellPresenterShould
    {
        private ICellView _view;
        private IGetCellType _getCellType;
        private CellPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _getCellType = For<IGetCellType>();
            _view = For<ICellView>();
            _presenter = new CellPresenter(_getCellType, _view);
        }
        
        [Test]
        public void GetCellTypeWhenPressed()
        {
            GivenAPresenterInitialization();
            WhenViewIsPressed();
            ThenGetCellTypeIsCalled();
        }

        private void GivenAPresenterInitialization() => 
                _presenter.Initialize();

        private void WhenViewIsPressed() => 
                _view.OnPressed.Invoke();

        private void ThenGetCellTypeIsCalled() => 
                _getCellType.Received(1).Execute();
    }
}