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
            //Fluent sintax https://en.wikipedia.org/wiki/Fluent_interface
            _retrieveGameConfiguration.Execute()
                                      .SelectMany(it => _generateInitialBoard.Execute(it))
                                      .Do(it=> _animateBoardAppearance.Execute(it))
                                      .SelectMany(_ => _publishOnBoardInitializationFinish.Execute())
                                      .Subscribe();
        }
    }
}