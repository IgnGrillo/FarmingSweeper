using Features.Board.Scripts.Delivery;
using UnityEngine;

namespace Features.Gameplay.Scripts.Delivery
{
    [CreateAssetMenu(menuName = "Create CreateGameIslandData", fileName = "CreateGameIslandData", order = 0)]
    public class CreateGameIslandData : ScriptableObject
    {
        public BoardView BoardView;
    }
}