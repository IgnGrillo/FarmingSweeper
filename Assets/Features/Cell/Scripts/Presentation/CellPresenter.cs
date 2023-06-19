using System;
using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using UniRx;

namespace Features.Cell.Scripts.Presentation
{
    public class CellPresenter
    {
        private readonly IGetCellType _getCellType;
        private readonly IPublishOnBombPressed _publishOnBombPressed;
        private readonly IPublishOnBlankSpacePressed _publishOnBlankSpacePressed;
        private readonly IGetFlagStatus _getFlagStatus;
        private readonly ISetFlagStatus _setFlagStatus;
        private readonly ICellView _view;

        public CellPresenter(IGetCellType getCellType,
                             IPublishOnBombPressed publishOnBombPressed,
                             IPublishOnBlankSpacePressed publishOnBlankSpacePressed,
                             IGetFlagStatus getFlagStatus,
                             ISetFlagStatus setFlagStatus,
                             ICellView view)
        {
            _getCellType = getCellType;
            _publishOnBombPressed = publishOnBombPressed;
            _publishOnBlankSpacePressed = publishOnBlankSpacePressed;
            _getFlagStatus = getFlagStatus;
            _setFlagStatus = setFlagStatus;
            _view = view;
        }

        public void Initialize()
        {
            _view.OnPressed += OnViewPressed;
            _view.OnFlagged += OnViewFlagged;
        }

        private void OnViewPressed() =>
                _getCellType.Execute()
                            .Do(OnCellTypeObtained)
                            .Subscribe();

        private void OnViewFlagged()
        {
            _getFlagStatus.Execute()
                          .Where(it => it == FlagStatus.NotPlaced)
                          .Do(_ => _setFlagStatus.Execute(this))
                          .Subscribe();
        }

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