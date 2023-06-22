using Features.Gameplay.Scripts.Domain.Actions;
using Features.Gameplay.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Features.Gameplay.Tests.Editor
{
    public class GameplayPresenterShould
    {
        private GameplayPresenter _presenter;
        private IRetrieveGameConfiguration _retrieveGameConfiguration;

        [SetUp]
        public void SetUp()
        {
            _retrieveGameConfiguration = Substitute.For<IRetrieveGameConfiguration>();
            _presenter = new GameplayPresenter(_retrieveGameConfiguration);
        }

        [Test]
        public void RetrieveGameConfigurationDataWhenInitialized()
        {
            WhenInitialized();
            ThenRetrieveGameConfigurationWasCalled();
        }

        [Ignore("WIP")]
        [Test]
        public void ExecuteGenerateBoardWhenInitialized()
        {

        }

        private void WhenInitialized() => 
                _presenter.Initialize();

        private void ThenRetrieveGameConfigurationWasCalled() => 
                _retrieveGameConfiguration.Received(1).Execute();
    }
}