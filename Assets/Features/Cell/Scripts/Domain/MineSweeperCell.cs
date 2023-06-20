namespace Features.Cell.Scripts.Domain
{
    public class MineSweeperCell
    {
        public bool IsBomb;
        public CellSecondaryStatus SecondaryStatus;
        public int BombsNearby;

        public MineSweeperCell(bool isBomb, CellSecondaryStatus secondaryStatus, int bombsNearby)
        {
            IsBomb = isBomb;
            SecondaryStatus = secondaryStatus;
            BombsNearby = bombsNearby;
        }
    }
}