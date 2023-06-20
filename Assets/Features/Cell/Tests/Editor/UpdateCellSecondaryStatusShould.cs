using Features.Cell.Scripts.Domain;
using Features.Cell.Scripts.Domain.Actions;
using NUnit.Framework;

namespace Features.Cell.Tests.Editor
{
    public class UpdateCellSecondaryStatusShould
    {
        [TestCase(CellSecondaryStatus.Blank, CellSecondaryStatus.Flagged)]
        [TestCase(CellSecondaryStatus.Flagged, CellSecondaryStatus.Mystery)]
        [TestCase(CellSecondaryStatus.Mystery, CellSecondaryStatus.Blank)]
        public void UpdateCellSecondaryStatusWithProvidedValues(CellSecondaryStatus cellInitialSecondaryStatus,
                                                                CellSecondaryStatus updatedStatus)
        {
            var cell = GivenAMineSweeperCell(cellInitialSecondaryStatus);
            var updateCellSecondaryStatus = GivenAnUpdateCellSecondaryStatus();
            WhenExecute(updatedStatus, updateCellSecondaryStatus, cell);
            ThenCellSecondaryStatueWas(updatedStatus, cell);
        }

        private static MineSweeperCell GivenAMineSweeperCell(CellSecondaryStatus cellInitialSecondaryStatus) =>
                new(false, cellInitialSecondaryStatus, 0);

        private static UpdateCellSecondaryStatus GivenAnUpdateCellSecondaryStatus() =>
                new();

        private static void WhenExecute(CellSecondaryStatus updatedStatus,
                                        IUpdateCellSecondaryStatus updateCellSecondaryStatus,
                                        MineSweeperCell cell) =>
                updateCellSecondaryStatus.Execute(cell, updatedStatus);

        private static void ThenCellSecondaryStatueWas(CellSecondaryStatus updatedStatus, MineSweeperCell cell) =>
                Assert.AreEqual(updatedStatus, cell.SecondaryStatus);
    }
}