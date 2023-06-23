using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public interface IAnimateBoardAppearance
    {
        IObservable<Unit> Execute(MineSweeperBoard mineSweeperBoard);
    }
}