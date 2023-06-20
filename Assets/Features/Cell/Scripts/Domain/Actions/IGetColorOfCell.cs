using UnityEngine;

namespace Features.Cell.Scripts.Domain.Actions
{
    public interface IGetColorOfCell
    {
        Color Execute(int bombsNearby);
    }
}