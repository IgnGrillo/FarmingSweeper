using System;
using Features.Cell.Scripts.Domain;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class GenerateInitialBoard : IGenerateInitialBoard
    {
        public IObservable<MineSweeperBoard> Execute(GameConfiguration gameConfiguration)
        {
            return Observable.Return(new MineSweeperBoard
            {
                Cells = new[,]
                {
                    {
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb()
                    },
                    {
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb()
                    },
                    {
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb()
                    },
                    {
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb()
                    },
                    {
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb(),
                        MineSweeperCell.BlankBomb()
                    }
                }
            });
        }
    }
}