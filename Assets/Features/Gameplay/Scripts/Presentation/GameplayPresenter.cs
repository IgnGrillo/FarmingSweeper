using Features.Gameplay.Scripts.Domain.Actions;
using UniRx;

namespace Features.Gameplay.Scripts.Presentation
{
    public class GameplayPresenter
    {
        private readonly IRetrieveGameConfiguration _retrieveGameConfiguration;
        private readonly IGenerateInitialBoard _generateInitialBoard;
        private readonly IAnimateBoardAppearance _animateBoardAppearance;
        private readonly IPublishOnBoardInitializationFinish _publishOnBoardInitializationFinish;

        public GameplayPresenter(IRetrieveGameConfiguration retrieveGameConfiguration,
                                 IGenerateInitialBoard generateInitialBoard,
                                 IAnimateBoardAppearance animateBoardAppearance,
                                 IPublishOnBoardInitializationFinish publishOnBoardInitializationFinish)
        {
            _retrieveGameConfiguration = retrieveGameConfiguration;
            _generateInitialBoard = generateInitialBoard;
            _animateBoardAppearance = animateBoardAppearance;
            _publishOnBoardInitializationFinish = publishOnBoardInitializationFinish;
        }

        public void Initialize()
        {
            _retrieveGameConfiguration.Execute()
                                      .SelectMany(gameConfiguration => _generateInitialBoard.Execute(gameConfiguration))
                                      .Do(mineSweeperBoard=> _animateBoardAppearance.Execute(mineSweeperBoard))
                                      .SelectMany(_ => _publishOnBoardInitializationFinish.Execute())
                                      .Subscribe();
        }
    }
}