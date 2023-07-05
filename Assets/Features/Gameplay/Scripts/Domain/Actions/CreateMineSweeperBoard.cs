using System;
using Features.Cell.Scripts.Domain;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class CreateMineSweeperBoard : IGenerateInitialBoard
    {
        public IObservable<MineSweeperBoard> Execute(GameConfiguration gameConfiguration) => 
                Observable.Return(new MineSweeperBoard(cells: GetCellsForAConfigurationOf(gameConfiguration)));

        private static MineSweeperCell[,] GetCellsForAConfigurationOf(GameConfiguration gameConfiguration)
        {
            var numberOfCells = GetBoardDimensionFor(gameConfiguration.BoardConfiguration);
            var cells = new MineSweeperCell [numberOfCells, numberOfCells];
            for (var i = 0; i < cells.GetLongLength(0); i++)
            {
                for (var j = 0; j < cells.GetLongLength(1); j++)
                {
                    cells[i, j] = MineSweeperCell.BlankBomb();
                }
            }
            return cells;
        }

        private static int GetBoardDimensionFor(BoardConfiguration boardConfiguration)
        {
            return boardConfiguration switch
            {
                BoardConfiguration.Board9X9 => 9,
                _ => throw new ArgumentOutOfRangeException(nameof(boardConfiguration), boardConfiguration, null)
            };
        }
    }
}