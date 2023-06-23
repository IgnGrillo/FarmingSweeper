using Features.Gameplay.Scripts.Domain.Actions;
using UniRx;

namespace Features.Gameplay.Scripts.Presentation
{
    public class GameplayPresenter
    {
        private readonly IRetrieveGameConfiguration _retrieveGameConfiguration;
        private readonly IGenerateInitialBoard _generateInitialBoard;

        public GameplayPresenter(IRetrieveGameConfiguration retrieveGameConfiguration,
                                 IGenerateInitialBoard generateInitialBoard)
        {
            _retrieveGameConfiguration = retrieveGameConfiguration;
            _generateInitialBoard = generateInitialBoard;
        }

        public void Initialize()
        {
            _retrieveGameConfiguration.Execute()
                                      .Select(it => _generateInitialBoard.Execute(it))
                                      .Subscribe();
        }
    }
}