using System;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public interface ICreateMineSweeperBoard
    {
        IObservable<MineSweeperBoard> Execute(GameConfiguration gameConfiguration);
    }
}