using System;

namespace Features.Cell.Scripts.Domain
{
    public interface ICellView
    {
        Action OnPressed { get; set; }
        void PlayOnBombPressedAnimation();
    }
}