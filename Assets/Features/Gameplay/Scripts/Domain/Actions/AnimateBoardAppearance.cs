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
    }
}