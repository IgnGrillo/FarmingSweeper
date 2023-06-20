using System;
using UniRx;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class GetAmountOfBombsNearby : IGetAmountOfBombsNearby
    {
        public IObservable<int> Execute() => Observable.Return(1);
    }
}