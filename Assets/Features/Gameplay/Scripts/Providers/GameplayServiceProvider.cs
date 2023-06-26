using Features.Gameplay.Scripts.Domain;

namespace Features.Gameplay.Scripts.Providers
{
    public static class GameplayServiceProvider
    {
        private static GameConfigurationService _gameConfigurationService;

        public static IGameConfigurationService GetGameConfigurationService() =>
                _gameConfigurationService ??= new GameConfigurationService();
    }
}