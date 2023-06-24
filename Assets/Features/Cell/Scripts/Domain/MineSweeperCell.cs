using UniRx;

namespace Features.Cell.Scripts.Domain
{
    public class MineSweeperCell
    {
        public readonly bool IsBomb;
        public CellSecondaryStatus SecondaryStatus;
        public readonly int BombsNearby;
        public Subject<Unit> OnAnimateAppearance;

        public MineSweeperCell(bool isBomb, CellSecondaryStatus secondaryStatus, int bombsNearby)
        {
            IsBomb = isBomb;
            SecondaryStatus = secondaryStatus;
            BombsNearby = bombsNearby;
        }

        public static MineSweeperCell InitialBomb() => new MineSweeperCell(false, CellSecondaryStatus.Blank, 0);
    }
}