using System;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public interface IGenerateInitialBoard
    {
        IObservable<MineSweeperBoard> Execute(GameConfiguration gameConfiguration);
    }
}