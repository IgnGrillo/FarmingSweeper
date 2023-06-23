using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class GenerateInitialBoard : IGenerateInitialBoard
    {
        public IObservable<MineSweeperBoard> Execute(GameConfiguration gameConfiguration)
        {
            return Observable.Return(new MineSweeperBoard());
        }
    }
}