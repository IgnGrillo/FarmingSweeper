using Features.Gameplay.Scripts.Domain.Actions;

namespace Features.Gameplay.Scripts.Providers
{
    public static class GameplayActionProvider
    {
        private static RetrieveGameConfiguration _retrieveGameConfiguration;
        private static GenerateInitialBoard _generateInitialBoard;
        private static AnimateBoardAppearance _animateBoardAppearance;
        private static PublishOnBoardInitializationFinish _publishOnBoardInitializationFinish;

        public static IRetrieveGameConfiguration GetRetrieveGameConfiguration() =>
                _retrieveGameConfiguration ??= new RetrieveGameConfiguration(GameplayServiceProvider.GetGameConfigurationService());

        public static IGenerateInitialBoard GetGenerateInitialBoard() =>
                _generateInitialBoard ??= new GenerateInitialBoard();

        public static IAnimateBoardAppearance GetAnimateBoardAppearance() =>
                _animateBoardAppearance ??= new AnimateBoardAppearance();

        public static IPublishOnBoardInitializationFinish GetPublishOnBoardInitializationFinish() =>
                _publishOnBoardInitializationFinish ??= new PublishOnBoardInitializationFinish();
    }
}