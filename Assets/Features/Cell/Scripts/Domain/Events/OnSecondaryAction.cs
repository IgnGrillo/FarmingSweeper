namespace Features.Cell.Scripts.Domain.Events
{
    public class OnSecondaryAction : Emitable
    {
        public CellSecondaryStatus CellSecondaryStatusChangedTo;
        
        public OnSecondaryAction(CellSecondaryStatus cellSecondaryStatusChangedTo)
        {
            CellSecondaryStatusChangedTo = cellSecondaryStatusChangedTo;
        }
    }
}