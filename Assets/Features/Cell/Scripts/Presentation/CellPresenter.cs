using System;
using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using Features.Cell.Tests.Editor;
using UniRx;

namespace Features.Cell.Scripts.Presentation
{
    public class CellPresenter
    {
        private readonly IGetCellType _getCellType;
        private readonly IPublishOnBombPressed _publishOnBombPressed;
        private readonly ICellView _view;

        public CellPresenter(IGetCellType getCellType,
                             IPublishOnBombPressed publishOnBombPressed,
                             ICellView view)
        {
            _getCellType = getCellType;
            _publishOnBombPressed = publishOnBombPressed;
            _view = view;
        }

        public void Initialize()
        {
            _view.OnPressed += OnViewPressed;
        }

        private void OnViewPressed()
        {
            _getCellType.Execute()
                        .Where(x => x == CellType.Bomb)
                        .Do(OnBombPressed)
                        .Subscribe();
        }

        private void OnBombPressed(CellType _)
        {
            _view.PlayOnBombPressedAnimation();
            _publishOnBombPressed.Execute();
        }
    }
}