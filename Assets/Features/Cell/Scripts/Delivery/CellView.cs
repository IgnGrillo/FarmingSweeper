using System;
using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using Features.Cell.Scripts.Presentation;
using Features.Cell.Scripts.Providers;
using TMPro;
using UnityEngine;

namespace Features.Cell.Scripts.Delivery
{
    public class CellView : MonoBehaviour, ICellView
    {
        [SerializeField] private TMP_Text amountOfBombsDisplay;
        [SerializeField] private CellDisplayColorByBombsNearby cellDisplayColorByBombsNearby;
        public Action OnPressed { get; set; }
        public Action OnSecondaryPressed { get; set; }

        public void Initialize(MineSweeperCell cell)
        {
            new CellPresenter(CellActionProvider.GetPublishOnBombPressed(),
                    CellActionProvider.GetPublishOnBlankPressed(),
                    CellActionProvider.GetUpdateCellSecondaryStatus(),
                    CellActionProvider.GetPublishOnCellSecondaryStatusChange(),
                    CellActionProvider.GetGetColorOfCell(cellDisplayColorByBombsNearby),
                    this).Initialize(cell);
        }

        public void PlayOnBombPressedAnimation() { }
        public void PlayOnBlankSpacePressedAnimation() { }
        public void PlayPlaceFlagAnimation() { }
        public void PlayPlaceMysteryAnimation() { }
        public void PlayBlankAnimation() { }

        public void DisplayAmountOfBombsNearby(int amountOfBombsNearby, Color color)
        {
            amountOfBombsDisplay.gameObject.SetActive(true);
            amountOfBombsDisplay.text = amountOfBombsNearby.ToString();
            amountOfBombsDisplay.color = color;
        }
    }
}