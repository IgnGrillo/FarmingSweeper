using Features.Gameplay.Scripts.Presentation;
using UnityEngine;
using static Features.Gameplay.Scripts.Providers.GameplayActionProvider;

namespace Features.Gameplay.Scripts.Delivery
{
    public class GameplayView : MonoBehaviour
    {
        [SerializeField] private CreateGameIslandData createGameIslandData;
        
        private void Start()
        {
            new GameplayPresenter(GetRetrieveGameConfiguration(),
                    GetGenerateInitialBoard(), 
                    GetCreateGameIsland(createGameIslandData),
                    GetAnimateBoardAppearance(),
                    GetPublishOnBoardInitializationFinish()).Initialize();
        }
    }
}