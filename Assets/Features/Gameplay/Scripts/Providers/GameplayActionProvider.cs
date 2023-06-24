using Features.Gameplay.Scripts.Domain.Actions;

namespace Features.Gameplay.Scripts.Providers
{
    public static class GameplayActionProvider
    {
        public static IRetrieveGameConfiguration GetRetrieveGameConfiguration() =>
                new RetrieveGameConfiguration();

        public static IGenerateInitialBoard GetGenerateInitialBoard() =>
                new GenerateInitialBoard();

        public static IAnimateBoardAppearance GetAnimateBoardAppearance() =>
                new AnimateBoardAppearance();

        public static IPublishOnBoardInitializationFinish GetPublishOnBoardInitializationFinish() =>
                new PublishOnBoardInitializationFinish();
    }
}