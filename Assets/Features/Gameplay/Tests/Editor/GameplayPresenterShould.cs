using Features.Gameplay.Scripts.Domain;
using Features.Gameplay.Scripts.Domain.Actions;
using Features.Gameplay.Scripts.Presentation;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using UniRx;

namespace Features.Gameplay.Tests.Editor
{
    public class GameplayPresenterShould
    {
        private IRetrieveGameConfiguration _retrieveGameConfiguration;
        private IGenerateInitialBoard _generateInitialBoard;
        private GameplayPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _retrieveGameConfiguration = Substitute.For<IRetrieveGameConfiguration>();
            _generateInitialBoard = Substitute.For<IGenerateInitialBoard>();
            _presenter = new GameplayPresenter(_retrieveGameConfiguration,
                    _generateInitialBoard);
        }

        [Test]
        public void RetrieveGameConfigurationDataWhenInitialized()
        {
            WhenInitialized();
            ThenRetrieveGameConfigurationWasCalled();
        }

        [Test]
        public void GenerateInitialBoardWhenInitialized()
        {
            var gameConfiguration = new GameConfiguration();
            GivenARetrieveGameConfigurationThatReturns(gameConfiguration);
            WhenInitialized();
            ThenGenerateInitialBoard(gameConfiguration);
        }

        private void GivenARetrieveGameConfigurationThatReturns(GameConfiguration gameConfiguration) => 
                _retrieveGameConfiguration.Execute().Returns(Observable.Return(gameConfiguration));

        private void WhenInitialized() =>
                _presenter.Initialize();

        private void ThenRetrieveGameConfigurationWasCalled() =>
                _retrieveGameConfiguration.Received(1).Execute();

        private void ThenGenerateInitialBoard(GameConfiguration gameConfiguration) => 
                _generateInitialBoard.Received(1).Execute(gameConfiguration);
    }
}