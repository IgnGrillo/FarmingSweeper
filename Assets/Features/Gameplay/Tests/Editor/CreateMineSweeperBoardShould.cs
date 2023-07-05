using System;
using System.Linq;
using Features.Cell.Scripts.Domain;
using Features.Gameplay.Scripts.Domain;
using Features.Gameplay.Scripts.Domain.Actions;
using NUnit.Framework;
using UniRx;

namespace Features.Gameplay.Tests.Editor
{
    public class CreateMineSweeperBoardShould
    {
        private CreateMineSweeperBoard _createMineSweeperBoard;
        private GameConfiguration _gameConfiguration;

        [SetUp]
        public void SetUp() =>
                _createMineSweeperBoard = new CreateMineSweeperBoard();

        [Test]
        public void GenerateA9X9MineSweeperBoardWhenBoardConfigurationIs9X9()
        {
            _gameConfiguration = GivenAGameConfigurationWith(BoardConfiguration.Board9X9);
            var boardObtained = GivenAMineSweeperBoard();
            WhenExecute().Subscribe(board => boardObtained = board);
            ThenLongLengthZeroIsOfLength(boardObtained, 9);
            ThenLongLengthOneIsOfLength(boardObtained, 9);
            ThenMineSweeperCellsAreNotNull(boardObtained);
            ThenAllTheCellsAreBlank(boardObtained);
        }

        private static GameConfiguration GivenAGameConfigurationWith(BoardConfiguration boardConfiguration) =>
                new() { BoardConfiguration = boardConfiguration };

        private static MineSweeperBoard GivenAMineSweeperBoard() =>
                new();

        private IObservable<MineSweeperBoard> WhenExecute() =>
                _createMineSweeperBoard.Execute(_gameConfiguration);

        private static void ThenLongLengthZeroIsOfLength(MineSweeperBoard boardObtained, int expected) =>
                Assert.AreEqual(expected, boardObtained.Cells.GetLongLength(0));

        private static void ThenLongLengthOneIsOfLength(MineSweeperBoard boardObtained, int expected) =>
                Assert.AreEqual(expected, boardObtained.Cells.GetLongLength(1));

        private static void ThenMineSweeperCellsAreNotNull(MineSweeperBoard boardObtained) =>
                Assert.IsEmpty(boardObtained.Cells.Cast<MineSweeperCell>().Where(item => item == null));

        private static void ThenAllTheCellsAreBlank(MineSweeperBoard boardObtained) =>
                Assert.IsFalse(boardObtained.Cells.Cast<MineSweeperCell>().Any(item => !item.IsBlank()));
    }
}