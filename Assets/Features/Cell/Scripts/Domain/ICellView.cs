using System;
using UnityEngine;

namespace Features.Cell.Scripts.Domain
{
    public interface ICellView
    {
        Action OnPressed { get; set; }
        Action OnSecondaryPressed { get; set; }
        void Initialize(MineSweeperCell cell);
        void PlayOnBombPressedAnimation();
        void PlayOnBlankSpacePressedAnimation();
        void PlayPlaceFlagAnimation();
        void PlayPlaceMysteryAnimation();
        void PlayBlankAnimation();
        void DisplayAmountOfBombsNearby(int amountOfBombsNearby, Color color);
    }
}