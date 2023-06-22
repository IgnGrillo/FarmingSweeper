using Features.Gameplay.Scripts.Domain.Actions;

namespace Features.Gameplay.Scripts.Presentation
{
    public class GameplayPresenter
    {
        private readonly IRetrieveGameConfiguration _retrieveGameConfiguration;

        public GameplayPresenter(IRetrieveGameConfiguration retrieveGameConfiguration) => 
                _retrieveGameConfiguration = retrieveGameConfiguration;

        public void Initialize()
        {
            _retrieveGameConfiguration.Execute();
        }
    }
}