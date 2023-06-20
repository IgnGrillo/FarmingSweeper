using System;
using Features.Cell.Scripts.Presentation;

namespace Features.Cell.Scripts.Domain
{
    public interface ICellRepository
    {
        IObservable<MineSweeperCell> GetCell(MineSweeperCell presenter);
    }
}