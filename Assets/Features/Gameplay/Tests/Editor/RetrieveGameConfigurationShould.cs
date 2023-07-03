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
        [Test]
        public void RetrieveGameConfigurationShouldSimplePasses()
        {
            var gameConfigurationService = GivenAGameConfigurationService();
            var retrieveGameConfiguration = GivenARetrieveGameConfiguration(gameConfigurationService);
            var expectedGameConfiguration = GivenAGameConfiguration();
            GameConfiguration gameConfigurationObtained = null;
            GivenAGameConfigurationServiceThatReturns(gameConfigurationService, expectedGameConfiguration);
            WhenExecute(retrieveGameConfiguration).Subscribe(onNext: configuration =>  gameConfigurationObtained = configuration);
            ThenGameConfigurationIs(expectedGameConfiguration, gameConfigurationObtained);
        }

        private static IGameConfigurationService GivenAGameConfigurationService() => 
                        Substitute.For<IGameConfigurationService>();

        private static IRetrieveGameConfiguration GivenARetrieveGameConfiguration(IGameConfigurationService gameConfigurationService) => 
                        new RetrieveGameConfiguration(gameConfigurationService);

        private static GameConfiguration GivenAGameConfiguration() => 
                new();

        private static void GivenAGameConfigurationServiceThatReturns(IGameConfigurationService gameConfigurationService, GameConfiguration gameConfiguration) => 
                gameConfigurationService.GetGameConfiguration().Returns(Observable.Return(gameConfiguration));

        private static IObservable<GameConfiguration> WhenExecute(IRetrieveGameConfiguration retrieveGameConfiguration) => 
                retrieveGameConfiguration.Execute();

        private static void ThenGameConfigurationIs(GameConfiguration expectedGameConfiguration,
                                                    GameConfiguration actualGameConfigurationObtained) => 
                Assert.AreEqual(expectedGameConfiguration, actualGameConfigurationObtained);
    }
}