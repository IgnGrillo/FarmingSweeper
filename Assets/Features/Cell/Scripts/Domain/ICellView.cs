using System;
using Features.Cell.Scripts.Presentation;

namespace Features.Cell.Scripts.Domain
{
    public interface ICellView
    {
        Action OnPressed { get; set; }
        Action OnFlagged { get; set; }
        void PlayOnBombPressedAnimation();
        void PlayOnBlankSpacePressedAnimation();
        void PlayPlaceFlagAnimation();
    }
}