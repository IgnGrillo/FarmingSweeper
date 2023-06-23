using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public interface IGenerateInitialBoard
    {
        IObservable<MineSweeperBoard> Execute(GameConfiguration gameConfiguration);
    }

    public class GenerateInitialBoard : IGenerateInitialBoard
    {
        public IObservable<MineSweeperBoard> Execute(GameConfiguration gameConfiguration)
        {
            return Observable.Return(new MineSweeperBoard());
        }
    }
}