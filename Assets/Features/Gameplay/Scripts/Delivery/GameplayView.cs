using Features.Gameplay.Scripts.Presentation;
using Features.Gameplay.Scripts.Providers;
using UnityEngine;

namespace Features.Gameplay.Scripts.Delivery
{
    public class GameplayView : MonoBehaviour
    {
        private void Start()
        {
            new GameplayPresenter(GameplayActionProvider.GetRetrieveGameConfiguration(),
                    GameplayActionProvider.GetGenerateInitialBoard(),
                    GameplayActionProvider.GetAnimateBoardAppearance(),
                    GameplayActionProvider.GetPublishOnBoardInitializationFinish()).Initialize();
        }
    }
}