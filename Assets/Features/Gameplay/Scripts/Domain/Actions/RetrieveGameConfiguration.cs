using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class RetrieveGameConfiguration : IRetrieveGameConfiguration
    {
        public IObservable<GameConfiguration> Execute() =>
                Observable.Return(new GameConfiguration());
    }
}