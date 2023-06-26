using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class RetrieveGameConfiguration : IRetrieveGameConfiguration
    {
        private readonly IGameConfigurationService _gameConfigurationService;

        public RetrieveGameConfiguration(IGameConfigurationService gameConfigurationService)
        {
            _gameConfigurationService = gameConfigurationService;
        }

        public IObservable<GameConfiguration> Execute() =>
                _gameConfigurationService.GetGameConfiguration();
    }
}