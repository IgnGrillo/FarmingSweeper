using System;

namespace Features.Gameplay.Scripts.Domain
{
    public interface IGameConfigurationService
    {
        IObservable<GameConfiguration> GetGameConfiguration();
    }
}