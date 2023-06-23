using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public interface IPublishOnBoardInitializationFinish
    {
        IObservable<Unit> Execute();
    }
}