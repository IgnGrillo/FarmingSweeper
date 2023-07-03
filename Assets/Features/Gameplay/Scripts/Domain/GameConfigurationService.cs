using System;
using UniRx;

namespace Features.Gameplay.Scripts.Domain
{
    public class GameConfigurationService : IGameConfigurationService
    {
        public IObservable<GameConfiguration> GetGameConfiguration() =>
                Observable.Return(new GameConfiguration { BoardConfiguration = BoardConfiguration.Board5X5 });
    }
}