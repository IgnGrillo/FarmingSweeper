using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class AnimateBoardAppearance : IAnimateBoardAppearance
    {
        public IObservable<Unit> Execute(MineSweeperBoard mineSweeperBoard) => 
                Observable.ReturnUnit();
    }
}