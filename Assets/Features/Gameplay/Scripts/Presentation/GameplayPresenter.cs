using Features.Gameplay.Scripts.Domain.Actions;
using UniRx;

namespace Features.Gameplay.Scripts.Presentation
{
    public class GameplayPresenter
    {
        private readonly IRetrieveGameConfiguration _retrieveGameConfiguration;
        private readonly IGenerateInitialBoard _generateInitialBoard;
        private readonly IAnimateBoardAppearance _animateBoardAppearance;

        public GameplayPresenter(IRetrieveGameConfiguration retrieveGameConfiguration,
                                 IGenerateInitialBoard generateInitialBoard,
                                 IAnimateBoardAppearance animateBoardAppearance)
        {
            _retrieveGameConfiguration = retrieveGameConfiguration;
            _generateInitialBoard = generateInitialBoard;
            _animateBoardAppearance = animateBoardAppearance;
        }

        public void Initialize()
        {
            _retrieveGameConfiguration.Execute()
                                      .SelectMany(it => _generateInitialBoard.Execute(it))
                                      .Select(it=> _animateBoardAppearance.Execute(it))
                                      .Subscribe();
        }
    }
}