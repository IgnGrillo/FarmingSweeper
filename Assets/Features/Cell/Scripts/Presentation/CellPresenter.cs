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
        private readonly IPublishOnBlankSpacePressed _publishOnBlankSpacePressed;
        private readonly ICellView _view;

        public CellPresenter(IGetCellType getCellType,
                             IPublishOnBombPressed publishOnBombPressed,
                             IPublishOnBlankSpacePressed publishOnBlankSpacePressed,
                             ICellView view)
        {
            _getCellType = getCellType;
            _publishOnBombPressed = publishOnBombPressed;
            _publishOnBlankSpacePressed = publishOnBlankSpacePressed;
            _view = view;
        }

        public void Initialize() =>
                _view.OnPressed += OnViewPressed;

        private void OnViewPressed() =>
                _getCellType.Execute()
                            .Do(OnCellTypeObtained)
                            .Subscribe();

        private void OnCellTypeObtained(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.Bomb:
                    OnBombPressed();
                    break;
                case CellType.Blank:
                    OnBlankSpacePressed();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cellType), cellType, null);
            }
        }

        private void OnBlankSpacePressed()
        {
            _view.PlayOnBlankSpacePressedAnimation();
            _publishOnBlankSpacePressed.Execute();
        }

        private void OnBombPressed()
        {
            _view.PlayOnBombPressedAnimation();
            _publishOnBombPressed.Execute();
        }
    }
}