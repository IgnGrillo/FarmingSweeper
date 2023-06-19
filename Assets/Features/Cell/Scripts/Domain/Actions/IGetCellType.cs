using System;

namespace Features.Cell.Tests.Editor
{
    public interface IGetCellType
    {
        IObservable<CellType> Execute();
    }
}