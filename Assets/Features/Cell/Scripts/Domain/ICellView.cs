using System;

namespace Features.Cell.Scripts.Domain
{
    public interface ICellView
    {
        Action OnPressed { get; set; }
        Action OnSecondaryPressed { get; set; }
        void PlayOnBombPressedAnimation();
        void PlayOnBlankSpacePressedAnimation();
        void PlayPlaceFlagAnimation();
        void PlayPlaceMysteryAnimation();
        void PlayBlankAnimation();
        void DisplayAmountOfBombsNearby(int amountOfBombsNearby);
    }
}