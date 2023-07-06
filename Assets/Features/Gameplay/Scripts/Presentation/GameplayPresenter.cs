using System;
using Features.Board.Scripts.Delivery;
using Features.Gameplay.Scripts.Domain;
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
                                 ICreateGameIsland createGameIsland,
                                 IAnimateBoardAppearance animateBoardAppearance,
                                 IPublishOnBoardInitializationFinish publishOnBoardInitializationFinish)
        {
            _retrieveGameConfiguration = retrieveGameConfiguration;
            _createMinesweeperBoard = createMinesweeperBoard;
            _createGameIsland = createGameIsland;
            _animateBoardAppearance = animateBoardAppearance;
            _publishOnBoardInitializationFinish = publishOnBoardInitializationFinish;
        }

        public void Initialize()
        {
            _retrieveGameConfiguration.Execute()
                                      .SelectMany(CreateMineSweeperBoard)
                                      .SelectMany(CreateGameIsland)
                                      //.SelectMany(_ => _animateBoardAppearance.Execute())
                                      .SelectMany(_ => PublishOnBoardInitializationFinish())
                                      .Subscribe();
        }

        private IObservable<MineSweeperBoard> CreateMineSweeperBoard(GameConfiguration gameConfiguration) => 
                _createMinesweeperBoard.Execute(gameConfiguration);

        private IObservable<BoardView> CreateGameIsland(MineSweeperBoard mineSweeperBoard) => 
                _createGameIsland.Execute(mineSweeperBoard);

        private IObservable<Unit> PublishOnBoardInitializationFinish() => 
                _publishOnBoardInitializationFinish.Execute();
    }
}