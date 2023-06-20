using System;
using UniRx;

namespace Features.Cell.Scripts.Domain.Actions
{
    public interface IGetAmountOfBombsNearby
    {
        IObservable<int> Execute();
    }
}