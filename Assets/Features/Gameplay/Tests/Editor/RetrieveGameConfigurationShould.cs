using System;
using Features.Gameplay.Scripts.Domain;
using Features.Gameplay.Scripts.Domain.Actions;
using NSubstitute;
using UniRx;
using NUnit.Framework;

namespace Features.Gameplay.Tests.Editor
{
    public class RetrieveGameConfigurationShould
    {
        private IGameConfigurationService _gameConfigurationService;
        private RetrieveGameConfiguration _retrieveGameConfiguration;

        [Test]
        public void RetrieveGameConfigurationShouldSimplePasses()
        {
            _gameConfigurationService = Substitute.For<IGameConfigurationService>();
            _retrieveGameConfiguration = new RetrieveGameConfiguration(_gameConfigurationService);
            var gameConfiguration = GivenAGameConfiguration();
            var gameConfigurationObtained = new GameConfiguration();
            GivenAGameConfigurationServiceThatReturns(gameConfiguration);
            WhenExecute().Subscribe(onNext: configuration =>  gameConfigurationObtained = configuration);
            Assert.AreEqual(gameConfiguration, gameConfigurationObtained);
        }

        private static GameConfiguration GivenAGameConfiguration() => new();

        private void GivenAGameConfigurationServiceThatReturns(GameConfiguration gameConfiguration) => 
                _gameConfigurationService.GetGameConfiguration().Returns(Observable.Return(gameConfiguration));

        private IObservable<GameConfiguration> WhenExecute() => 
                _retrieveGameConfiguration.Execute();
    }
}