using System;
using UniRx;
namespace Features.Gameplay.Scripts.Domain.Actions
{
    public interface IRetrieveGameConfiguration
    {
        IObservable<GameConfiguration> Execute();
    }
}