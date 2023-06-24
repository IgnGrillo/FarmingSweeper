using Features.Cell.Scripts.Domain;
using Features.Gameplay.Scripts.Domain;
using Features.Gameplay.Scripts.Domain.Actions;
using NUnit.Framework;

namespace Features.Gameplay.Tests.Editor
{
    public class AnimateBoardAppearanceShould
    {
        [Ignore("Wip")]
        [Test]
        public void AnimateBoardAppearanceShouldSimplePasses()
        {
            var mineSweeperBoard = GivenA3X3EmptyBoard();
            var animateBoardAppearance = new AnimateBoardAppearance();
            animateBoardAppearance.Execute(mineSweeperBoard);
        }

        private static MineSweeperBoard GivenA3X3EmptyBoard()
        {
            return new MineSweeperBoard
            {
                Cells = new[,]
                {
                    { GivenACellWith(), GivenACellWith(), GivenACellWith() },
                    { GivenACellWith(), GivenACellWith(), GivenACellWith() },
                    { GivenACellWith(), GivenACellWith(), GivenACellWith() }
                }
            };
        }

        private static MineSweeperCell GivenACellWith(bool isBomb = false,
                                                      CellSecondaryStatus secondaryStatus = CellSecondaryStatus.Blank,
                                                      int bombsNearby = 0) => new(isBomb, secondaryStatus, bombsNearby);
    }
}