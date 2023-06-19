using System;
using Features.Cell.Tests.Editor;
using UniRx;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class GetCellType : IGetCellType
    {
        public IObservable<CellType> Execute()
        {
            return Observable.Return(CellType.Bomb);
        }
    }
}