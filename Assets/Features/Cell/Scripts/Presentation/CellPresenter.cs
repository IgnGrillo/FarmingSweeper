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
        private readonly IGetAmountOfBombsNearby _getAmountOfBombsNearby;
        private readonly ICellView _view;

        public CellPresenter(IGetCellType getCellType,
                             IPublishOnBombPressed publishOnBombPressed,
                             IPublishOnBlankSpacePressed publishOnBlankSpacePressed,
                             IGetFlagStatus getFlagStatus,
                             ISetFlagStatus setFlagStatus,
                             IGetAmountOfBombsNearby getAmountOfBombsNearby,
                             ICellView view)
        {
            _getCellType = getCellType;
            _publishOnBombPressed = publishOnBombPressed;
            _publishOnBlankSpacePressed = publishOnBlankSpacePressed;
            _getFlagStatus = getFlagStatus;
            _setFlagStatus = setFlagStatus;
            _getAmountOfBombsNearby = getAmountOfBombsNearby;
            _view = view;
        }

        public void Initialize()
        {
            _view.OnPressed += OnViewPressed;
            _view.OnFlagged += OnViewFlagged;
            _getAmountOfBombsNearby.Execute().Do(_view.DisplayAmountOfBombsNearby).Subscribe();
        }

        private void OnViewPressed() => _getCellType.Execute()
                                                    .Do(OnCellTypeObtained)
                                                    .Subscribe();

        private void OnViewFlagged() => _getFlagStatus.Execute()
                                                      .Do(OnFlagStatusObtained)
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

        private void OnFlagStatusObtained(FlagStatus flagStatus)
        {
            switch (flagStatus)
            {
                case FlagStatus.Placed:
                    RemoveFlag();
                    break;
                case FlagStatus.Removed:
                    PlaceFlag();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(flagStatus), flagStatus, null);
            }
        }
        private void PlaceFlag()
        {
            _setFlagStatus.Execute(this, FlagStatus.Placed);
            _view.PlayPlaceFlagAnimation();
        }
        
        private void RemoveFlag()
        {
            _setFlagStatus.Execute(this, FlagStatus.Removed);
            _view.PlayRemoveFlagAnimation();
        }
    }
}