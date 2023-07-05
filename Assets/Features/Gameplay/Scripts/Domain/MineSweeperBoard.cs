using Features.Cell.Scripts.Domain;

namespace Features.Gameplay.Scripts.Domain
{
    public class MineSweeperBoard
    {
        public MineSweeperCell[,] Cells;
        public MineSweeperBoard() { }

        public MineSweeperBoard(MineSweeperCell[,] cells)
        {
            Cells = cells;
        }
    }
}