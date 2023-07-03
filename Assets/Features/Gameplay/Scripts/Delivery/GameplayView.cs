using Features.Gameplay.Scripts.Presentation;
using UnityEngine;
using static Features.Gameplay.Scripts.Providers.GameplayActionProvider;

namespace Features.Gameplay.Scripts.Delivery
{
    public class GameplayView : MonoBehaviour
    {
        private void Start()
        {
            new GameplayPresenter(GetRetrieveGameConfiguration(),
                    GetGenerateInitialBoard(),
                    GetAnimateBoardAppearance(),
                    GetPublishOnBoardInitializationFinish()).Initialize();
        }
    }
}