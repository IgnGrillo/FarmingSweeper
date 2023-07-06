using Features.Board.Delivery;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public interface ICreateGameIsland
    {
        BoardView Execute(MineSweeperBoard minesweeperBoard);
    }
}