using Features.Gameplay.Scripts.Delivery;
using Features.Gameplay.Scripts.Domain.Actions;

namespace Features.Gameplay.Scripts.Providers
{
    public static class GameplayActionProvider
    {
        private static RetrieveGameConfiguration _retrieveGameConfiguration;
        private static CreateMineSweeperBoard _createMineSweeperBoard;
        private static CreateGameIsland _createGameIsland;
        private static AnimateBoardAppearance _animateBoardAppearance;
        private static PublishOnBoardInitializationFinish _publishOnBoardInitializationFinish;

        public static IRetrieveGameConfiguration GetRetrieveGameConfiguration() =>
                _retrieveGameConfiguration ??= new RetrieveGameConfiguration(GameplayServiceProvider.GetGameConfigurationService());

        public static ICreateMineSweeperBoard GetGenerateInitialBoard() =>
                _createMineSweeperBoard ??= new CreateMineSweeperBoard();
        
        public static ICreateGameIsland GetCreateGameIsland(CreateGameIslandData createGameIslandData) =>
                        _createGameIsland ??= new CreateGameIsland(createGameIslandData);

        public static IAnimateBoardAppearance GetAnimateBoardAppearance() =>
                _animateBoardAppearance ??= new AnimateBoardAppearance();

        public static IPublishOnBoardInitializationFinish GetPublishOnBoardInitializationFinish() =>
                _publishOnBoardInitializationFinish ??= new PublishOnBoardInitializationFinish();
    }
}