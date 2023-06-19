using System;

namespace Features.Cell.Scripts.Domain
{
    public interface ICellView
    {
        Action OnPressed { get; set; }
        Action OnFlagged { get; set; }
        void PlayOnBombPressedAnimation();
        void PlayOnBlankSpacePressedAnimation();
    }
}