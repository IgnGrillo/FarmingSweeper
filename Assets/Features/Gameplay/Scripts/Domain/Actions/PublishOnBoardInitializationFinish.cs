using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class PublishOnBoardInitializationFinish : IPublishOnBoardInitializationFinish
    {
        public IObservable<Unit> Execute() => 
                Observable.ReturnUnit();
    }
}