using System;
using Features.Board.Scripts.Delivery;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public interface ICreateGameIsland
    {
        IObservable<BoardView> Execute(MineSweeperBoard minesweeperBoard);
    }
}