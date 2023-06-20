using System;
using Features.Cell.Scripts.Domain;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Cell.Scripts.Delivery
{
    public class CellView : MonoBehaviour, ICellView
    {
        [SerializeField] private Button button;
        public Action OnPressed { get; set; }
        public Action OnSecondaryPressed { get; set; }
        
        private void OnEnable() =>
                button.onClick.AddListener(CallOnPressed);

        private void OnDisable() =>
                button.onClick.RemoveListener(CallOnPressed);
        
        public void PlayOnBombPressedAnimation() { }
        public void PlayOnBlankSpacePressedAnimation() { }
        public void PlayPlaceFlagAnimation() { }
        public void PlayPlaceMysteryAnimation() { }
        public void PlayBlankAnimation() { }
        public void DisplayAmountOfBombsNearby(int amountOfBombsNearby) { }

        private void CallOnPressed() =>
                OnPressed();
    }
}