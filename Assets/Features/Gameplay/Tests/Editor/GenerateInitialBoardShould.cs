using System;
using System.Collections.Generic;
using System.Linq;
using Features.Cell.Scripts.Domain;
using Features.Gameplay.Scripts.Domain;
using Features.Gameplay.Scripts.Domain.Actions;
using NUnit.Framework;
using UniRx;

namespace Features.Gameplay.Tests.Editor
{
    public class GenerateInitialBoardShould
    {
        private GenerateInitialBoard _generateInitialBoard;
        private GameConfiguration _gameConfiguration;

        [SetUp]
        public void SetUp()
        {
            _generateInitialBoard = new GenerateInitialBoard();
            
        }
        
        [Test]
        public void GenerateA5X5MineSweeperBoardWhenBoardConfigurationIs5X5()
        {
            _gameConfiguration = GivenAGameConfigurationWith(BoardConfiguration.Board5X5);
            var boardObtained = GivenAMineSweeperBoard();
            WhenExecute().Subscribe(board => boardObtained = board);
            ThenLongLengthZeroIsOfLength(boardObtained, 5);
            ThenLongLengthOneIsOfLength(boardObtained, 5);
            ThenMineSweeperCellsAreNotNull(boardObtained);
        }

        private static GameConfiguration GivenAGameConfigurationWith(BoardConfiguration boardConfiguration) =>
                new() { BoardConfiguration = boardConfiguration };

        private static MineSweeperBoard GivenAMineSweeperBoard() => 
                new();

        private IObservable<MineSweeperBoard> WhenExecute() =>
                _generateInitialBoard.Execute(_gameConfiguration);

        private static void ThenLongLengthZeroIsOfLength(MineSweeperBoard boardObtained, int expected) => 
                Assert.AreEqual(expected, boardObtained.Cells.GetLongLength(0));

        private static void ThenLongLengthOneIsOfLength(MineSweeperBoard boardObtained, int expected) => 
                Assert.AreEqual(expected, boardObtained.Cells.GetLongLength(1));

        private static void ThenMineSweeperCellsAreNotNull(MineSweeperBoard boardObtained) => 
                        Assert.IsEmpty(boardObtained.Cells.Cast<MineSweeperCell>().Where(item => item == null));
    }
}