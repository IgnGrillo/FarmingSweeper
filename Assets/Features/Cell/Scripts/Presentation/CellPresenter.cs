using Features.Cell.Scripts.Domain;
using Features.Cell.Tests.Editor;
using UniRx;

namespace Features.Cell.Scripts.Presentation
{
    public class CellPresenter
    {
        private readonly IGetCellType _getCellType;
        private readonly ICellView _view;

        public CellPresenter(IGetCellType getCellType, ICellView view)
        {
            _getCellType = getCellType;
            _view = view;
        }

        public void Initialize()
        {
            _view.OnPressed += OnViewPressed;
        }

        private void OnViewPressed()
        {
            _getCellType.Execute()
                        .Subscribe();
        }
    }
}