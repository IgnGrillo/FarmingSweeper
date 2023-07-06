using System;
using Features.Board.Scripts.Delivery;
using Features.Gameplay.Scripts.Delivery;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Features.Gameplay.Scripts.Domain.Actions
{
    public class CreateGameIsland : ICreateGameIsland
    {
        private readonly CreateGameIslandData _createGameIslandData;

        public CreateGameIsland(CreateGameIslandData createGameIslandData) => 
                _createGameIslandData = createGameIslandData;

        public IObservable<BoardView> Execute(MineSweeperBoard minesweeperBoard)
        {
            var instance = Object.Instantiate(_createGameIslandData.BoardView, Vector3.zero, Quaternion.identity);
            instance.Initialize(minesweeperBoard);
            return Observable.Return(instance);
        }
    }
}