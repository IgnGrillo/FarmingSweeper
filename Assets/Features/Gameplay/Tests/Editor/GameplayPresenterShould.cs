using Features.Gameplay.Scripts.Domain;
using Features.Gameplay.Scripts.Domain.Actions;
using Features.Gameplay.Scripts.Presentation;
using NSubstitute;
using NUnit.Framework;
using UniRx;

namespace Features.Gameplay.Tests.Editor
{
    public class GameplayPresenterShould
    {
        private IRetrieveGameConfiguration _retrieveGameConfiguration;
        private IGenerateInitialBoard _generateInitialBoard;
        private IAnimateBoardAppearance _animateBoardAppearance;
        private IPublishOnBoardInitializationFinish _publishOnBoardInitializationFinish;
        private GameplayPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _retrieveGameConfiguration = Substitute.For<IRetrieveGameConfiguration>();
            _generateInitialBoard = Substitute.For<IGenerateInitialBoard>();
            _animateBoardAppearance = Substitute.For<IAnimateBoardAppearance>();
            _publishOnBoardInitializationFinish = Substitute.For<IPublishOnBoardInitializationFinish>();
            _presenter = new GameplayPresenter(_retrieveGameConfiguration,
                    _generateInitialBoard,
                    _animateBoardAppearance,
                    _publishOnBoardInitializationFinish);
        }

        [Test]
        public void RetrieveGameConfigurationDataWhenInitialized()
        {
            WhenInitialized();
            ThenRetrieveGameConfiguration();
        }

        [Test]
        public void GenerateInitialBoardWhenInitializedAndHasRetrieveGameConfiguration()
        {
            var gameConfiguration = new GameConfiguration();
            GivenARetrieveGameConfigurationThatReturns(gameConfiguration);
            WhenInitialized();
            ThenGenerateInitialBoard(gameConfiguration);
        }

        [Test]
        public void AnimateBoardWhenInitializedWhenInitializedAndHasGeneratedInitialBoard()
        {
            var gameConfiguration = new GameConfiguration();
            var mineSweeperBoard = new MineSweeperBoard();
            GivenARetrieveGameConfigurationThatReturns(gameConfiguration);
            GivenAGenerateInitialBoardThatReturns(mineSweeperBoard);
            WhenInitialized();
            ThenAnimateBoardAppearance(mineSweeperBoard);
        }

        [Test]
        public void PublishOnBoardInitializationFinishWhenInitializedAndHasAnimatedBoard()
        {
            var gameConfiguration = new GameConfiguration();
            var mineSweeperBoard = new MineSweeperBoard();
            GivenARetrieveGameConfigurationThatReturns(gameConfiguration);
            GivenAGenerateInitialBoardThatReturns(mineSweeperBoard);
            GivenAnAnimateBoardAppearanceThatReturns();
            WhenInitialized();
            ThenPublishOnBoardInitializationFinish();
        }

        private void GivenARetrieveGameConfigurationThatReturns(GameConfiguration gameConfiguration) =>
                _retrieveGameConfiguration.Execute().Returns(Observable.Return(gameConfiguration));

        private void GivenAGenerateInitialBoardThatReturns(MineSweeperBoard mineSweeperBoard) =>
                _generateInitialBoard.Execute(Arg.Any<GameConfiguration>())
                                     .Returns(Observable.Return(mineSweeperBoard));

        private void GivenAnAnimateBoardAppearanceThatReturns() =>
                _animateBoardAppearance.Execute(Arg.Any<MineSweeperBoard>()).Returns(Observable.ReturnUnit());

        private void WhenInitialized() =>
                _presenter.Initialize();

        private void ThenRetrieveGameConfiguration() =>
                _retrieveGameConfiguration.Received(1).Execute();

        private void ThenGenerateInitialBoard(GameConfiguration gameConfiguration) =>
                _generateInitialBoard.Received(1).Execute(gameConfiguration);

        private void ThenAnimateBoardAppearance(MineSweeperBoard mineSweeperBoard) =>
                _animateBoardAppearance.Received(1).Execute(mineSweeperBoard);
        private void ThenPublishOnBoardInitializationFinish() =>
                _publishOnBoardInitializationFinish.Received(1).Execute();
    }
}