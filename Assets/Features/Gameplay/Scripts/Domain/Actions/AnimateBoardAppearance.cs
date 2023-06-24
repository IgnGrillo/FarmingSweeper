using System;
using UniRx;
using System.Linq;
using Features.Cell.Scripts.Domain;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class AnimateBoardAppearance : IAnimateBoardAppearance
    {
        public IObservable<Unit> Execute(MineSweeperBoard mineSweeperBoard)
        {
            mineSweeperBoard = GivenA3X3EmptyBoard();
            var cells = mineSweeperBoard.Cells;
            var mineSweeperCells = cells.Cast<MineSweeperCell>().ToList();
            for (var i = 0; i < mineSweeperCells.Count + 1; i++)
            {
                mineSweeperCells[i].OnAnimateAppearance
                                   .Delay(TimeSpan.FromSeconds(.5f))
                                   .Concat(mineSweeperCells[i + 1].OnAnimateAppearance);
            }
            return mineSweeperCells[0].OnAnimateAppearance;
        }
        
        private static MineSweeperBoard GivenA3X3EmptyBoard()
        {
            return new MineSweeperBoard
            {
                Cells = new[,]
                {
                    { GivenACellWith(), GivenACellWith(), GivenACellWith() },
                    { GivenACellWith(), GivenACellWith(), GivenACellWith() },
                    { GivenACellWith(), GivenACellWith(), GivenACellWith() }
                }
            };
        }
        
        private static MineSweeperCell GivenACellWith(bool isBomb = false,
                                                      CellSecondaryStatus secondaryStatus = CellSecondaryStatus.Blank,
                                                      int bombsNearby = 0) => new(isBomb, secondaryStatus, bombsNearby);
    }
}