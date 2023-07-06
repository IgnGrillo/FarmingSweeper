using Features.Gameplay.Scripts.Domain.Actions;
using UniRx;

namespace Features.Gameplay.Scripts.Presentation
{
    public class GameplayPresenter
    {
        private readonly IRetrieveGameConfiguration _retrieveGameConfiguration;
        private readonly ICreateMineSweeperBoard _createMinesweeperBoard;
        private readonly ICreateGameIsland _createGameIsland;
        private readonly IAnimateBoardAppearance _animateBoardAppearance;
        private readonly IPublishOnBoardInitializationFinish _publishOnBoardInitializationFinish;

        public GameplayPresenter(IRetrieveGameConfiguration retrieveGameConfiguration,
                                 ICreateMineSweeperBoard createMinesweeperBoard,
                                 IAnimateBoardAppearance animateBoardAppearance,
                                 IPublishOnBoardInitializationFinish publishOnBoardInitializationFinish)
        {
            _retrieveGameConfiguration = retrieveGameConfiguration;
            _createMinesweeperBoard = createMinesweeperBoard;
            _animateBoardAppearance = animateBoardAppearance;
            _publishOnBoardInitializationFinish = publishOnBoardInitializationFinish;
        }

        public void Initialize()
        {
            _retrieveGameConfiguration.Execute()
                                      .SelectMany(gameConfiguration => _createMinesweeperBoard.Execute(gameConfiguration))
                                      .Do(minesweeperBoard => _createGameIsland.Execute(minesweeperBoard))
                                      .Do(mineSweeperBoard => _animateBoardAppearance.Execute(mineSweeperBoard))
                                      .SelectMany(_ => _publishOnBoardInitializationFinish.Execute())
                                      .Subscribe();
        }
    }
}